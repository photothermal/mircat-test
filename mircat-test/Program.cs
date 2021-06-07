using MIRcat_Control;
using System;
using System.Linq;
using System.Threading;

namespace PSC.MIRcatTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool bCreated = false;
                TryCmd(MIRcatSDK.MIRcatSDK_IsMIRcatObjectCreated(ref bCreated));
                Console.WriteLine("MIRcatSDK_IsMIRcatObjectCreated( {0} )", bCreated);

                if (!bCreated)
                {
                    Console.WriteLine("MIRcatSDK_CreateMIRcatObject()");
                    TryCmd(MIRcatSDK.MIRcatSDK_CreateMIRcatObject());
                }

                ushort uMajor = 0;
                ushort uMinor = 0;
                ushort uPatch = 0;
                TryCmd(MIRcatSDK.MIRcatSDK_GetAPIVersion(ref uMajor, ref uMinor, ref uPatch));
                Console.WriteLine("MIRcatSDK_GetAPIVersion( {0}, {1}, {2} )", uMajor, uMinor, uPatch);

                Console.WriteLine("MIRcatSDK_Initialize()");
                TryCmd(MIRcatSDK.MIRcatSDK_Initialize());

                bool bConnected = false;
                TryCmd(MIRcatSDK.MIRcatSDK_IsConnectedToLaser(ref bConnected));
                Console.WriteLine( "MIRcatSDK_IsConnectedToLaser( {0} )", bConnected);

                var laser = new LaserSupport();

                laser.FetchParameterLimits();
                laser.QueryLaserStages();


                var initialWavenum = laser.QclChips.Values.First().CenterWn;

                // start laser
                laser.StartLaser(initialWavenum, CancellationToken.None);

                laser.SetPulseWidth(100);

                laser.GetEmitMode();
                laser.GetEmitMode();
                laser.GetEmitMode();
                laser.GetEmitMode();

                laser.SetPulseWidth(500);

                laser.GetEmitMode();

                laser.SetPulseRate(100);

                laser.TryErrorCheck(false, true);

                laser.GetEmitMode();
                laser.GetEmitMode();

                laser.SetPulseRate(100);

                laser.GetEmitMode();

                laser.SetPulseRate(100);

                laser.GetEmitMode();

                laser.SetPulseWidth(500);

                laser.TryErrorCheck(false, true);                

                bool bIsOn = false;
                TryCmd(MIRcatSDK.MIRcatSDK_IsEmissionOn(ref bIsOn));
                Console.WriteLine("MIRcatSDK_IsEmissionOn( {0} )", string.Join(", ", new object[] { bIsOn }));

                TryCmd(MIRcatSDK.MIRcatSDK_IsEmissionOn(ref bIsOn));
                Console.WriteLine("MIRcatSDK_IsEmissionOn( {0} )", string.Join(", ", new object[] { bIsOn }));

                laser.GetEmitMode();

                laser.SetPulseRate(100);

                laser.GetEmitMode();

                laser.SetPulseWidth(500);

                laser.GetEmitMode();
                laser.GetEmitMode();
                laser.GetEmitMode();
                laser.GetEmitMode();

                laser.SetPulseRate(100);

                laser.GetEmitMode();

                laser.SetPulseWidth(500);

                laser.TryErrorCheck(false, true);

                laser.GetEmitMode();

                laser.SetWavelength(initialWavenum);

                // get the currently defined sweep rate
                Units units = Units.MIRcatSDK_UNITS_CM1;
                float fStart = 0;
                float fStop = 0;
                float fSpeed = 0;
                ushort uRepeat = 0;
                bool bidir = false;
                TryCmd(MIRcatSDK.MIRcatSDK_GetAdvancedSweepParams(ref units, ref fStart, ref fStop, ref fSpeed, ref uRepeat, ref bidir));
                Console.WriteLine("MIRcatSDK_GetAdvancedSweepParams( {0} )", string.Join(", ", new object[] { units, fStart, fStop, fSpeed, uRepeat, bidir }));

                // make sure we are in cm-1/s
                fSpeed = LaserSupport.ConvertWW(fSpeed, units, Units.MIRcatSDK_UNITS_CM1);
                Console.WriteLine("    ** Laser currently set to {0:0.#} cm-1/s **", fSpeed);

                // we will choose the furthest from either 500 or 1000 cm-1/s as our target speed:
                var targetRate = (new float[] { 500, 1000 }).OrderBy(f => Math.Abs(f - fSpeed)).Last();
                Console.WriteLine("    ** We will test setting the sweep speed to {0:0.#} cm-1/s **", targetRate);

                var sweepParams = laser.BuildSweep().ToArray();

                // Get the parameters we don't want to change
                PulseTriggerMode u8PulseMode = 0;
                ProcessTriggerMode u8ProcTrigMode = 0;
                Units u8Ignored = 0;
                float fIgnored1 = 0, fIgnored2 = 0, fIgnored3 = 0;
                uint uDwellTime = 0, uAfterOffTime = 0;
                Units u8Units = Units.MIRcatSDK_UNITS_CM1;

                TryCmd(MIRcatSDK.MIRcatSDK_GetWlTrigParams(
                    ref u8PulseMode,
                    ref u8ProcTrigMode,
                    ref fIgnored1,          // < Ignore these paramters
                    ref fIgnored2,          // < Ignore these paramters
                    ref fIgnored3,          // < Ignore these paramters
                    ref u8Ignored,          // < Ignore these paramters
                    ref uDwellTime,
                    ref uAfterOffTime));
                Console.WriteLine(
                    "MIRcatSDK_GetWlTrigParams( {0} )", string.Join(", ", new object[] {
                    u8PulseMode,
                    u8ProcTrigMode,
                    fIgnored1,
                    fIgnored2,
                    fIgnored3,
                    u8Ignored,
                    uDwellTime,
                    uAfterOffTime }));


                // Note: New behavior as of 4/6/2017
                //       'stageReadyCallback' may be null.  
                //       If 'stageReadyCallback' is null, we are specifying an immediately executed sweep using internal process triggers.
                //       If 'stageReadyCallback' is provided, we will use manual process triggers, and inject a process trigger for each
                //       successful invocation of 'stageReadyCallback'.

                //if (null == stageReadyCallback)
                //{
                //    u8ProcTrigMode = ProcessTriggerMode.MIRcatSDK_PROC_TRIG_MODE_INTERNAL;  // Fastest full-range sweep possible.
                //}
                //else
                {
                    u8ProcTrigMode = ProcessTriggerMode.MIRcatSDK_PROC_TRIG_MODE_MANUAL;   // set the MIRcat to use the manual process triggers
                }


                // Now change the parameters
                Console.WriteLine(
                    "MIRcatSDK_SetWlTrigParams( {0} )", string.Join(", ", new object[] {
                    u8PulseMode,
                    u8ProcTrigMode,
                    sweepParams.MinWn(),
                    sweepParams.MaxWn(),
                    0.5f,
                    u8Units,
                    uDwellTime,
                    uAfterOffTime }));

                TryCmd(MIRcatSDK.MIRcatSDK_SetWlTrigParams(
                    u8PulseMode,
                    u8ProcTrigMode,
                    sweepParams.MinWn(),
                    sweepParams.MaxWn(),
                    0.5f,
                    u8Units,
                    uDwellTime,
                    uAfterOffTime));

                TryCmd(MIRcatSDK.MIRcatSDK_SetAdvancedSweepParams(Units.MIRcatSDK_UNITS_CM1, sweepParams.MinWn(), sweepParams.MaxWn(), targetRate, 1, false));
                Console.WriteLine("MIRcatSDK_SetAdvancedSweepParams( {0} )", string.Join(", ",
                    new object[] { Units.MIRcatSDK_UNITS_CM1, sweepParams.MinWn(), sweepParams.MaxWn(), targetRate, 1, false }));

                foreach (var obj in sweepParams)
                {
                    TryCmd(MIRcatSDK.MIRcatSDK_SetAdvancedSweepChanParams(Convert.ToByte(obj.ChipNum), Convert.ToSingle(obj.minWn), Convert.ToSingle(obj.maxWn), true));
                    Console.WriteLine("MIRcatSDK_SetAdvancedSweepChanParams( {0} )", string.Join(", ",
                        new object[] { Convert.ToByte(obj.ChipNum), Convert.ToSingle(obj.minWn), Convert.ToSingle(obj.maxWn), true }));
                }

                TryCmd(MIRcatSDK.MIRcatSDK_ReadWriteAdvancedSweepParams(true));
                Console.WriteLine(string.Format("MIRcatSDK_ReadWriteAdvancedSweepParams( {0} )", true));


                // now read back the advanced sweep parameters from the laser
                TryCmd(MIRcatSDK.MIRcatSDK_GetAdvancedSweepParams(ref units, ref fStart, ref fStop, ref fSpeed, ref uRepeat, ref bidir));
                Console.WriteLine("MIRcatSDK_GetAdvancedSweepParams( {0} )", string.Join(", ", new object[] { units, fStart, fStop, fSpeed, uRepeat, bidir }));

                if (string.Equals(fSpeed.ToString("0.#"), targetRate.ToString("0.#")))
                {
                    Console.WriteLine("   ** The laser successfully accepted the new sweep speed parameter. **");
                }
                else
                {
                    Console.WriteLine("   ** FAILURE -- the laser did not accept the new sweep speed parameter. **");
                }

                bool bIsTuned = false;
                TryCmd(MIRcatSDK.MIRcatSDK_IsTuned(ref bIsTuned));
                Console.WriteLine("MIRcatSDK_IsTuned( {0} )", bIsTuned);

                if (bIsTuned)
                {
                    TryCmd(MIRcatSDK.MIRcatSDK_CancelManualTuneMode());
                    Console.WriteLine("MIRcatSDK_CancelManualTuneMode()");
                }

                Console.WriteLine("MIRcatSDK_StartSweepAdvancedScan()");
                TryCmd(MIRcatSDK.MIRcatSDK_StartSweepAdvancedScan());


                while (true)
                {
                    bool bSysError = false;
                    TryCmd(MIRcatSDK.MIRcatSDK_IsSystemError(ref bSysError));
                    Console.WriteLine("MIRcatSDK_IsSystemError( {0} )", bSysError);

                    bool bScanInProgress = false;
                    bool bScanIsActive = false;
                    bool bScanIsPaused = false;
                    ushort uCurScanNum = 0;
                    ushort uCurScanPercent = 0;
                    float fCurWavenumber = 0;
                    bool bTecInProg = false;
                    bool bMotionInProg = false;
                    MIRcatSDK.MIRcatSDK_GetScanStatus(
                        ref bScanInProgress,
                        ref bScanIsActive,
                        ref bScanIsPaused,
                        ref uCurScanNum,
                        ref uCurScanPercent,
                        ref fCurWavenumber,
                        ref units,
                        ref bTecInProg,
                        ref bMotionInProg);
                    Console.WriteLine("MIRcatSDK_GetScanStatus( {0} )", string.Join(", ", new object[] {
                            bScanInProgress,
                            bScanIsActive,
                            bScanIsPaused,
                            uCurScanNum,
                            uCurScanPercent,
                            fCurWavenumber,
                            units,
                            bTecInProg,
                            bMotionInProg
                        }));

                    if (!bScanInProgress)
                    {
                        Console.WriteLine("  ** scan has stopped **");
                        break;
                    }
                    //if (!bScanIsActive)
                    //{
                    //    Console.WriteLine("  ** no scan is active **");
                    //    break;
                    //}
                    if (uCurScanNum > 1)
                    {
                        Console.WriteLine("  ** Scan complete **");
                        break;
                    }

                    bool bWaiting = false;
                    TryCmd(MIRcatSDK.MIRcatSDK_GetScanWaitingProcessTrigger(ref bWaiting));
                    Console.WriteLine("MIRcatSDK_GetScanWaitingProcessTrigger( {0} )", bWaiting);

                    if (bWaiting)
                    {
                        Console.WriteLine("MIRcatSDK_InjectProcessTrigger()");
                        TryCmd(MIRcatSDK.MIRcatSDK_InjectProcessTrigger());
                    }

                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }

                Console.WriteLine("MIRcatSDK_StopScanInProgress()");
                var r = MIRcatSDK.MIRcatSDK_StopScanInProgress();
                Console.WriteLine("   Result = " + r);




                Console.WriteLine("MIRcatSDK_DisarmLaser()");
                TryCmd(MIRcatSDK.MIRcatSDK_DisarmLaser());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to close...");
                Console.ReadKey();
            }
        }

        static void TryCmd(SDKConstant result)
        {
            if (MIRcatSDK.MIRcatSDK_Failed(result))
            {
                throw new Exception(MIRcatSDK.MIRcatSDK_GetErrorDesc(result));
            }
        }

    }
}
