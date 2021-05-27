using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MIRcat_Control;

namespace PSC.MIRcatTest
{
    class LaserSupport
    {
        #region Public Properties

        public Dictionary<int, QclRange> QclChips { get; private set; }
        public TimeSpan UpdateDelay { get; set; } = TimeSpan.FromSeconds(1);
        public TimeSpan DefaultTimeout { get; set; } = TimeSpan.FromSeconds(40);

        #endregion

        #region Public Methods

        public void StartLaser(double wavenumber, CancellationToken cxToken)
        {
            try
            {
                var fxnStartTime = DateTime.Now;
                var timeoutRemaining = new Func<TimeSpan>(
                    () =>
                    {
                        var elapsed = DateTime.Now.Subtract(fxnStartTime);
                        if (elapsed >= DefaultTimeout)
                        {
                            return TimeSpan.Zero;
                        }
                        return this.DefaultTimeout - elapsed;
                    });

                this.EnsureArmed(wavenumber, false, cxToken);

                this.WaitLaserIsTuned(timeoutRemaining(), cxToken);

                if (!this.GetIsEmitting())
                {
                    Console.WriteLine("MIRcatSDK_TurnEmissionOn()");
                    TryCmd(MIRcatSDK.MIRcatSDK_TurnEmissionOn());

                    this.WaitLaserEmitting(timeoutRemaining(), cxToken);
                    Thread.Sleep(TimeSpan.FromSeconds(0.5));    // wait for the TECs to go out of spec (if they're going to)
                }

                this.WaitTempNormalize(timeoutRemaining(), cxToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error starting laser.", ex);
            }
        }
        public void StopLaser()
        {
            try
            {
                bool bEmission = false;
                TryCmd(MIRcatSDK.MIRcatSDK_IsEmissionOn(ref bEmission));
                Console.WriteLine(string.Format(
                    "MIRcatSDK_IsEmissionOn( {0} )",
                    bEmission));
                if (bEmission)
                {
                    Console.WriteLine("MIRcatSDK_TurnEmissionOff()");
                    TryCmd(MIRcatSDK.MIRcatSDK_TurnEmissionOff());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error stopping laser.", ex);
            }
        }


        public void EnsureArmed(double invCm, bool bFixErrors, CancellationToken cxToken)
        {
            var cxEvent = cxToken.WaitHandle;

            try
            {
                lock (this)
                {
                    this.TryErrorCheck(!bFixErrors, true);                                                  // check for error state

                    var fxnStartTime = DateTime.Now;
                    var timeoutRemaining = new Func<TimeSpan>(
                        () =>
                        {
                            var elapsed = DateTime.Now.Subtract(fxnStartTime);
                            if (elapsed >= DefaultTimeout)
                            {
                                return TimeSpan.Zero;
                            }
                            return DefaultTimeout - elapsed;
                        });

                    bool bKeySwitchSet = false;                                                             // Check key switch state
                                                                                                            // 
                    TryCmd(MIRcatSDK.MIRcatSDK_IsKeySwitchStatusSet(ref bKeySwitchSet));                    // 
                                                                                                            // 
                    Console.WriteLine(string.Format(                                                        // 
                        "MIRcatSDK_IsKeySwitchStatusSet( {0} )",                                            // 
                        bKeySwitchSet));                                                                    // 
                                                                                                            //   

                    if (!bKeySwitchSet)
                    {
                        throw new Exception("Key switch not set.");
                    }

                    Console.WriteLine("    Key switch ok");

                    bool bInterlockSet = false;                                                             // Check interlock state
                                                                                                            // 
                    TryCmd(MIRcatSDK.MIRcatSDK_IsInterlockedStatusSet(ref bInterlockSet));                  //  
                                                                                                            // 
                    Console.WriteLine(string.Format(                                                        // 
                        "MIRcatSDK_IsInterlockedStatusSet( {0} )",                                          // 
                        bInterlockSet));                                                                    // 
                                                                                                            // 

                    if (!bInterlockSet)
                    {
                        throw new Exception("Interlock not set.");
                    }

                    Console.WriteLine("    Interlock ok");

                    bool bArmed = false;                                                                    // Arm laser.  Check if already armed

                    TryCmd(MIRcatSDK.MIRcatSDK_IsLaserArmed(ref bArmed));                                   // and do not attempt to re-arm if so.
                                                                                                            // 
                    Console.WriteLine(string.Format(                                                        // 
                        "MIRcatSDK_IsLaserArmed( {0} )",                                                    // 
                        bArmed));                                                                           // 
                                                                                                            // 
                    if (!bArmed)                                                                            // 
                    {                                                                                       // 
                        Console.WriteLine("MIRcatSDK_ArmLaser()");                                          // 
                                                                                                            // 
                        TryCmd(MIRcatSDK.MIRcatSDK_ArmLaser());                                             // Arm laser 
                                                                                                            // 
                        do                                                                                  // 
                        {                                                                                   // 
                            TryCmd(MIRcatSDK.MIRcatSDK_IsLaserArmed(ref bArmed));                           // 
                                                                                                            // 
                            Console.WriteLine(string.Format(                                                // 
                                "MIRcatSDK_IsLaserArmed( {0} )",                                            // 
                                bArmed));                                                                   // 
                                                                                                            // 
                            this.TryErrorCheck(!bFixErrors, true);                                          // 
                        }                                                                                   // 
                        while (!bArmed                                                                      //
                            && timeoutRemaining() > TimeSpan.Zero                                           // 
                            && !(null != cxEvent && cxEvent.WaitOne(UpdateDelay)));                         // 
                    }                                                                                       // 

                    if (null != cxEvent && cxEvent.WaitOne(0, false))
                    {
                        throw new Exception("Laser arming sequence canceled.");
                    }

                    if (!bArmed)
                    {
                        throw new Exception("Timeout waiting for laser to arm.");
                    }

                    Console.WriteLine("    Laser armed");

                    this.WaitTempNormalize(timeoutRemaining(), cxToken);

                    Console.WriteLine("    TECs are at temperature.");

                    int Qcl_num = this.GetQclNum(invCm);                                                    // specify the QCL number for the given wavelength

                    float fTuneWW = 0;                                                                      // Check if we are already tuned to the 
                    Units units = Units.MIRcatSDK_UNITS_CM1;                                                // same wavenumber and chip. Do not issue
                    byte preferredQcl = 0;                                                                  // the TuneToWW command if we are.
                                                                                                            // 
                    TryCmd(MIRcatSDK.MIRcatSDK_GetTuneWW(ref fTuneWW, ref units, ref preferredQcl));        // 
                                                                                                            // 
                    Console.WriteLine(string.Format(                                                        // 
                        "MIRcatSDK_GetTuneWW( {0}, {1}, {2} )",                                             // 
                        fTuneWW,                                                                            // 
                        units,                                                                              // 
                        preferredQcl));                                                                     // 
                                                                                                            // 
                    float fTuneWW_CM1 = ConvertWW(fTuneWW, units, Units.MIRcatSDK_UNITS_CM1);               // 
                                                                                                            // 
                    //if (this.GetIsTuned()                                                                   //
                    //    && float.Equals((float)invCm, fTuneWW_CM1)                                          // 
                    //    && byte.Equals((byte)Qcl_num, preferredQcl))                                        // 
                    //{                                                                                       // 
                    //    Console.WriteLine(string.Format(                                                    // 
                    //        "MIRcat already tuned to {0} cm-1. Skipping tune command.",                     // 
                    //        invCm));                                                                        // 
                    //}                                                                                       // 
                    //else                                                                                    // 
                    {
                        Console.WriteLine(string.Format(
                            "MIRcatSDK_TuneToWW( {0}, {1}, {2} )",
                            (float)invCm,
                            Units.MIRcatSDK_UNITS_CM1,
                            (byte)Qcl_num));

                        TryCmd(MIRcatSDK.MIRcatSDK_TuneToWW((float)invCm, Units.MIRcatSDK_UNITS_CM1, (byte)Qcl_num)); // do a tune to the last known frequency
                    }

                    this.WaitLaserIsTuned(timeoutRemaining(), cxToken);

                    this.TryErrorCheck(!bFixErrors, true);                                                  // Error check again

                    if (this.GetIsEmitting())                                                               // CW MIRcats can have TEC temperature spikes
                    {                                                                                       // after changing the active QCL.  That is why
                        this.WaitTempNormalize(timeoutRemaining(), cxToken);                                // we wait to cool again after tuning.
                    }                                                                                       //                                                                                                             

                    bool bSysError = false;                                                                 //  
                                                                                                            // 
                    TryCmd(MIRcatSDK.MIRcatSDK_IsSystemError(ref bSysError));                               // test the system before declaring good
                                                                                                            // 
                    Console.WriteLine(string.Format(                                                        // 
                        "MIRcatSDK_IsSystemError( {0} )",                                                   // 
                        bSysError));                                                                        // 
                                                                                                            // 
                    if (bSysError)                                                                          // 
                    {                                                                                       // 
                        throw new Exception("MIRcat is indicating a system error.");                        // 
                    }                                                                                       //
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to arm MIRcat laser.", ex);
            }
        }

        public void QueryLaserStages()
        {
            try
            {
                byte numOfQcls = 0;
                TryCmd(MIRcatSDK.MIRcatSDK_GetNumInstalledQcls(ref numOfQcls));

                Console.WriteLine(string.Format(
                    "MIRcatSDK_GetNumInstalledQcls( {0} )",
                    numOfQcls));

                // collect the hardware-reported stages
                var hwQcls = Enumerable.Range(1, numOfQcls).Select(
                    i =>
                    {
                        byte iQcl = Convert.ToByte(i);
                        float limW1 = 0;
                        float limW2 = 0;
                        Units unit = Units.MIRcatSDK_UNITS_CM1;

                        TryCmd(MIRcatSDK.MIRcatSDK_GetQclTuningRange(iQcl, ref limW1, ref limW2, ref unit));

                        Console.WriteLine(string.Format(
                            "MIRcatSDK_GetQclTuningRange( {0}, {1}, {2}, {3} )",
                            iQcl,
                            limW1,
                            limW2,
                            unit));

                        if (unit != Units.MIRcatSDK_UNITS_CM1)
                        {
                            limW1 = ConvertWW(limW1, unit, Units.MIRcatSDK_UNITS_CM1);
                            limW2 = ConvertWW(limW2, unit, Units.MIRcatSDK_UNITS_CM1);
                        }

                        var minWn = Math.Min(limW1, limW2);
                        var maxWn = Math.Max(limW1, limW2);

                        return new QclRange() { ChipNum = iQcl, minWn = minWn, maxWn = maxWn };
                    })
                    .ToDictionary(item => item.ChipNum, item => item);

                // log the collected stage information
                Console.WriteLine(string.Join(", ", hwQcls.Values.Select(item => string.Format("QCL{0}:[{1:0.##} - {2:0.##} cm-1]", item.ChipNum, item.minWn, item.maxWn))));

                this.QclChips = hwQcls;
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading MIRcat laser configuration.", ex);
            }
        }

        // We have seen a communication error when converting units
        // using the MIRcatSDK_ConvertWW method.  We therefore do this 
        // trivial conversion ourselves.
        public static float ConvertWW(
            float fWW,
            Units currentUnits,
            Units newUnits)
        {
            return currentUnits == newUnits ? fWW : Convert.ToSingle(1e4D / fWW);
        }

        /// <summary>
        /// Create a default Advanced Sweep configuration that uses the whole laser's range.
        /// </summary>
        /// <returns>IEnumerable of QclRange objects defining the sweep.</returns>
        public IEnumerable<QclRange> BuildSweep()
        {
            // sweep from lowest wavenumber to highest across all available chips

            if (null == this.QclChips)
            {
                this.QueryLaserStages();
            }

            var ordered = this.QclChips.Values.OrderBy(item => Math.Min(item.minWn, item.maxWn)).ToArray();

            double? transWn = null;

            for (int i = 0; i < ordered.Length; i++)
            {
                var curQcl = ordered[i];

                var nextQcl = (i < (ordered.Length - 1)) ? ordered[i + 1] : null;

                var qclStart = (null == transWn) ? curQcl.MinWn : transWn ?? throw new Exception();

                // look for next transition point (use midpoint)
                var qclEnd = (null == nextQcl) ? curQcl.MaxWn : (curQcl.MaxWn + nextQcl.MinWn) / 2;

                yield return new QclRange() { ChipNum = curQcl.ChipNum, minWn = qclStart, maxWn = qclEnd };

                transWn = qclEnd;
            }
        }

        #endregion

        #region Private Methods

        private static void TryCmd(SDKConstant result)
        {
            if (MIRcatSDK.MIRcatSDK_Failed(result))
            {
                throw new Exception(MIRcatSDK.MIRcatSDK_GetErrorDesc(result));
            }
        }

        private void WaitLaserIsTuned(TimeSpan timeout, CancellationToken cxToken)
        {
            try
            {
                var cxEvent = cxToken.WaitHandle;

                DateTime startTime = DateTime.Now;

                while (!this.GetIsTuned()
                    && DateTime.Now.Subtract(startTime) < timeout
                    && !cxEvent.WaitOne(UpdateDelay))
                {
                    this.TestForErrors();
                }

                if (!cxEvent.WaitOne(0))
                {
                    if (!this.GetIsTuned())
                    {
                        throw new TimeoutException();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error waiting for laser to tune.", ex);
            }
        }
        private void WaitLaserEmitting(TimeSpan timeout, CancellationToken cxToken)
        {
            try
            {
                var cxEvent = cxToken.WaitHandle;

                DateTime startTime = DateTime.Now;

                while (!this.GetIsEmitting()
                    && DateTime.Now.Subtract(startTime) < timeout
                    && !cxEvent.WaitOne(UpdateDelay))
                {
                    this.TestForErrors();
                }

                if (!cxEvent.WaitOne(0))
                {
                    if (!this.GetIsEmitting())
                    {
                        throw new TimeoutException();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error waiting for laser to emit.", ex);
            }
        }
        private void WaitTempNormalize(TimeSpan timeout, CancellationToken cxToken)
        {
            try
            {
                var cxEvent = cxToken.WaitHandle;

                DateTime startTime = DateTime.Now;

                while (!this.AreTECsAtSetTemperature()
                    && DateTime.Now.Subtract(startTime) < timeout
                    && !cxEvent.WaitOne(UpdateDelay))
                {
                    this.TestForErrors();
                }


                if (!cxEvent.WaitOne(0))
                {
                    if (!this.AreTECsAtSetTemperature())
                    {
                        throw new TimeoutException();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error waiting for laser temperature to stabilize.", ex);
            }
        }

        /// <summary>
        /// Read MIRcat error condition, and clear if possible.  Will throw an exception only if the error cannot be cleared.
        /// </summary>
        /// <param name="bThrowErrors">Throw an exception if there is an error condition (even if it is clearable).</param>
        /// <param name="bClearErrors">Attempt to clear errors if present.</param>
        /// <param name="bWarnErrors">Notify the user (via GUI) if an error condition was present.</param>
        /// <param name="bWarned">'True' if an error condition was found and cleared, and the user was warned.</param>
        private void TryErrorCheck(bool bThrowErrors, bool bClearErrors)
        {
            bool bSysError = false;

            TryCmd(MIRcatSDK.MIRcatSDK_IsSystemError(ref bSysError));

            Console.WriteLine(string.Format(
                "MIRcatSDK_IsSystemError( {0} )",
                bSysError));

            if (bSysError)
            {
                MIRcatConstant errCode = 0;

                TryCmd(MIRcatSDK.MIRcatSDK_GetSystemErrorWord(ref errCode));

                Console.WriteLine(string.Format(
                    "MIRcatSDK_GetSystemErrorWord( {0} )",
                    errCode));

                Console.WriteLine(string.Format("MIRcat reported error: {0}",
                    MIRcatSDK.MIRcatSDK_GetErrorDesc(errCode)));

                if (bClearErrors)
                {
                    // now try clearing the error...
                    bool clearOk = false;

                    TryCmd(MIRcatSDK.MIRcatSDK_ClearSystemError(ref clearOk));

                    Console.WriteLine(string.Format(
                        "MIRcatSDK_ClearSystemError( {0} )",
                        clearOk));

                    if (!bThrowErrors)  // only warn or report clear failure if we are not throwing the original error
                    {
                        if (clearOk)
                        {
                            Console.WriteLine(string.Format(
                                "The MIRcat was indicating a system error.\n\n{0}\n\nWhich has now been cleared.",
                                MIRcatSDK.MIRcatSDK_GetErrorDesc(errCode)));
                        }
                        else
                        {
                            throw new Exception(string.Format(
                                "The MIRcat is indicating a system error.\n\n{0}\n\nPlease use MIRcat control software to clear the error.",
                                MIRcatSDK.MIRcatSDK_GetErrorDesc(errCode)));
                        }
                    }

                    // one more check to make sure the error really did clear
                    TryCmd(MIRcatSDK.MIRcatSDK_IsSystemError(ref bSysError));

                    Console.WriteLine(string.Format(
                        "MIRcatSDK_IsSystemError( {0} )",
                        bSysError));
                }

                if (bSysError)
                {
                    TryCmd(MIRcatSDK.MIRcatSDK_GetSystemErrorWord(ref errCode));

                    Console.WriteLine(string.Format(
                        "MIRcatSDK_GetSystemErrorWord( {0} )",
                        errCode));

                    if (bThrowErrors)
                    {
                        throw new Exception(
                            MIRcatSDK.MIRcatSDK_GetErrorDesc(errCode));
                    }
                    if (bClearErrors)
                    {
                        throw new Exception(string.Format(
                            "The MIRcat is indicating a persistent system error.\n\n{0}\n\nPlease use MIRcat control software to clear the error.",
                            MIRcatSDK.MIRcatSDK_GetErrorDesc(errCode)));
                    }
                }
            }
        }

        /// <summary>
        /// Read MIRcat error condition and throw an exception if an error is present.
        /// </summary>
        private void TestForErrors()
        {
            bool bSysError = false;
            MIRcatConstant errCode = 0;

            TryCmd(MIRcatSDK.MIRcatSDK_IsSystemError(ref bSysError));

            Console.WriteLine(string.Format(
                "MIRcatSDK_IsSystemError( {0} )",
                bSysError));

            if (bSysError)
            {
                TryCmd(MIRcatSDK.MIRcatSDK_GetSystemErrorWord(ref errCode));

                Console.WriteLine(string.Format(
                    "MIRcatSDK_GetSystemErrorWord( {0} )",
                    errCode));

                throw new Exception(string.Format(
                    "The MIRcat is indicating a system error:\n'{0}'",
                    MIRcatSDK.MIRcatSDK_GetErrorDesc(errCode)));
            }
        }
        private bool GetIsEmitting()
        {
            bool bIsEmitting = false;

            TryCmd(MIRcatSDK.MIRcatSDK_IsEmissionOn(ref bIsEmitting));

            Console.WriteLine(string.Format(
                "MIRcatSDK_IsEmissionOn( {0} )",
                bIsEmitting));

            return bIsEmitting;
        }
        private bool GetIsTuned()
        {
            bool bIsTuned = false;

            TryCmd(MIRcatSDK.MIRcatSDK_IsTuned(ref bIsTuned));

            Console.WriteLine(string.Format(
                "MIRcatSDK_IsTuned( {0} )",
                bIsTuned));

            return bIsTuned;
        }
        private bool AreTECsAtSetTemperature()
        {
            bool bAtSetTemperature = false;

            TryCmd(MIRcatSDK.MIRcatSDK_AreTECsAtSetTemperature(ref bAtSetTemperature));

            Console.WriteLine(string.Format(
                "MIRcatSDK_AreTECsAtSetTemperature( {0} )",
                bAtSetTemperature));

            return bAtSetTemperature;
        }

        private int GetQclNum(double invCm)
        {
            if (null == this.QclChips)
            {
                this.QueryLaserStages();
            }

            return this.QclChips?.Values.FirstOrDefault(chip => chip.Contains(invCm))?.ChipNum ?? throw new Exception(string.Format("No QCL chip covers '{0:0.#}' cm-1", invCm));
        }

        #endregion
    }

    public static class LaserExtensions
    {
        public static float MinWn(this IEnumerable<QclRange> span) => Convert.ToSingle(span.Min(item => Math.Min(item.minWn, item.maxWn)));
        public static float MaxWn(this IEnumerable<QclRange> span) => Convert.ToSingle(span.Max(item => Math.Max(item.minWn, item.maxWn)));
    }
}
