using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MIRcat_Control;

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
                    Console.WriteLine("MIRcatSDK_CreateMIRcatObject");
                    TryCmd(MIRcatSDK.MIRcatSDK_CreateMIRcatObject());
                }

                ushort uMajor = 0;
                ushort uMinor = 0;
                ushort uPatch = 0;
                TryCmd(MIRcatSDK.MIRcatSDK_GetAPIVersion(ref uMajor, ref uMinor, ref uPatch));
                Console.WriteLine("MIRcatSDK_GetAPIVersion( {0}, {1}, {2} )", uMajor, uMinor, uPatch);

                Console.WriteLine("MIRcatSDK_Initialize");
                TryCmd(MIRcatSDK.MIRcatSDK_Initialize());

                bool bConnected = false;
                TryCmd(MIRcatSDK.MIRcatSDK_IsConnectedToLaser(ref bConnected));
                Console.WriteLine( "MIRcatSDK_IsConnectedToLaser( {0} )", bConnected);

                var laser = new LaserSupport();
                laser.QueryLaserStages();

                var initialWavenum = laser.QclChips.Values.First().CenterWn;

                // start laser
                laser.StartLaser(initialWavenum, CancellationToken.None);

                bool bIsOn = false;
                TryCmd(MIRcatSDK.MIRcatSDK_IsEmissionOn(ref bIsOn));
                Console.WriteLine("MIRcatSDK_IsEmissionOn( {0} )", string.Join(", ", new object[] { bIsOn }));

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

                // MIRcatSDK_StartSweepAdvancedScan()
                // MIRcatSDK_IsSystemError(False )




                Console.WriteLine("MIRcatSDK_DisarmLaser");
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
