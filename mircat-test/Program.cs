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
                Console.WriteLine(string.Format("MIRcatSDK_GetAPIVersion( {0}, {1}, {2} )", uMajor, uMinor, uPatch));

                Console.WriteLine("MIRcatSDK_Initialize");
                TryCmd(MIRcatSDK.MIRcatSDK_Initialize());

                bool bConnected = false;
                TryCmd(MIRcatSDK.MIRcatSDK_IsConnectedToLaser(ref bConnected));
                Console.WriteLine(string.Format(
                    "MIRcatSDK_IsConnectedToLaser( {0} )",
                    bConnected));

                var laserInfo = new LaserInfo();
                laserInfo.QueryLaserStages();

                var initialWavenum = laserInfo.QclChips.Values.First().CenterWn;

                // arm laser
                laserInfo.EnsureArmed(initialWavenum, true, CancellationToken.None);

                // TO DO:  set up sweep test.

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
