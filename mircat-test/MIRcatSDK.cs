using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace MIRcat_Control
{
    public enum SDKConstant : uint
    {
        MIRcatSDK_RET_SUCCESS                               = 0,

        /* Comm and Transport Errors */
        MIRcatSDK_RET_UNSUPPORTED_TRANSPORT                 = 1,

        /* Initialization Errors */
        MIRcatSDK_RET_INITIALIZATION_FAILURE                = 32,

        /* Function return error codes */
        MIRcatSDK_RET_ARMDISARM_FAILURE                     = 64,
        MIRcatSDK_RET_STARTTUNE_FAILURE                     = 65,
        MIRcatSDK_RET_INTERLOCKS_KEYSWITCH_NOTSET           = 66,
        MIRcatSDK_RET_STOP_SCAN_FAILURE                     = 67,
        MIRcatSDK_RET_PAUSE_SCAN_FAILURE                    = 68,
        MIRcatSDK_RET_RESUME_SCAN_FAILURE                   = 69,
        MIRcatSDK_RET_MANUAL_STEP_SCAN_FAILURE              = 70,
        MIRcatSDK_RET_START_SWEEPSCAN_FAILURE               = 71,
        MIRcatSDK_RET_START_STEPMEASURESCAN_FAILURE         = 72,
        MIRcatSDK_RET_INDEX_OUTOFBOUNDS                     = 73,
        MIRcatSDK_RET_START_MULTISPECTRALSCAN_FAILURE       = 74,
        MIRcatSDK_RET_TOO_MANY_ELEMENTS                     = 75,
        MIRcatSDK_RET_NOT_ENOUGH_ELEMENTS                   = 76,
        MIRcatSDK_RET_BUFFER_TOO_SMALL                      = 77,
        MIRcatSDK_RET_FAVORITE_NAME_NOTRECOGNIZED           = 78,
        MIRcatSDK_RET_FAVORITE_RECALL_FAILURE               = 79,
        MIRcatSDK_RET_WW_OUTOFTUNINGRANGE                   = 80,
        MIRcatSDK_RET_NO_SCAN_INPROGRESS                    = 81,
        MIRcatSDK_RET_EMISSION_ON_FAILURE                   = 82,
        MIRcatSDK_RET_EMISSION_ALREADY_OFF                  = 83,
        MIRcatSDK_RET_EMISSION_OFF_FAILURE                  = 84,
        MIRcatSDK_RET_EMISSION_ALREADY_ON                   = 85,
        MIRcatSDK_RET_PULSERATE_OUTOFRANGE                  = 86,
        MIRcatSDK_RET_PULSEWIDTH_OUTOFRANGE                 = 87,
        MIRcatSDK_RET_CURRENT_OUTOFRANGE                    = 88,
        MIRcatSDK_RET_SAVE_SETTINGS_FAILURE                 = 89,
        MIRcatSDK_RET_QCL_NUM_OUTOFRANGE                    = 90,
        MIRcatSDK_RET_LASER_ALREADY_ARMED                   = 91,
        MIRcatSDK_RET_LASER_ALREADY_DISARMED                = 92,
        MIRcatSDK_RET_LASER_NOT_ARMED                       = 93,
        MIRcatSDK_RET_LASER_NOT_TUNED                       = 94,
        MIRcatSDK_RET_TECS_NOT_AT_SET_TEMPERATURE           = 95,
        MIRcatSDK_RET_CW_NOT_ALLOWED_ON_QCL					= 96,
        MIRcatSDK_RET_INVALID_LASER_MODE					= 97,
        MIRcatSDK_RET_TEMPERATURE_OUT_OF_RANGE				= 98,
        MIRcatSDK_RET_LASER_POWER_OFF_ERROR				    = 99,
        MIRcatSDK_RET_COMM_ERROR							= 100,
        MIRcatSDK_RET_NOT_INITIALIZED						= 101,
        MIRcatSDK_RET_ALREADY_CREATED						= 102,
        MIRcatSDK_RET_START_SWEEP_ADVANCED_SCAN_FAILURE		= 103,
        MIRcatSDK_RET_INJECT_PROC_TRIG_ERROR				= 104,
        MIRcatSDK_RET_PASSED_NULL_POINTER					= 105,
        MIRcatSDK_RET_TABLE_NUM_OUT_OF_RANGE				= 106,
        MIRcatSDK_RET_STRCPY_ERROR							= 107,
        MIRcatSDK_RET_TOO_MANY_CAL_ENTRIES					= 108,
        MIRcatSDK_RET_CANNOT_DELETE_FACTORY_CAL				= 109,
        MIRcatSDK_RET_CANNOT_OVERWRITE_FACTORY_CAL			= 110,
        MIRcatSDK_RET_ADMIN_PASSWORD_INCORRECT				= 111,
        MIRcatSDK_RET_NO_DEVICE_AT_HANDLE					= 112,
        MIRcatSDK_RET_CONNECT_FAIL_AT_HANDLE				= 113,
        MIRcatSDK_RET_NO_CONTROLLER_AT_HANDLE				= 114,
        MIRcatSDK_RET_DISCONNECT_ERROR						= 115,
    }

    public enum MIRcatConstant : ushort
    {
        APP_CMDIF_STATUS_SUCCESS                    = 0,
        APP_CMDIF_STATUS_FAIL                       = 1,
        APP_CMDIF_STATUS_NO_QCL_AT_THIS_SLOT        = 2,
        APP_CMDIF_STATUS_CMD_DISPOSITION_FAIL       = 10,
        APP_CMDIF_STATUS_CMD_ID_FAIL                = 11,
        APP_CMDIF_STATUS_CMD_LEN_FAIL               = 12,
        APP_CMDIF_STATUS_CMD_INVALID_CHAN           = 13,
        APP_CMDIF_STATUS_TEC_ERROR1                 = 20,
        APP_CMDIF_STATUS_TEC_ERROR2                 = 21,
        APP_CMDIF_STATUS_TEC_ERROR3                 = 22,
        APP_CMDIF_STATUS_TEC_ERROR4                 = 23,
        APP_CMDIF_STATUS_BTEMP_HIGH                 = 24,
        APP_CMDIF_STATUS_BTEMP_LOW                  = 25,
        APP_CMDIF_STATUS_TEC_RWAY1                  = 26,
        APP_CMDIF_STATUS_TEC_RWAY2                  = 27,
        APP_CMDIF_STATUS_TEC_RWAY3                  = 28,
        APP_CMDIF_STATUS_TEC_RWAY4                  = 29,
        APP_CMDIF_STATUS_MOTION_FAULT1              = 30,
        APP_CMDIF_STATUS_MOTION_FAULT2              = 31,
        APP_CMDIF_STATUS_MOTION_FAULT3              = 32,
        APP_CMDIF_STATUS_MOTION_FAULT4              = 33,
        APP_CMDIF_STATUS_MOTION_STALL1              = 35,
        APP_CMDIF_STATUS_MOTION_STALL2              = 36,
        APP_CMDIF_STATUS_MOTION_STALL3              = 37,
        APP_CMDIF_STATUS_MOTION_STALL4              = 38,
        APP_CMDIF_STATUS_MOTION_UNINIT_CHAN1        = 40,
        APP_CMDIF_STATUS_MOTION_UNINIT_CHAN2        = 41,
        APP_CMDIF_STATUS_MOTION_UNINIT_CHAN3        = 42,
        APP_CMDIF_STATUS_MOTION_UNINIT_CHAN4        = 43,
        APP_CMDIF_STATUS_MOTION_ERROR_CHAN1         = 45,
        APP_CMDIF_STATUS_MOTION_ERROR_CHAN2         = 46,
        APP_CMDIF_STATUS_MOTION_ERROR_CHAN3         = 47,
        APP_CMDIF_STATUS_MOTION_ERROR_CHAN4         = 48,
        APP_CMDIF_STATUS_EEPROM_CRC_MISMATCH1       = 50,
        APP_CMDIF_STATUS_EEPROM_CRC_MISMATCH2       = 51,
        APP_CMDIF_STATUS_EEPROM_CRC_MISMATCH3       = 52,
        APP_CMDIF_STATUS_EEPROM_CRC_MISMATCH4       = 53,
        APP_CMDIF_STATUS_CANNOT_GEN_DEFAULT_FAV     = 55,
        APP_CMDIF_STATUS_MOTION_HOME_FAULT_CHAN1    = 60,
        APP_CMDIF_STATUS_MOTION_HOME_FAULT_CHAN2    = 61,
        APP_CMDIF_STATUS_MOTION_HOME_FAULT_CHAN3    = 62,
        APP_CMDIF_STATUS_MOTION_HOME_FAULT_CHAN4    = 63,
        APP_CMDIF_STATUS_CASE_TEMP1_FAULT           = 65,
        APP_CMDIF_STATUS_CASE_TEMP2_FAULT           = 66,
        APP_CMDIF_STATUS_CASE_TEMPS_BAD             = 67,
        APP_CMDIF_STATUS_MOTOR_OVERCURRENT          = 68,
    }
    
    /* Communication Parameters */
    public enum CommParams : byte
    {
        MIRcatSDK_COMM_SERIAL                   = 1,
        MIRcatSDK_COMM_UDP                      = 2,
        MIRcatSDK_COMM_DEFAULT                  = MIRcatSDK_COMM_SERIAL
    }
    
    /* Serial port parameters */
    /* Automatically find the device on the port */
    public enum SerialParams : uint
    {
        MIRcatSDK_SERIAL_PORT_AUTO              = 0,
        MIRcatSDK_SERIAL_BAUD_USE_DEFAULT       = 0,
        MIRcatSDK_SERIAL_BAUD1					= 115200,
        MIRcatSDK_SERIAL_BAUD2					= 921600,
    }

    /* Units */
    /* Wave length Wave Number units */
    public enum Units : byte
    {
        MIRcatSDK_UNITS_MICRONS                 = 1,
        MIRcatSDK_UNITS_CM1                     = 2,
    }

    /* Laser Modes */
    public enum LaserMode : byte
    {
        MIRcatSDK_MODE_ERROR					= 0,
        MIRcatSDK_MODE_PULSED					= 1,
        MIRcatSDK_MODE_CW						= 2,
        MIRcatSDK_MODE_CW_MOD					= 3,
        MIRcatSDK_MODE_CW_MR					= 6,	//currently not supported in firmware
        MIRcatSDK_MODE_CW_MR_MOD				= 7,	//currently not supported in firmware
        MIRcatSDK_MODE_CW_FLTR1					= 8,
        MIRcatSDK_MODE_CW_FLTR2					= 9,
        MIRcatSDK_MODE_CW_FLTR1_MOD				= 10,
    }

    /* Pulse Triggering Modes */
    public enum PulseTriggerMode : byte
    {
        MIRcatSDK_PULSE_MODE_INTERNAL			= 1,
        MIRcatSDK_PULSE_MODE_EXTERNAL_TRIGGER	= 2,
        MIRcatSDK_PULSE_MODE_EXTERNAL_PASSTHRU	= 3,
        MIRcatSDK_PULSE_MODE_WAVELENGTH_TRIGGER = 4,
    }

    /* Process Triggering Modes */
    public enum ProcessTriggerMode : byte
    {
        MIRcatSDK_PROC_TRIG_MODE_INTERNAL		= 1,
        MIRcatSDK_PROC_TRIG_MODE_EXTERNAL		= 2,
        MIRcatSDK_PROC_TRIG_MODE_MANUAL			= 3,
    }

    /* Pointing Constants */
    public enum Pointing : UInt16
    {
        MIRCATSDK_POINTING_MAX_TABLES_PER_CHANNEL = 8,
        MIRCATSDK_POINTING_TABLE_NAME_LEN_MAX     = 32,
        MIRCATSDK_MAX_CAL_ENTRIES_PER_TABLE       = 1024,
    }

    sealed class MIRcatSDK
    {
        public static bool MIRcatSDK_Failed(SDKConstant retCode)
        {
            return SDKConstant.MIRcatSDK_RET_SUCCESS != retCode;
        }
        public static bool MIRcatSDK_Failed(MIRcatConstant errCode)
        {
            return MIRcatConstant.APP_CMDIF_STATUS_SUCCESS != errCode;
        }
        public static string MIRcatSDK_GetErrorDesc(SDKConstant retCode)
        {
            switch (retCode)
            {
                case SDKConstant.MIRcatSDK_RET_SUCCESS: return string.Format("{0}: Function executed successfully.", retCode);
                case SDKConstant.MIRcatSDK_RET_UNSUPPORTED_TRANSPORT: return string.Format("{0}: Transport requested by the application is not supported by this version of SDK.", retCode);
                case SDKConstant.MIRcatSDK_RET_INITIALIZATION_FAILURE: return string.Format("{0}: Initialization of SDK failed.", retCode);
                case SDKConstant.MIRcatSDK_RET_ARMDISARM_FAILURE: return string.Format("{0}: Could not arm or disarm the laser.", retCode);
                case SDKConstant.MIRcatSDK_RET_STARTTUNE_FAILURE: return string.Format("{0}: Start Single tune operation failed.", retCode);
                case SDKConstant.MIRcatSDK_RET_INTERLOCKS_KEYSWITCH_NOTSET: return string.Format("{0}: Interlocks and/or key switch are not set. This is required before the laser is armed.", retCode);
                case SDKConstant.MIRcatSDK_RET_STOP_SCAN_FAILURE: return string.Format("{0}: Stop scan operation failed.", retCode);
                case SDKConstant.MIRcatSDK_RET_PAUSE_SCAN_FAILURE: return string.Format("{0}: Pause scan operation failed.", retCode);
                case SDKConstant.MIRcatSDK_RET_RESUME_SCAN_FAILURE: return string.Format("{0}: Resume scan operation failed.", retCode);
                case SDKConstant.MIRcatSDK_RET_MANUAL_STEP_SCAN_FAILURE: return string.Format("{0}: Manual step in scan failed.", retCode);
                case SDKConstant.MIRcatSDK_RET_START_SWEEPSCAN_FAILURE: return string.Format("{0}: Starting sweep scan failed.", retCode);
                case SDKConstant.MIRcatSDK_RET_START_STEPMEASURESCAN_FAILURE: return string.Format("{0}: Starting step measure scan failed.", retCode);
                case SDKConstant.MIRcatSDK_RET_INDEX_OUTOFBOUNDS: return string.Format("{0}: Index provided to parameter to a function is out of bounds.", retCode);
                case SDKConstant.MIRcatSDK_RET_START_MULTISPECTRALSCAN_FAILURE: return string.Format("{0}: Starting multi spectral scan failed.", retCode);
                case SDKConstant.MIRcatSDK_RET_TOO_MANY_ELEMENTS: return string.Format("{0}: Number of elements being added are too many.", retCode);
                case SDKConstant.MIRcatSDK_RET_NOT_ENOUGH_ELEMENTS: return string.Format("{0}: Number of elements added are less than specified number.", retCode);
                case SDKConstant.MIRcatSDK_RET_BUFFER_TOO_SMALL: return string.Format("{0}: Return buffer is too small.", retCode);
                case SDKConstant.MIRcatSDK_RET_FAVORITE_NAME_NOTRECOGNIZED: return string.Format("{0}: Favorite name passed is not recognized as a valid name.", retCode);
                case SDKConstant.MIRcatSDK_RET_FAVORITE_RECALL_FAILURE: return string.Format("{0}: Unable to recall favorite setting.", retCode);
                case SDKConstant.MIRcatSDK_RET_WW_OUTOFTUNINGRANGE: return string.Format("{0}: Wavelength or wave number provided is out of tuning range.", retCode);
                case SDKConstant.MIRcatSDK_RET_NO_SCAN_INPROGRESS: return string.Format("{0}: No scan is currently in progress.", retCode);
                case SDKConstant.MIRcatSDK_RET_EMISSION_ON_FAILURE: return string.Format("{0}: Could not turn emission on.", retCode);
                case SDKConstant.MIRcatSDK_RET_EMISSION_ALREADY_OFF: return string.Format("{0}: Emission is already off.", retCode);
                case SDKConstant.MIRcatSDK_RET_EMISSION_OFF_FAILURE: return string.Format("{0}: Could not turn emission off.", retCode);
                case SDKConstant.MIRcatSDK_RET_EMISSION_ALREADY_ON: return string.Format("{0}: Emission is already on.", retCode);
                case SDKConstant.MIRcatSDK_RET_PULSERATE_OUTOFRANGE: return string.Format("{0}: Pulse Rate out of range.", retCode);
                case SDKConstant.MIRcatSDK_RET_PULSEWIDTH_OUTOFRANGE: return string.Format("{0}: Pulse Width out of range.", retCode);
                case SDKConstant.MIRcatSDK_RET_CURRENT_OUTOFRANGE: return string.Format("{0}: Current out of range.", retCode);
                case SDKConstant.MIRcatSDK_RET_SAVE_SETTINGS_FAILURE: return string.Format("{0}: Save settings failure.", retCode);
                case SDKConstant.MIRcatSDK_RET_QCL_NUM_OUTOFRANGE: return string.Format("{0}: QCL number out of range.", retCode);
                case SDKConstant.MIRcatSDK_RET_LASER_ALREADY_ARMED: return string.Format("{0}: Laser already armed.", retCode);
                case SDKConstant.MIRcatSDK_RET_LASER_ALREADY_DISARMED: return string.Format("{0}: Laser already disarmed.", retCode);
                case SDKConstant.MIRcatSDK_RET_LASER_NOT_ARMED: return string.Format("{0}: Laser not armed.", retCode);
                case SDKConstant.MIRcatSDK_RET_LASER_NOT_TUNED: return string.Format("{0}: Laser not tuned.", retCode);
                case SDKConstant.MIRcatSDK_RET_TECS_NOT_AT_SET_TEMPERATURE: return string.Format("{0}: TECs are not at set temperature.", retCode);
                case SDKConstant.MIRcatSDK_RET_CW_NOT_ALLOWED_ON_QCL: return string.Format("{0}: QCL does not support CW mode.", retCode);
                case SDKConstant.MIRcatSDK_RET_INVALID_LASER_MODE: return string.Format("{0}: Invalid laser mode.", retCode);
                case SDKConstant.MIRcatSDK_RET_TEMPERATURE_OUT_OF_RANGE: return string.Format("{0}: Temperature out of range.", retCode);
                case SDKConstant.MIRcatSDK_RET_LASER_POWER_OFF_ERROR: return string.Format("{0}: Could not turn off power to laser.", retCode);
                case SDKConstant.MIRcatSDK_RET_COMM_ERROR: return string.Format("{0}: Communication error.", retCode);
                case SDKConstant.MIRcatSDK_RET_NOT_INITIALIZED: return string.Format("{0}: MIRcat communications not initialized.", retCode);
                case SDKConstant.MIRcatSDK_RET_ALREADY_CREATED: return string.Format("{0}: MIRcat communications already initialized.", retCode);
                case SDKConstant.MIRcatSDK_RET_START_SWEEP_ADVANCED_SCAN_FAILURE: return string.Format("{0}: MIRcat start 'advanced' sweep failure.", retCode);
                case SDKConstant.MIRcatSDK_RET_INJECT_PROC_TRIG_ERROR: return string.Format("{0}: MIRcat process trigger injection error.", retCode);
            }

            return string.Format("{0}: Unknown SDK return error code.", retCode);
        }
        public static string MIRcatSDK_GetErrorDesc(MIRcatConstant errCode)
        {
            switch (errCode)
            {
                case MIRcatConstant.APP_CMDIF_STATUS_SUCCESS: return string.Format("{0}: Operation completed successfully.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_FAIL: return string.Format("{0}: Operation failed.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_NO_QCL_AT_THIS_SLOT: return string.Format("{0}: No QCL at this slot.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_CMD_DISPOSITION_FAIL: return string.Format("{0}: Command disposition failure.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_CMD_ID_FAIL: return string.Format("{0}: Command ID failure.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_CMD_LEN_FAIL: return string.Format("{0}: Command length failure.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_CMD_INVALID_CHAN: return string.Format("{0}: Command invalid chnanel.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_TEC_ERROR1: return string.Format("{0}: TEC Error 1.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_TEC_ERROR2: return string.Format("{0}: TEC Error 2.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_TEC_ERROR3: return string.Format("{0}: TEC Error 3.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_TEC_ERROR4: return string.Format("{0}: TEC Error 4.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_BTEMP_HIGH: return string.Format("{0}: Bench temp too high.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_BTEMP_LOW: return string.Format("{0}: Bench temp too low.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_TEC_RWAY1: return string.Format("{0}: TEC runaway error 1.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_TEC_RWAY2: return string.Format("{0}: TEC runaway error 2.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_TEC_RWAY3: return string.Format("{0}: TEC runaway error 3.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_TEC_RWAY4: return string.Format("{0}: TEC runaway error 4.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_MOTION_FAULT1: return string.Format("{0}: Motion fault 1.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_MOTION_FAULT2: return string.Format("{0}: Motion fault 2.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_MOTION_FAULT3: return string.Format("{0}: Motion fault 3.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_MOTION_FAULT4: return string.Format("{0}: Motion fault 4.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_MOTION_STALL1: return string.Format("{0}: Motion stall 1.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_MOTION_STALL2: return string.Format("{0}: Motion stall 2.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_MOTION_STALL3: return string.Format("{0}: Motion stall 3.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_MOTION_STALL4: return string.Format("{0}: Motion stall 4.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_MOTION_UNINIT_CHAN1: return string.Format("{0}: Motion uninit channel 1.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_MOTION_UNINIT_CHAN2: return string.Format("{0}: Motion uninit channel 2.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_MOTION_UNINIT_CHAN3: return string.Format("{0}: Motion uninit channel 3.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_MOTION_UNINIT_CHAN4: return string.Format("{0}: Motion uninit channel 4.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_MOTION_ERROR_CHAN1: return string.Format("{0}: Motion error channel 1.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_MOTION_ERROR_CHAN2: return string.Format("{0}: Motion error channel 2.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_MOTION_ERROR_CHAN3: return string.Format("{0}: Motion error channel 3.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_MOTION_ERROR_CHAN4: return string.Format("{0}: Motion error channel 4.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_EEPROM_CRC_MISMATCH1: return string.Format("{0}: EEPROM CRC Mismatch 1.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_EEPROM_CRC_MISMATCH2: return string.Format("{0}: EEPROM CRC Mismatch 2.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_EEPROM_CRC_MISMATCH3: return string.Format("{0}: EEPROM CRC Mismatch 3.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_EEPROM_CRC_MISMATCH4: return string.Format("{0}: EEPROM CRC Mismatch 4.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_CANNOT_GEN_DEFAULT_FAV: return string.Format("{0}: Cannot gen. default Fav.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_MOTION_HOME_FAULT_CHAN1: return string.Format("{0}: Motion home fault channel 1.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_MOTION_HOME_FAULT_CHAN2: return string.Format("{0}: Motion home fault channel 2.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_MOTION_HOME_FAULT_CHAN3: return string.Format("{0}: Motion home fault channel 3.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_MOTION_HOME_FAULT_CHAN4: return string.Format("{0}: Motion home fault channel 4.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_CASE_TEMP1_FAULT: return string.Format("{0}: Case temperature 1 fault.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_CASE_TEMP2_FAULT: return string.Format("{0}: Case temperature 2 fault.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_CASE_TEMPS_BAD: return string.Format("{0}: Case temperatures bad.", errCode);
                case MIRcatConstant.APP_CMDIF_STATUS_MOTOR_OVERCURRENT: return string.Format("{0}: Motor overcurrent error.", errCode);
            }

            return string.Format("{0}: Unknown MIRcat error code.", errCode);
        }

        /** 
	    <summary>Get Version of the API.</summary>
	    <param name="papiVersionMajor">Major Version of MIRcat API.</param>
	    <param name="papiVersionMinor">Minor Version of MIRcat API.</param>
	    <param name="papiVersionPatch">Patch Version of MIRcat API.</param>
	    <returns>Error code.  Possible codes: MIRcat_SDK_RET_SUCCESS</returns>
	    */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetAPIVersion(
            ref UInt16 papiVersionMajor,
            ref UInt16 papiVersionMinor,
            ref UInt16 papiVersionPatch);

        /** 
	    <summary>Set the communications type.</summary>
	    <see>MIRcatSDK_COMM_SERIAL</see>
	    <see>MIRcatSDK_COMM_UDP</see>
	    <see>MIRcatSDK_COMM_DEFAULT</see>
	    <param name="commType">Communications Interface Type.</param>
	    <returns>Error code.</returns>
	    */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_SetCommType(
            [MarshalAs(UnmanagedType.U1)] CommParams commType);

        /** 
        <summary>Set serial port parameters.</summary>
        <see>MIRcatSDK_SERIAL_PORT_AUTO</see>
        <see>MIRcatSDK_SERIAL_BAUD_USE_DEFAULT</see>
        <param name="port">COM port number.</param>
        <param name="baud">Baud Rate.</param>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_SetSerialParams(
            UInt16 port,
            UInt32 baud);

        /**
        <summary>Creates new MIRcat object.  If a previous call has been made to MIRcatSDK_DeInitialize(),
        this function should be called before trying to call other MIRcatSDK functions.  </summary>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_CreateMIRcatObject();

        /**
        <summary>Returns bool value indicating if MIRcat object has been created.  
        The object is destroyed following a call to MIRcatSDK_DeInitialize().  If it is
        destroyed it must be created before any SDK function calls will be valid.
        A call to MIRcatSDK_Initialize() will also create the object if it has been destroyed.
        </summary>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_IsMIRcatObjectCreated(
            ref bool pbMIRcatObjectCreated);

        /** 
        <summary>Initialize the API.</summary>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_Initialize();


        /**
        <summary>Disconnect and clean up ports/memory associated with initializing the MIRcatSDK.
        A call to this function requires a call to MIRcatSDK_CreateMIRcatObject() or MIRcatSDK_Initialize()
        before any subsequent calls to any SDK functions.</summary>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_DeInitialize();

        /** INFORMATION FUNCTIONS */

        /** 
        <summary>Gets the model number of the MIRcat system.</summary>
        <param name="pszModelNumber">Pointer to character array that will contain model number after calling the function.  This array should be at least 24 bytes.</param>
        <param name="bSize">Size of pszModelNumber in bytes.</param>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetModelNumber(
            [MarshalAs(UnmanagedType.LPStr, SizeParamIndex = 1)] ref string pszModelNumber,
            byte bSize);

        /** 
        <summary>Gets the serial number of the MIRcat system.</summary>
        <param name="pszSerialNumber">Pointer to character array that will contain serial number after calling the function.  This array should be at least 24 bytes.</param>
        <param name="bSize">Size of pszSerialNumber in bytes.</param>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetSerialNumber(
            [MarshalAs(UnmanagedType.LPStr, SizeParamIndex = 1)] ref string pszSerialNumber,
            byte bSize);



        /** 
	    <summary>Gets the tuning range of the MIRcat system.</summary>
	    <param name="pfMinRange">Minimum wavelength of the MIRcat system.</param>
	    <param name="pfMaxRange">Maximum wavelength of the MIRcat system.</param>
	    <param name="pbUnits">Units for the min/max wavelength of the MIRcat system.</param>
	    <see>MIRcatSDK_UNITS_MICRONS</see>
	    <see>MIRcatSDK_UNITS_CM1</see>
	    <returns>Error code.</returns>
	    */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetTuningRange(
            ref float pfMinRange,
            ref float pfMaxRange,
            [MarshalAs(UnmanagedType.U1)] ref Units pbUnits);

        /** 
        <summary>Gets the number of QCLs installed in the MIRcat system.</summary>
        <param name="pbNumQcls">Number of installed QCLs.</param>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetNumInstalledQcls(
            ref byte pbNumQcls);

        /** 
        <summary>Gets the tuning range of a particular QCL the MIRcat system.</summary>
        <param name="bQcl">QCL for which to get the tuning range, indexed 1-4.</param>
        <param name="pfMinRange">Minimum wavelength of the QCL.</param>
        <param name="pfMaxRange">Maximum wavelength of the QCL.</param>
        <param name="pbUnits">Units for the min/max wavelength of the MIRcat system.</param>
        <see>MIRcatSDK_UNITS_MICRONS</see>
        <see>MIRcatSDK_UNITS_CM1</see>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetQclTuningRange(
            byte bQcl,
            ref float pfMinRange,
            ref float pfMaxRange,
            [MarshalAs(UnmanagedType.U1)] ref Units pbUnits);


        /* STATUS APIs */

        /** 
        <summary>Is there a valid connection to the laser?</summary>
        <param name="pbConnected">Bool value that indicates if the API is connected to the MIRcat system.</param>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_IsConnectedToLaser(
            ref bool pbConnected);

        /** 
        <summary>Is the interlock set?</summary>
        <param name="pbSet">Bool value that indicates if the interlock circuit is closed.</param>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_IsInterlockedStatusSet(
            ref bool pbSet);

        /** 
        <summary>Is the key switch in the ON position?</summary>
        <param name="pbSet">Bool value that indicates if the key switch is in the ON position.</param>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_IsKeySwitchStatusSet(
            ref bool pbSet);

        /** 
        <summary>Is the laser emission on?</summary>
        <param name="pbIsOn">Bool value that indicates if the laser is currently emitting light.</param>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_IsEmissionOn(
            ref bool pbIsOn);

        /** 
        <summary>Is the laser armed?</summary>
        <param name="pbIsArmed">Bool value that indicates if the laser is armed.</param>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_IsLaserArmed(
            ref bool pbIsArmed);

        /** 
        <summary>Is there a system error?</summary>
        <param name="pbIsError">Bool value that indicates if there is a system error.</param>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_IsSystemError(
            ref bool pbIsError);

        /** 
        <summary>Attempt to clear system error.  If the error cannot be cleared it is likely a serious system error.</summary>
        <param name="pbErrorCleared">Bool value that indicates the error could be cleared.  If </param>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_ClearSystemError(
            ref bool pbErrorCleared);

        /** 
        <summary>Are all of the TECs at the set temperature?</summary>
        <param name="pbIsAtSetTemperature">Bool value that indicates if the TECs are at the set temperatures.</param>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_AreTECsAtSetTemperature(
            ref bool pbIsAtSetTemperature);

        /** 
        <summary>Gets the system error word.</summary>
        <param name="pwErrorWord">16-bit error code.  See user's manual for a list of error codes.</param>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetSystemErrorWord(
            [MarshalAs(UnmanagedType.U2)] ref MIRcatConstant pwErrorWord);

        /** 
        <summary>Gets the wavelength display units specified in the laser settings.</summary>
        <param name="pbDisplayUnits">Display units for wavelength in the laser settings.</param>
        <see>MIRcatSDK_UNITS_MICRONS</see>
        <see>MIRcatSDK_UNITS_CM1</see>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetWWDisplayUnits(
            [MarshalAs(UnmanagedType.U1)] ref Units pbDisplayUnits);

        /** 
        <summary>Gets the status of the current scan/tune.</summary>
        <param name="pbIsScanInProgress">Bool value that indicates if the scan is in progress.</param>
        <param name="pbIsScanActive">Bool value that indicates if the scan is active.</param>
        <param name="pbIsScanPaused">Bool value that indicates if the scan is paused.</param>
        <param name="pwCurScanNum">Current scan number in repeated scan sequence.</param>
        <param name="pwCurrentScanPercent">Current scan percentage completed.</param>
        <param name="pfCurrentWW">Current wavelength of the laser.</param>
        <param name="pbUnits">Wavelength units.</param>
        <param name="pbIsTECInProgress">Bool value that indicates if the laser is waiting for a TEC to get to the target temperature before firing.</param>
        <param name="pbIsMotionInProgress">Bool value that indicates if a QCL is currently tuning.</param>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetScanStatus(
            ref bool pbIsScanInProgress,
            ref bool pbIsScanActive,
            ref bool pbIsScanPaused,
            ref UInt16 pwCurScanNum,
            ref UInt16 pwCurrentScanPercent,
            ref float pfCurrentWW,
            [MarshalAs(UnmanagedType.U1)] ref Units pbUnits,
            ref bool pbIsTECInProgress,
            ref bool pbIsMotionInProgress);

        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetScanWaitingProcessTrigger(
            ref bool bWaitProcTrig);

        /** 
        <summary>Gets the active QCL during a scan/tune.</summary>
        <param name="pbActiveQcl">The QCL that is active during this part of the scan/tune.</param>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetActiveQcl(
            ref byte pbActiveQcl);

        /* UTILITY FUNCTIONS */

        //Add function to convert from cm-1 to microns and vice-versa
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_ConvertWW(
            float fWW,
            [MarshalAs(UnmanagedType.U1)] Units bcurrentUnits,
            [MarshalAs(UnmanagedType.U1)] Units bnewUnits,
            ref float pfConvertedWW);

        /* ARM/DISARM Laser */

        /** 
        <summary>Arm the laser.</summary>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_ArmLaser();

        /** 
        <summary>Disarm the laser.</summary>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_DisarmLaser();

        /**
        <summary>Toggle the armed state of the laser based on the current state (i.e., if the laser is disarmed, this command will arm it and vice versa).</summary>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_ArmDisarmLaser();

        /* GENERAL SCAN OPERATIONS */

        /**
        <summary>Stops the current scan.</summary>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_StopScanInProgress();
        /**
        <summary>Pauses the current scan.  This function sends a pause command to the laser, but currently the laser does not support pausing of a scan.</summary>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_PauseScanInProgress();

        /**
        <summary>Resumes the current scan.  This function sends a resume command to the laser, but currently the laser does not support pausing of a scan, so will not resume.</summary>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_ResumeScanInProgress();

        /**
        <summary>Tells the laser to go to the next step in a Step and Measure or Multi-Spectral scan if the process trigger mode is set to Manual.</summary>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_ManualStepScanInProgress();

        /* TUNE APIs */

        /**
        <summary>Gets the actual tuned wavelength.  This can be used during a sweep or tune to indicate when target is reached</summary>
        <param name="pfActualWW">The actual wavelength the laser is currently tuned to.</param>
        <param name="pbUnits">The wavelength units for the tuning.</param>
        <param name="pbLightValid">Indicates if laser light is valid (tuned and emitting).</param>
        <see>MIRcatSDK_UNITS_MICRONS</see>
        <see>MIRcatSDK_UNITS_CM1</see>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetActualWW(
            ref float pfActualWW,
            [MarshalAs(UnmanagedType.U1)] ref Units pbUnits,
            ref bool pbLightValid);

        /**
        <summary>Gets the currently tuned target wavelength.</summary>
        <param name="pfTuneWW">The wavelength the laser is currently tuned to.</param>
        <param name="pbUnits">The wavelength units for the tuning.</param>
        <param name="pbPreferredQcl">The preferred QCL as specified in the last TuneToWW command indexed 1-4.  A value of 0 indicates no preferred QCL.</param>
        <see>MIRcatSDK_UNITS_MICRONS</see>
        <see>MIRcatSDK_UNITS_CM1</see>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetTuneWW(
            ref float pfTuneWW,
            [MarshalAs(UnmanagedType.U1)] ref Units pbUnits,
            ref byte pbPreferredQcl);

        /**
        <summary>Tune the laser to the specified wavelength with a preferred QCL.</summary>
        <param name="fTuneWW">The target wavelength to tune the laser to.</param>
        <param name="bUnits">The wavelength units for tuning the laser.</param>
        <param name="bPreferredQcl">The preferred QCL for this tune command indexed 1-4.  A value of 0 indicates no preferred QCL.</param>
        <see>MIRcatSDK_UNITS_MICRONS</see>
        <see>MIRcatSDK_UNITS_CM1</see>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_TuneToWW(
            float fTuneWW,
            [MarshalAs(UnmanagedType.U1)] Units bUnits,
            byte bPreferredQcl);

        /**
        <summary>Is the laser tuned?</summary>
        <param name="pbIsTuned">Bool value that indicates if the laser is currently tuned.</param>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_IsTuned(
            ref bool pbIsTuned);

        /**
        <summary>Cancel the current single tune.  If the laser is tuned in single tune mode, this command must be sent before performing a scan.</summary>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_CancelManualTuneMode();

        /**
        <summary>Turns laser emission on.  Laser must have been tuned to a wavelength prior to sending this command.</summary>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_TurnEmissionOn();

        /**
        <summary>Turns laser emission off.  If the laser emission is already off, this will return the MIRcatSDK_RET_EMISSION_ALREADY_OFF code.</summary>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_TurnEmissionOff();


        /* SWEEP APIs */

        /**
        <summary>Gets the sweep start wavelength from the last sweep scan.</summary>
        <param name="pfStartWW">Start wavelength of the last scan.</param>	
        <param name="pbUnits">Wavelength units.</param>	
        <see>MIRcatSDK_UNITS_MICRONS</see>
        <see>MIRcatSDK_UNITS_CM1</see>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetSweepStartWW(
            ref float pfStartWW,
            [MarshalAs(UnmanagedType.U1)] ref Units pbUnits);

        /**
        <summary>Gets the sweep stop wavelength from the last sweep scan.</summary>
        <param name="pfStopWW">Stop wavelength of the last scan.</param>	
        <param name="pbUnits">Wavelength units.</param>	
        <see>MIRcatSDK_UNITS_MICRONS</see>
        <see>MIRcatSDK_UNITS_CM1</see>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetSweepStopWW(
            ref float pfStopWW,
            [MarshalAs(UnmanagedType.U1)] ref Units pbUnits);

        /**
        <summary>Gets the sweep speed in the indicated units per second from the last sweep scan.</summary>
        <param name="pfScanSpeed">Scan speed in units per second.</param>	
        <param name="pbUnits">Wavelength units.</param>	
        <see>MIRcatSDK_UNITS_MICRONS</see>
        <see>MIRcatSDK_UNITS_CM1</see>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetSweepScanSpeed(
            ref float pfScanSpeed,
            [MarshalAs(UnmanagedType.U1)] ref Units pbUnits);

        /**
        <summary>Gets the number of iterations to be performed for this scan.</summary>
        <param name="pwNumScans">Number of scan iterations to be performed.  Note: A bi-directional scan will count the scan up and scan down as a single scan.</param>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetSweepNumScans(
            ref UInt16 pwNumScans);

        /**
        <summary>Is this scan bi-directional?</summary>
        <param name="pbIsBidirectional">Bool value indicating if this scan is bi-directional.</param>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_IsSweepBidirectional(
            ref bool pbIsBidirectional);

        /**
        <summary>Starts a sweep scan with the specified parameters.</summary>
        <param name="fStartWW">Start wavelength for this scan.</param>	
        <param name="fStopWW">Stop wavelength for this scan.</param>	
        <param name="fScanSpeed">Scan speed in specified units per second.</param>	
        <param name="bUnits">Wavelength units for this scan.</param>	
        <param name="wNumScans">Number of iterations of this scan to perform.</param>	
        <param name="bIsBiDirectional">Bool value indicating if this scan is bi-directional.</param>	
        <param name="u8PreferredQcl">The preferred QCL for this sweep scan command indexed 1-4.  A value of 0 indicates no preferred QCL.  If there is a preferred QCL, the scan will switch to this QCL as soon as possible and stay on this QCL as long as possible.</param>	
        <see>MIRcatSDK_UNITS_MICRONS</see>
        <see>MIRcatSDK_UNITS_CM1</see>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_StartSweepScan(
            float fStartWW,
            float fStopWW,
            float fScanSpeed,
            [MarshalAs(UnmanagedType.U1)] Units bUnits,
            UInt16 wNumScans,
            bool bIsBiDirectional,
            byte u8PreferredQcl);


        /* STEP & MEASURE APIs */

        /**
        <summary>Gets the Step and Measure start wavelength from the last Step and Measure scan.</summary>
        <param name="pfStartWW">Start wavelength of the last scan.</param>	
        <param name="pbUnits">Wavelength units.</param>	
        <see>MIRcatSDK_UNITS_MICRONS</see>
        <see>MIRcatSDK_UNITS_CM1</see>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetStepMeasureStartWW(
            ref float pfStartWW,
            [MarshalAs(UnmanagedType.U1)] ref Units pbUnits);

        /**
        <summary>Gets the Step and Measure stop wavelength from the last Step and Measure scan.</summary>
        <param name="pfStopWW">Stop wavelength of the last scan.</param>	
        <param name="pbUnits">Wavelength units.</param>	
        <see>MIRcatSDK_UNITS_MICRONS</see>
        <see>MIRcatSDK_UNITS_CM1</see>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetStepMeasureStopWW(
            ref float pfStopWW,
            [MarshalAs(UnmanagedType.U1)] ref Units pbUnits);

        /**
        <summary>Gets the Step and Measure step size from the last Step and Measure scan.</summary>
        <param name="pfStepSize">Step size in the specified units.</param>	
        <param name="pbUnits">Wavelength units.</param>	
        <see>MIRcatSDK_UNITS_MICRONS</see>
        <see>MIRcatSDK_UNITS_CM1</see>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetStepMeasureStepSizeWW(
            ref float pfStepSize,
            [MarshalAs(UnmanagedType.U1)] ref Units pbUnits);

        /**
        <summary>Gets the Step and Measure step size from the last Step and Measure scan.</summary>
        <param name="pfStepSize">Step size in the specified units.</param>	
        <param name="pbUnits">Wavelength units.</param>	
        <see>MIRcatSDK_UNITS_MICRONS</see>
        <see>MIRcatSDK_UNITS_CM1</see>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetStepMeasureNumScans(
            ref UInt16 pwNumScans);

        /**
        <summary>Starts a Step and Measure scan with the specified parameters.</summary>
        <param name="fStart">Start wavelength in the specified units.</param>	
        <param name="fStop">Stop wavelength in the specified units.</param>
        <param name="fStepSize">Step size in the specified units.</param>	
        <param name="bUnits">Wavelength units.</param>
        <param name="wNumScans">Number of iterations to be performed for this scan.</param>	
        <see>MIRcatSDK_UNITS_MICRONS</see>
        <see>MIRcatSDK_UNITS_CM1</see>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_StartStepMeasureModeScan(
            float fStart,
            float fStop,
            float fStepSize,
            [MarshalAs(UnmanagedType.U1)] Units bUnits,
            UInt16 wNumScans);

        /* MULTI-SPECTRAL APIs */

        /**
        <summary>Gets the number of elements in the last Multi-Spectral scan.</summary>
        <param name="pbNumElements">Number of elements in the Multi-Spectral scan.</param>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetNumMultiSpectralElements(
            ref byte pbNumElements);

        /**
        <summary>Gets the parameters for the specified element in a Multi-Spectral scan.</summary>
        <param name="bIndex">Element index.</param>	
        <param name="pfScanWW">Element wavelength.</param>	
        <param name="pdwDwellTime">Element dwell time.</param>	
        <param name="pdwOffTime">Element off time.</param>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetMultiSpectralElement(
            byte bIndex,
            ref float pfScanWW,
            ref UInt32 pdwDwellTime,
            ref UInt32 pdwOffTime);

        /**
        <summary>Gets the wavelength units for the last Multi-Spectral scan.</summary>
        <param name="pbUnits">Wavelength units for the Multi-Spectral scan.</param>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetMultiSpectralWWUnits(
            [MarshalAs(UnmanagedType.U1)] ref Units pbUnits);

        /**
        <summary>Gets the number of iterations for the last Multi-Spectral scan.</summary>
        <param name="pwNumScans">Number of scan iterations.</param>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetMultiSpectralNumScans(
            ref UInt16 pwNumScans);

        /**
        <summary>Sets the number of elements for a Multi-Spectral scan.</summary>
        <param name="bNumElements">Number of elements in a Multi-Spectral scan.</param>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_SetNumMultiSpectralElements(
            byte bNumElements);

        /**
        <summary>Adds a Multi-Spectral scan element to the end of the element list.</summary>
        <param name="fScanWW">Element wavelength.</param>	
        <param name="bUnits">Element wavelength units.</param>	
        <param name="dwDwellTime">Element dwell time.</param>	
        <param name="dwOffTime">Element off time.</param>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_AddMultiSpectralElement(
            float fScanWW,
            [MarshalAs(UnmanagedType.U1)] Units bUnits,
            UInt32 dwDwellTime,
            UInt32 dwOffTime);

        /**
        <summary>Starts a Multi-Spectral scan with the specified number of iterations.  The elements for this scan must have been setup previously.</summary>
        <param name="wNumScans">Number of iterations for this Multi-Spectral scan.</param>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_StartMultiSpectralModeScan(
            UInt16 wNumScans);

        /* FAVORITES APIs */

        /**
        <summary>Gets the number of user favorites that have been saved.</summary>
        <param name="pbNumFavorites">Number of favorites saved in the laser memory.</param>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetNumFavorites(
            ref byte pbNumFavorites);

        /**
        <summary>Gets the name of the favorite at the specified index.</summary>
        <param name="bIndex">Index of the favorite.</param>	
        <param name="pszFavoriteName">Name of the favorite.  This character array should be 32 bytes .</param>	
        <param name="bSize">Length in bytes of the favorite name.</param>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetFavoriteName(
            byte bIndex,
            [MarshalAs(UnmanagedType.LPStr, SizeParamIndex = 2)] ref string pszFavoriteName,
            byte bSize);

        /**
        <summary>Recalls the favorite with the given name.</summary>
        <param name="pszFavoriteName">Name of the favorite to recall.</param>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_RecallFavorite(
            string pszFavoriteName);

        /* SETTINGS APIs */

        /* All QCLs are indexed starting from 1 */

        /**
        <summary>Gets the pulse rate of the specified QCL in Hz.</summary>
        <param name="bQcl">QCL number indexed from 1.</param>	
        <param name="pfPulseRateInHz">Pulse Rate in Hz.</param>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetQCLPulseRate(
            byte bQcl,
            ref float pfPulseRateInHz);

        /**
        <summary>Gets the pulse width of the specified QCL in ns.</summary>
        <param name="bQcl">QCL number indexed from 1.</param>	
        <param name="pfPulseWidthInNanoSec">Pulse Width in ns.</param>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetQCLPulseWidth(
            byte bQcl,
            ref float pfPulseWidthInNanoSec);

        /**
        <summary>Gets the current setting of the specified QCL in mA.</summary>
        <param name="bQcl">QCL number indexed from 1.</param>	
        <param name="pfCurrentInMilliAmps">Current setting in mA.</param>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetQCLCurrent(
            byte bQcl,
            ref float pfCurrentInMilliAmps);

        /**
        <summary>Set the operating parameters for the specified QCL.</summary>
        <param name="bQcl">QCL number indexed from 1.</param>	
        <param name="fPulseRateInHz">Pulse rate in Hz.</param>	
        <param name="fPulseWidthInNanoSec">Pulse width in ns.</param>
        <param name="fCurrentInMilliAmps">Current in mA.</param>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_SetQCLParams(
            byte bQcl,
            float fPulseRateInHz,
            float fPulseWidthInNanoSec,
            float fCurrentInMilliAmps);

        /**
        <summary>Gets the pulse limits for the  specified QCL.</summary>
        <param name="bQcl">QCL number indexed from 1-4.</param>	
        <param name="pfpfPulseRateMaxInHz">Maximum pulse rate in Hz.</param>	
        <param name="pfPulseWidthMaxInNanoSec">Maximum pulse width in ns.</param>
        <param name="pfDutyCycleMax">Maximum pulsed duty cycle.</param>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetQCLPulseLimits(
            byte bQcl,
            ref float pfpfPulseRateMaxInHz,
            ref float pfPulseWidthMaxInNanoSec,
            ref float pfDutyCycleMax);

        /**
        <summary>Gets the max pulsed current setting of the specified QCL in mA.</summary>
        <param name="bQcl">QCL number indexed from 1-4.</param>	
        <param name="pfCurrentInMilliAmps">Maximum QCL current in mA.</param>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetQCLMaxPulsedCurrent(
            byte bQcl,
            ref UInt16 pfCurrentInMilliAmps);

        /**
        <summary>Gets the max CW current setting of the specified QCL in mA.</summary>
        <param name="bQcl">QCL number indexed from 1-4.</param>	
        <param name="pfCurrentInMilliAmps">Maximum QCL current in mA.</param>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetQCLMaxCwCurrent(
            byte bQcl,
            ref UInt16 pfCurrentInMilliAmps);

        /**
        <summary>Gets the status of CW being supported for this QCL.</summary>
        <param name="bQcl">QCL number indexed from 1-4.</param>	
        <param name="pbCwAllowed">Bool value that indicates if CW is supported on this channel.</param>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_isCwAllowed(
            byte bQcl,
            ref bool pbCwAllowed);

        /**
	    <summary>Gets the status of CW filters being supported for this QCL.</summary>
	    <param name="bQcl">QCL number indexed from 1-4.</param>	
	    <param name="pbCwAllowed">Bool value that indicates if CW filters are installed on this channel.</param>	
	    <returns>Error code.</returns>
	    */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_areCwFiltersInstalled(
            byte bQcl,
            ref bool pbFiltersInstalled);

        /**
        <summary>Gets the TEC current for the specified channel.</summary>
        <param name="bQcl">TEC number indexed from 1-4.</param>	
        <param name="pfCurrentInMilliAmps">TEC current in mA.</param>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetTecCurrent(
            byte bTec,
            ref UInt16 pfCurrentInMilliAmps);

        /**
        <summary>Gets the QCL temperature for the specified channel.</summary>
        <param name="bQcl">QCL number indexed from 1-4.</param>	
        <param name="pfQclTemperature">QCL temperature in degrees C.</param>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetQCLTemperature(
            byte bQcl,
            ref float pfQclTemperature);

        /**
        <summary>Gets the QCL operating mode for the specified channel.</summary>
        <param name="bQcl">QCL number indexed from 1-4.</param>	
        <param name="pbMode">QCL operating mode.</param>		
        <see>MIRcatSDK_MODE_ERROR</see>
        <see>MIRcatSDK_MODE_PULSED</see>
        <see>MIRcatSDK_MODE_CW</see>
        <see>MIRcatSDK_MODE_CW_MOD</see>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetQCLOperatingMode(
            byte bQcl,
            [MarshalAs(UnmanagedType.U1)] ref LaserMode pbMode);

        /**
        <summary>Gets the QCL set temperature for the specified channel in degrees C.</summary>
        <param name="bQcl">QCL number indexed from 1-4.</param>	
        <param name="pfQclSetTemperature">QCL set temperature.</param>	
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetQclSetTemperature(
            byte bQcl,
            ref float pfQclSetTemperature);

        /**
        <summary>Gets the QCL temperature range for the specified channel in degrees C.</summary>
        <param name="bQcl">QCL number indexed from 1-4.</param>	
        <param name="pfQclNominalTemperature">QCL nominal factory temperature.</param>
        <param name="pfQclMinTemperature">QCL minimum temperature.</param>
        <param name="pfQclMaxTemperature">QCL maximum temperature.</param>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetQCLTemperatureRange(
            byte bQcl,
            ref float pfQclNominalTemperature,
            ref float pfQclMinTemperature,
            ref float pfQclMaxTemperature);

        /**
        <summary>Set all of the operating parameters for the specified QCL.</summary>
        <param name="bQcl">QCL number indexed from 1.</param>	
        <param name="fPulseRateInHz">Pulse rate in Hz.</param>	
        <param name="fPulseWidthInNanoSec">Pulse width in ns.</param>
        <param name="fCurrentInMilliAmps">Current in mA.</param>
        <param name="fTemperature">Temperature in degrees Celsius.</param>
        <param name="u8laserMode">Laser Mode (Pulsed, CW, or CW+Mod).</param>	
        <see>MIRcatSDK_MODE_PULSED</see>
        <see>MIRcatSDK_MODE_CW</see>
        <see>MIRcatSDK_MODE_CW_MOD</see>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_SetAllQclParams(
            byte bQcl,
            float fPulseRate,
            float fPulseWidth,
            float fCurrentInMilliAmps,
            float fTemperature,
            [MarshalAs(UnmanagedType.U1)] LaserMode u8laserMode);

        /**
        <summary>Set all of the operating parameters for the specified QCL.</summary>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_PowerOffSystem();

        /*********************************************************************************************************
         *	Adding new functions below
         *********************************************************************************************************/

        /**
        <summary>Gets the current wavelength trigger parameters in the laser settings.</summary>
        <param name="pbPulseMode">Pulse Triggering Mode</param>	
        <param name="pfWlTrigStart">Wavelength Trigger Start Wavelength</param>	
        <param name="pfWlTrigStop">Wavelength Trigger Stop Wavelength</param>	
        <param name="pfWlTrigInterval">Wavelength Trigger Interval.</param>	
        <param name="units">Wavelength Units for trigger parameters</param>	
        <see>MIRcatSDK_PULSE_MODE_INTERNAL</see>
        <see>MIRcatSDK_PULSE_MODE_EXTERNAL_TRIGGER</see>
        <see>MIRcatSDK_PULSE_MODE_EXTERNAL_PASSTHRU</see>
        <see>MIRcatSDK_PULSE_MODE_WAVELENGTH_TRIGGER</see>
        <see>MIRcatSDK_PROC_TRIG_MODE_INTERNAL</see>
        <see>MIRcatSDK_PROC_TRIG_MODE_EXTERNAL</see>
        <see>MIRcatSDK_PROC_TRIG_MODE_MANUAL</see>
        <see>MIRcatSDK_UNITS_MICRONS</see>
        <see>MIRcatSDK_UNITS_CM1</see>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetWlTrigParams(
            [MarshalAs(UnmanagedType.U1)] ref PulseTriggerMode pbPulseMode,
            [MarshalAs(UnmanagedType.U1)] ref ProcessTriggerMode pbProcTrigMode,
            ref float pfWlTrigStart,
            ref float pfWlTrigStop,
            ref float pfWlTrigInterval,
            [MarshalAs(UnmanagedType.U1)] ref Units pbUnits,
            ref UInt32 pDwellTime,
            ref UInt32 pAfterOffTime);

        /**
        <summary>Sets the current wavelength trigger parameters in the laser settings.</summary>
        <param name="pbPulseMode">Pulse Triggering Mode</param>	
        <param name="pfWlTrigStart">Wavelength Trigger Start Wavelength</param>	
        <param name="pfWlTrigStop">Wavelength Trigger Stop Wavelength</param>	
        <param name="pfWlTrigInterval">Wavelength Trigger Interval.</param>	
        <param name="units">Wavelength Units for trigger parameters</param>	
        <see>MIRcatSDK_PULSE_MODE_INTERNAL</see>
        <see>MIRcatSDK_PULSE_MODE_EXTERNAL_TRIGGER</see>
        <see>MIRcatSDK_PULSE_MODE_EXTERNAL_PASSTHRU</see>
        <see>MIRcatSDK_PULSE_MODE_WAVELENGTH_TRIGGER</see>
        <see>MIRcatSDK_PROC_TRIG_MODE_INTERNAL</see>
        <see>MIRcatSDK_PROC_TRIG_MODE_EXTERNAL</see>
        <see>MIRcatSDK_PROC_TRIG_MODE_MANUAL</see>
        <see>MIRcatSDK_UNITS_MICRONS</see>
        <see>MIRcatSDK_UNITS_CM1</see>
        <returns>Error code.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_SetWlTrigParams(
            [MarshalAs(UnmanagedType.U1)] PulseTriggerMode pbPulseMode,
            [MarshalAs(UnmanagedType.U1)] ProcessTriggerMode pbProcTrigMode,
            float pfWlTrigStart,
            float pfWlTrigStop,
            float pfWlTrigInterval,
            [MarshalAs(UnmanagedType.U1)] Units pbUnits,
            UInt32 pDwellTime,
            UInt32 pAfterOffTime);

        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetWlTrigChanParams( 
            byte bChan, 
            [MarshalAs(UnmanagedType.U1)] ref Units units, 
            ref float start_ww, 
            ref float stop_ww, 
            ref float spacing, 
            ref UInt16 numTrigs );

        /**
        <summary>Gets System Temperatures.</summary>
        <param name="pfBenchTemp1">Bench Temperature Sensor 1 (degrees C)</param>	
        <param name="pfBenchTemp2">Bench Temperature Sensor 2 (degrees C)</param>	
        <param name="pfPcbTemp">PCB Temperature Sensor (degrees C)</param>		
        <returns>*MIRcatSDK_RET_SUCCESS* if the controller is initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.</returns>
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetSystemTemperatures(
            ref float pfBenchTemp1,
            ref float pfBenchTemp2,
            ref float pfPcbTemp);


        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_ReadWriteAdvancedSweepParams(
            bool fWrite);

        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_SetAdvancedSweepParams(
            [MarshalAs(UnmanagedType.U1)] Units pbUnits,
            float pfStartWave,
            float pfStopWave,
            float pfSpeed,
            UInt16 psNumScans,
            bool pbBidirectional);

        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetAdvancedSweepParams(
            [MarshalAs(UnmanagedType.U1)] ref Units pbUnits,
            ref float pfStartWave,
            ref float pfStopWave,
            ref float pfSpeed,
            ref UInt16 psNumScans,
            ref bool pbBidirectional);

        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_SetAdvancedSweepChanParams(
            byte bQcl,
            float chStartWave,
            float chStopWave,
            bool useChannel);

        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetAdvancedSweepChanParams(
            byte bQcl,
            ref float chStartWave,
            ref float chStopWave,
            ref bool useChannel);

        /*	Function: StartSweepAdvancedScan
        *	Starts Sweep Advanced Scan.
        *
        *
        *	Returns:
        *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_StartSweepAdvancedScan();

        /*	Function: InjectProcessTrigger
        *	Inject a manual process into the system for scans when in manual process trigger mode.
        *
        *	Returns:
        *		MIRcatSDK_RET_SUCCESS - If the system successfully injects a process trigger.
        *		MIRcatSDK_RET_INJECT_PROC_TRIG_ERROR - *[System Error]* If the system fails to inject a process trigger.
        */
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_InjectProcessTrigger();

        //MIRCAT_LIB uint32_t MIRcatSDK_GetReadbackParameters(uint8_t bQcl, float* actualQclCurrent, float* actualQclVoltage, float* actualVsrc, float* actualVfet);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetReadbackParameters(
            byte bQcl,
            ref float actualQclCurrent,
            ref float actualQclVoltage,
            ref float actualVsrc,
            ref float actualVfet);

        //MIRCAT_LIB uint32_t MIRcatSDK_GetAllTecParams(uint8_t bTec, float* voltage, float* current, float* resistance);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetAllTecParams(
            byte bTec,
            ref float voltage,
            ref float current,
            ref float resistance);

        //MIRCAT_LIB uint32_t MIRcatSDK_GetMoveDuration(uint8_t chan, uint32_t* moveDuration_us);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetMoveDuration(
            byte chan,
            ref UInt32 moveDuration_us);

        //MIRCAT_LIB uint32_t MIRcatSDK_GetWlTrigPulseWidth(uint16_t* wlTrigWidth_us);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetWlTrigPulseWidth(
            ref UInt16 wlTrigWidth_us);

        //MIRCAT_LIB uint32_t MIRcatSDK_SetWlTrigPulseWidth(uint16_t wlTrigWidth_us);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_SetWlTrigPulseWidth(
            UInt16 wlTrigWidth_us);

        //MIRCAT_LIB uint32_t MIRcatSDK_EnableRedLaserPointer(bool enable);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_EnableRedLaserPointer(bool enable);

        /*********************************************************************************************************
         *	Pointing Control Functions
         *********************************************************************************************************/

        /*	Function: PointingControlsSupported
        *	Checks if the system supports MIRcat-QT-Z pointing controls.
        *
        *	Parameters:
        *		enabled - (out) Indicates if the system supports pointing controls (MIRcat-QT-Z)
        *
        *	Returns:
        *		Return codes:
        *		MIRcatSDK_RET_SUCCESS
        *		MIRcatSDK_RET_NOT_INITIALIZED
        *		MIRcatSDK_RET_COMM_ERROR
        */
        //MIRCAT_LIB uint32_t MIRcatSDK_PointingControlsSupported(bool* enabled);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_PointingControlsSupported(ref bool enabled);

        //Get/Set Pointing Compensation Enabled

        /*	Function: PointingGetCompensationEnabled
        *	Checks if pointing compensation is enabled.  If pointing compensation is enabled it
        *	will use the pointing calibration table to "flatten" out the pointing vs. wavelength.
        *
        *	Parameters:
        *		enableX - (out) Indicates if the X axis pointing compensation is enabled.
        *		enableY - (out) Indicates if the Y axis pointing compensation is enabled.
        *
        *	Returns:
        *		Return codes:
        *		MIRcatSDK_RET_SUCCESS
        *		MIRcatSDK_RET_NOT_INITIALIZED
        *		MIRcatSDK_RET_COMM_ERROR
        */
        //MIRCAT_LIB uint32_t MIRcatSDK_PointingGetCompensationEnabled(bool* xEnabled, bool* yEnabled);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_PointingGetCompensationEnabled(
            ref bool xEnabled,
            ref bool yEnabled);

        /*	Function: PointingCompensationEnable
        *	Enables or disables pointing compensation.  If pointing compensation is enabled it 
        *	will use the pointing calibration table to "flatten" out the pointing vs. wavelength.
        *
        *	Parameters:
        *		enableX - (in) Used to enable/disable X axis pointing compensation.
        *		enableY - (in) Used to enable/disable Y axis pointing compensation.
        *
        *	Returns:
        *		Return codes:
        *		MIRcatSDK_RET_SUCCESS
        *		MIRcatSDK_RET_NOT_INITIALIZED
        *		MIRcatSDK_RET_PASSED_NULL_POINTER
        *		MIRcatSDK_RET_COMM_ERROR
        */
        //MIRCAT_LIB uint32_t MIRcatSDK_PointingCompensationEnable(bool enableX, bool enableY);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_PointingCompensationEnable(
            bool enableX,
            bool enableY);


        /*	Function: PointingGoToPosition
        *	Commands MIRcat-QT-Z pointing system to go to X/Y position.  Pointing compensation
        *	should be disabled prior to commanding positions with this function.
        *
        *	Parameters:
        *		xCounts - (in) Target x position in counts.
        *		yCounts - (in) Target y position in counts.
        *
        *	Returns:
        *		Return codes:
        *		MIRcatSDK_RET_SUCCESS
        *		MIRcatSDK_RET_NOT_INITIALIZED
        *		MIRcatSDK_RET_COMM_ERROR
        */
        //MIRCAT_LIB uint32_t MIRcatSDK_PointingGoToPosition(int xCounts, int yCounts);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_PointingGoToPosition(
            int xCounts,
            int yCounts);

        /*	Function: PointingGetPosition
        *	Gets the current position of the pointing system.
        *
        *	Parameters:
        *		xCounts - (out) Target x position in counts.
        *		yCounts - (out) Target y position in counts.
        *
        *	Returns:
        *		Return codes:
        *		MIRcatSDK_RET_SUCCESS
        *		MIRcatSDK_RET_NOT_INITIALIZED
        *		MIRcatSDK_RET_PASSED_NULL_POINTER
        *		MIRcatSDK_RET_COMM_ERROR
        */
        //MIRCAT_LIB uint32_t MIRcatSDK_PointingGetPosition(int* xCounts, int* yCounts);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_PointingGetPosition(
            ref int xCounts,
            ref int yCounts);


        /*	Function: PointingGetActiveChannel
        *	Gets the laser channel that the pointing system is outputting.
        *
        *	Parameters:
        *		chan - (out) Laser channel for which the pointing system is outputting.
        *
        *	Returns:
        *		Return codes:
        *		MIRcatSDK_RET_SUCCESS
        *		MIRcatSDK_RET_NOT_INITIALIZED
        *		MIRcatSDK_RET_PASSED_NULL_POINTER
        *		MIRcatSDK_RET_COMM_ERROR
        */
        //MIRCAT_LIB uint32_t MIRcatSDK_PointingGetActiveChannel(uint8_t* chan);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_PointingGetActiveChannel(ref byte chan);

        /*	Function: PointingSetActiveChannel
        *	Sets the laser channel that the pointing system is outputting.
        *
        *	Parameters:
        *		chan - (in) Laser channel to output with the pointing system
        *
        *	Returns:
        *		Return codes:
        *		MIRcatSDK_RET_SUCCESS
        *		MIRcatSDK_RET_NOT_INITIALIZED
        *		MIRcatSDK_RET_QCL_NUM_OUTOFRANGE
        *		MIRcatSDK_RET_COMM_ERROR
        */
        //MIRCAT_LIB uint32_t MIRcatSDK_PointingSetActiveChannel(uint8_t chan);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_PointingSetActiveChannel(byte chan);

        /*	Function: PointingGetActiveBasePosition
        *	Gets the active base position for the given laser channel.
        *
        *	Parameters:
        *		chan - (in) Laser channel to query the base position of.
        *		baseX - (out) X position in counts of the base position for this channel.
        *		baseY - (out) Y position in counts of the base position for this channel.
        *
        *	Returns:
        *		Return codes:
        *		MIRcatSDK_RET_SUCCESS
        *		MIRcatSDK_RET_NOT_INITIALIZED
        *		MIRcatSDK_RET_PASSED_NULL_POINTER
        *		MIRcatSDK_RET_QCL_NUM_OUTOFRANGE
        *		MIRcatSDK_RET_COMM_ERROR
        */
        //MIRCAT_LIB uint32_t MIRcatSDK_PointingGetActiveBasePosition(uint8_t chan, int* baseX, int* baseY);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_PointingGetActiveBasePosition(
            byte chan,
            ref int baseX,
            ref int baseY);

        /*	Function: PointingSetActiveBasePosition
        *	Sets the active base position for the given laser channel.
        *
        *	Parameters:
        *		chan - (in) Laser channel to query the base position of.
        *		baseX - (in) X position in counts of the base position for this channel.
        *		baseY - (in) Y position in counts of the base position for this channel.
        *
        *	Returns:
        *		Return codes:
        *		MIRcatSDK_RET_SUCCESS
        *		MIRcatSDK_RET_NOT_INITIALIZED
        *		MIRcatSDK_RET_QCL_NUM_OUTOFRANGE
        *		MIRcatSDK_RET_COMM_ERROR
        */
        //MIRCAT_LIB uint32_t MIRcatSDK_PointingSetActiveBasePosition(uint8_t chan, int baseX, int baseY);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_PointingSetActiveBasePosition(
            byte chan,
            int baseX,
            int baseY);

        /*	Function: PointingGetFactoryBasePosition
        *	Gets the factory base position for the given laser channel.
        *
        *	Parameters:
        *		chan - (in) Laser channel to query the base position of.
        *		baseX - (out) X position in counts of the base position for this channel.
        *		baseY - (out) Y position in counts of the base position for this channel.
        *
        *	Returns:
        *		Return codes:
        *		MIRcatSDK_RET_SUCCESS
        *		MIRcatSDK_RET_NOT_INITIALIZED
        *		MIRcatSDK_RET_PASSED_NULL_POINTER
        *		MIRcatSDK_RET_QCL_NUM_OUTOFRANGE
        *		MIRcatSDK_RET_COMM_ERROR
        */
        //MIRCAT_LIB uint32_t MIRcatSDK_PointingGetFactoryBasePosition(uint8_t chan, int* baseX, int* baseY);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_PointingGetFactoryBasePosition(
            byte chan,
            ref int baseX,
            ref int baseY);

        /*	Function: PointingReadCalTableInfo
        *	Read the calibration table information for the requested calibration table.
        *
        *	Parameters:
        *		chan - (in) Laser channel for this calibration table.
        *		tableNum - (in) Table number for this calibration table.  There are up to 8 tables per channel (indexed 0 - 7).
        *		tableExists - (out) Indicates if a calibration table exists for this channel/table number.
        *		numEntries - (out) The number of calibration entries in this calibration table.
        *		wlUnits - (out) Wavelength units used for this calibration table (see cal table format for wavelength units).
        *		laserMode - (out) Laser mode used for this calibration table (see cal table format for laser mode).
        *		tableName - (out) Table name for this table.  tableName should point to char array of at least 32 characters.
        *
        *	Returns:
        *		Return codes:
        *		MIRcatSDK_RET_SUCCESS
        *		MIRcatSDK_RET_NOT_INITIALIZED
        *		MIRcatSDK_RET_PASSED_NULL_POINTER
        *		MIRcatSDK_RET_QCL_NUM_OUTOFRANGE
        *		MIRcatSDK_RET_TABLE_NUM_OUT_OF_RANGE
        *		MIRcatSDK_RET_COMM_ERROR
        *		MIRcatSDK_RET_STRCPY_ERROR
        */
        //MIRCAT_LIB uint32_t MIRcatSDK_PointingReadCalTableInfo(uint8_t chan, uint8_t tableNum,
        //                                                        bool* tableExists,
        //                                                        uint16_t* numEntries,
        //                                                        uint8_t* wlUnits,
        //                                                        uint8_t* laserMode,
        //                                                        char* tableName);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_PointingReadCalTableInfo(
            byte chan,
            byte tableNum,
            ref UInt16 numEntries,
            [MarshalAs(UnmanagedType.U1)] ref Units wlUnits,
            ref byte laserMode,
            [MarshalAs(UnmanagedType.LPStr, SizeConst = (int)Pointing.MIRCATSDK_POINTING_TABLE_NAME_LEN_MAX)] ref string tableName);


        /*	Function: PointingExportCalTable
        *	Export the calibration table for this channel/table number.
        *
        *	Parameters:
        *		chan - (in) Laser channel for this calibration table.
        *		tableNum - (in) Table number for this calibration table.  There are up to 8 tables per channel (indexed 0 - 7).
        *		numEntries - (out) The number of calibration entries in this calibration table.
        *		wavelengths - (out) Array of wavelengths for this calibration table.  Caller should allocate an array of 1024 elements (max table entries) to pass in.
        *		xCal - (out) Array of x calibration offsets for this calibration table.  Caller should allocate an array of 1024 elements (max table entries) to pass in.
        *		yCal - (out) Array of y calibration offsets for this calibration table.  Caller should allocate an array of 1024 elements (max table entries) to pass in.
        *
        *	Returns:
        *		Return codes:
        *		MIRcatSDK_RET_SUCCESS
        *		MIRcatSDK_RET_NOT_INITIALIZED
        *		MIRcatSDK_RET_PASSED_NULL_POINTER
        *		MIRcatSDK_RET_QCL_NUM_OUTOFRANGE
        *		MIRcatSDK_RET_TABLE_NUM_OUT_OF_RANGE
        *		MIRcatSDK_RET_COMM_ERROR
        */
        //MIRCAT_LIB uint32_t MIRcatSDK_PointingExportCalTable(uint8_t chan, uint8_t tableNum,
        //                                                        uint16_t* numEntries,
        //                                                        float* wavelengths,
        //                                                        int32_t* xCal,
        //                                                        int32_t* yCal);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_PointingExportCalTable(
            byte chan,
            byte tableNum,
            ref float wavelengths,
            ref Int32 xCal,
            ref Int32 yCal);


        /*	Function: PointingImportCalTable
        *	Import the calibration table for this channel / table number.  Note, table number 0 is typically used as the factory calibration table.
        *	This function does not allow the user to import a calibration table as table number 0 to prevent the factory calibration from being overwritten.
        *
        *	Parameters:
        *		chan - (in) Laser channel for this calibration table.
        *		tableNum - (in) Table number for this calibration table.  There are up to MIRCATSDK_POINTING_MAX_TABLES_PER_CHANNEL
        *			tables per channel(indexed 0 - 7).
        *		numEntries - (in) The number of calibration entries in this calibration table.
        *		wlUnits - (in) The wavelength units used for this calibration table (see cal table format for wavelength units).
        *		laserMode - (in) Laser mode for this calibration table (see cal table format for laser mode units).
        *		wavelengths - (in) Array of wavelengths for this calibration table.  Size of array should match numEntries.
        *		xCal - (in) Array of x calibration offsets for this calibration table.  Size of array should match numEntries.
        *		yCal - (in) Array of y calibration offsets for this calibration table.  Size of array should match numEntries.
        *
        *	Returns:
        *	Return codes :
        *		MIRcatSDK_RET_SUCCESS
        *		MIRcatSDK_RET_NOT_INITIALIZED
        *		MIRcatSDK_RET_PASSED_NULL_POINTER
        *		MIRcatSDK_RET_QCL_NUM_OUTOFRANGE
        *		MIRcatSDK_RET_TABLE_NUM_OUT_OF_RANGE
        *		MIRcatSDK_RET_COMM_ERROR
        */
        //MIRCAT_LIB uint32_t MIRcatSDK_PointingImportCalTable(uint8_t chan, uint8_t tableNum,
        //                                                    uint16_t numEntries, uint8_t wlUnits, uint8_t laserMode,
        //                                                    char* tableName,
        //                                                    float* wavelengths,
        //                                                    int32_t* xCal,
        //                                                    int32_t* yCal);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_PointingImportCalTable(
            byte chan,
            byte tableNum,
            UInt16 numEntries,
            [MarshalAs(UnmanagedType.U1)] Units wlUnits,
            byte laserMode,
            [MarshalAs(UnmanagedType.LPStr, SizeConst = (int)Pointing.MIRCATSDK_POINTING_TABLE_NAME_LEN_MAX)] string tableName,
            ref float wavelengths,
            ref Int32 xCal,
            ref Int32 yCal);


        /*	Function: PointingActivateCalTable
        *	Activate a specific pointing calibration table.  
        *
        *	Parameters:
        *		chan - (in) Laser channel for this calibration table.
        *		tableNum - (in) Table number for this calibration table.  There are up to MIRCATSDK_POINTING_MAX_TABLES_PER_CHANNEL
        *			tables per channel(indexed 0 - 7).
        *
        *	Returns:
        *		Return codes:
        *		MIRcatSDK_RET_SUCCESS
        *		MIRcatSDK_RET_NOT_INITIALIZED
        *		MIRcatSDK_RET_QCL_NUM_OUTOFRANGE
        *		MIRcatSDK_RET_TABLE_NUM_OUT_OF_RANGE
        *		MIRcatSDK_RET_COMM_ERROR
        */
        //MIRCAT_LIB uint32_t MIRcatSDK_PointingActivateCalTable(uint8_t chan, uint8_t tableNum);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_PointingActivateCalTable(
            byte chan,
            byte tableNum);

        /*	Function: PointingGetActivateCalTable
        *	Gets the active pointing calibration table for a given channel.  If no table has been activated this will return
        *	MIRCATSDK_POINTING_MAX_TABLES_PER_CHANNEL.
        *
        *	Parameters:
        *		chan - (in) Laser channel for this calibration table.
        *		tableNum - (out) Table number for this calibration table.  There are up to MIRCATSDK_POINTING_MAX_TABLES_PER_CHANNEL
        *			tables per channel(indexed 0 - 7).  If no table is active then this will return MIRCATSDK_POINTING_MAX_TABLES_PER_CHANNEL.
        *
        *	Returns:
        *		Return codes:
        *		MIRcatSDK_RET_SUCCESS
        *		MIRcatSDK_RET_NOT_INITIALIZED
        *		MIRcatSDK_RET_QCL_NUM_OUTOFRANGE
        *		MIRcatSDK_RET_COMM_ERROR
        */
        //MIRCAT_LIB uint32_t MIRcatSDK_PointingGetActiveCalTable(uint8_t chan, uint8_t* tableNum);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_PointingGetActiveCalTable(
            byte chan,
            ref byte tableNum);


        //Function to delete specific table
        /*	Function: PointingDeleteCalTable
        *	Delete a specific pointing calibration table.  Note, table number 0 is typically used as the factory calibration table.
        *	This function does not allow the user to delete calibration table 0.
        *
        *	Parameters:
        *		chan - (in) Laser channel for this calibration table.
        *		tableNum - (in) Table number for this calibration table.  There are up to MIRCATSDK_POINTING_MAX_TABLES_PER_CHANNEL
        *			tables per channel(indexed 0 - 7).
        *
        *	Returns:
        *		Return codes:
        *		MIRcatSDK_RET_SUCCESS
        *		MIRcatSDK_RET_NOT_INITIALIZED
        *		MIRcatSDK_RET_QCL_NUM_OUTOFRANGE
        *		MIRcatSDK_RET_TABLE_NUM_OUT_OF_RANGE
        *		MIRcatSDK_RET_COMM_ERROR
        */
        //MIRCAT_LIB uint32_t MIRcatSDK_PointingDeleteCalTable(uint8_t chan, uint8_t tableNum);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_PointingDeleteCalTable(
            byte chan,
            byte tableNum);

        //MIRCAT_LIB uint32_t MIRcatSDK_GetAdminMode(bool* adminMode);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_GetAdminMode(ref byte adminMode);
        //MIRCAT_LIB uint32_t MIRcatSDK_SetAdminMode(int32_t password, bool adminMode);
        [DllImport("MIRcatSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern SDKConstant MIRcatSDK_SetAdminMode(
            Int32 password,
            bool adminMode);
    }
}
