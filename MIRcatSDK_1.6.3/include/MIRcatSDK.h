//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
// MIRcatSDK.h
//
// Copyright (c) 2013-2014.   All rights reserved.
// Daylight Solutions
// 15378 Avenue of Science, Suite 200
// San Diego, CA  92128
//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

#ifndef _MIRcatSDK_H_
#define _MIRcatSDK_H_
#include <stdint.h>

// Title: MIRcatSDK.h

/* Topic: Documentation and Code Conventions

        - Every function the SDK starts with *MIRcatSDK_*. This prefix is
   omitted from the much of the documentation.
        - Since most functions return <Error Codes>, functions that require data
   output use out parameters. The user must pass a pointer with enough storage
   space to hold the data. Out parameters are noted in the documentation by
                *(out)*.
*/
#ifdef WIN32_EXPORT
#define MIRCAT_LIB __declspec(dllexport)
#elif __linux__
#define MIRCAT_LIB
#else
#define MIRCAT_LIB __declspec(dllimport)
#endif



/* Section: Constants */

/* Group: Error Codes

   SIDEKICK_SDK_RET_SUCCESS - Success error code. Compare return value from function with this value to check for success.
*/

#define MIRcatSDK_RET_SUCCESS                               ((uint32_t)0)

/* Constants: Communication and Transport Errors
   MIRcatSDK_RET_UNSUPPORTED_TRANSPORT - If the user specified `commType` is invalid.
*/
#define MIRcatSDK_RET_UNSUPPORTED_TRANSPORT                 ((uint32_t)1)

/* Constants: Initialization Errors
   MIRcatSDK_RET_INITIALIZATION_FAILURE - *[System Error]* If MIRcat controller Initialization failed.
*/
#define MIRcatSDK_RET_INITIALIZATION_FAILURE                ((uint32_t)32)

/* Constants: Function Return Error Codes
   MIRcatSDK_RET_ARMDISARM_FAILURE - *[System Error]* If the system fails to either arm or disarm the laser.
   MIRcatSDK_RET_STARTTUNE_FAILURE - *[System Error]* If the system fails to tune the laser to the user specified wavelength.
   MIRcatSDK_RET_INTERLOCKS_KEYSWITCH_NOTSET - *[User Error]* If the interlock status is not set or the key switch is not set.
   MIRcatSDK_RET_STOP_SCAN_FAILURE - *[System Error]* If the system fails to successfully stop the scan in progress.
   MIRcatSDK_RET_PAUSE_SCAN_FAILURE - *[System Error]* If the system fails to pause the scan in progress.
   MIRcatSDK_RET_RESUME_SCAN_FAILURE - *[System Error]* If the system fails to resume the scan in progress.
   MIRcatSDK_RET_MANUAL_STEP_SCAN_FAILURE - *[System Error]* If the system fails to manually move to the next step.
   MIRcatSDK_RET_START_SWEEPSCAN_FAILURE - *[System Error]* If the system fails to start a Sweep Scan.
   MIRcatSDK_RET_START_STEPMEASURESCAN_FAILURE - *[System Error]* If the system fails to start a step and measure scan.
   MIRcatSDK_RET_INDEX_OUTOFBOUNDS - *[User Error]* If the user specified index is invalid and out of bounds.
   MIRcatSDK_RET_START_MULTISPECTRALSCAN_FAILURE - *[System Error]* If the system fails to start a Multi-Spectral Scan.
   MIRcatSDK_RET_TOO_MANY_ELEMENTS - *[User Error]* The user specified number of elements is too large.
   MIRcatSDK_RET_NOT_ENOUGH_ELEMENTS - *[User Error]* If the user does not define enough Multi-Spectral scan elements.
   MIRcatSDK_RET_BUFFER_TOO_SMALL - *[User Error]* If the user specified buffer is too small for the character array.
   MIRcatSDK_RET_FAVORITE_NAME_NOTRECOGNIZED - *[User Error]* If the user specifies an invalid favorite name.
   MIRcatSDK_RET_FAVORITE_RECALL_FAILURE - *[System Error]* If the system fails to recall the favorite with the user specified name.
   MIRcatSDK_RET_WW_OUTOFTUNINGRANGE - *[User Error]* If the user specified wavelength is out of the valid range.
   MIRcatSDK_RET_NO_SCAN_INPROGRESS - *[User Error]* If the user attempts to modify a scan when there is no current scan in progress.
   MIRcatSDK_RET_EMISSION_ON_FAILURE - *[System Error]* If the system fails to enable the laser emission.
   MIRcatSDK_RET_EMISSION_ALREADY_OFF - *[User Error]* If the user attempts to diable laser emission when it is already disabled.
   MIRcatSDK_RET_EMISSION_OFF_FAILURE - *[System Error]* If the system fails to disable the laser emission.
   MIRcatSDK_RET_EMISSION_ALREADY_ON - *[User Error]* If the user attempts to enable the laser emission while the laser is already emitting.
   MIRcatSDK_RET_PULSERATE_OUTOFRANGE - *[User Error]* If the user specified pulse rate is invalid and out of range.
   MIRcatSDK_RET_PULSEWIDTH_OUTOFRANGE - *[User Error]* If the user specified pulse width is invalid and out of range.
   MIRcatSDK_RET_CURRENT_OUTOFRANGE - *[User Error]* If the user specifies an invalid current that is out of range.
   MIRcatSDK_RET_SAVE_SETTINGS_FAILURE - *[System Error]* If the system fails to save the QCL settings.
   MIRcatSDK_RET_QCL_NUM_OUTOFRANGE - *[User Error]* If the user specified QCL is out of range. Must be 1-4.
   MIRcatSDK_RET_LASER_ALREADY_ARMED - *[User Error]* If the user attempts to arm the laser when it has already been armed.
   MIRcatSDK_RET_LASER_ALREADY_DISARMED - *[User Error]* If the user attempts to disarm the laser when it has already been disarmed.
   MIRcatSDK_RET_LASER_NOT_ARMED - *[User Error]* If the user attempts to modify the laser when the laser is not yet armed.
   MIRcatSDK_RET_LASER_NOT_TUNED - *[User Error]* If the user attempts to enable laser emission before tuning the laser.
   MIRcatSDK_RET_TECS_NOT_AT_SET_TEMPERATURE - *[System Error]* If the system is not operating at the set temperature.
   MIRcatSDK_RET_CW_NOT_ALLOWED_ON_QCL - *[User Error]* If the user specified QCL does not support CW.
   MIRcatSDK_RET_INVALID_LASER_MODE - *[User Error]* If the user specifies an invalid laser mode.
   MIRcatSDK_RET_TEMPERATURE_OUT_OF_RANGE - *[User Error]* If the user specifies an invalid temperature that is out of range.
   MIRcatSDK_RET_LASER_POWER_OFF_ERROR - *[System Error]* If the system fails to power off the laser.
   #define MIRcatSDK_RET_COMM_ERROR - *[System Error]*
   MIRcatSDK_RET_NOT_INITIALIZED - *[User Error]* If user attempts to modify the MIRcat object or call a function before the MIRcatController is initialized. Call *MIRcatSDK_CreateMIRcatObject()* or *MIRcatSDK_Initialize()* to fix the error.
   MIRcatSDK_RET_ALREADY_CREATED - *[User Error]* If the user attempts to create a new MIRcatObject when an instance has already been initialized.
   MIRcatSDK_RET_START_SWEEP_ADVANCED_SCAN_FAILURE - *[System Error]* If the system fails to start a Sweep-Advanced Scan.
   MIRcatSDK_RET_INJECT_PROC_TRIG_ERROR - *[System Error]* If the system fails to inject a process trigger.
   MIRcatSDK_MODE_ERROR - *[User Error]* If the user specifies an invalid laser mode.
*/
#define MIRcatSDK_RET_ARMDISARM_FAILURE                     ((uint32_t)64)
#define MIRcatSDK_RET_STARTTUNE_FAILURE                     ((uint32_t)65)
#define MIRcatSDK_RET_INTERLOCKS_KEYSWITCH_NOTSET           ((uint32_t)66)
#define MIRcatSDK_RET_STOP_SCAN_FAILURE                     ((uint32_t)67)
#define MIRcatSDK_RET_PAUSE_SCAN_FAILURE                    ((uint32_t)68)
#define MIRcatSDK_RET_RESUME_SCAN_FAILURE                   ((uint32_t)69)
#define MIRcatSDK_RET_MANUAL_STEP_SCAN_FAILURE              ((uint32_t)70)
#define MIRcatSDK_RET_START_SWEEPSCAN_FAILURE               ((uint32_t)71)
#define MIRcatSDK_RET_START_STEPMEASURESCAN_FAILURE         ((uint32_t)72)
#define MIRcatSDK_RET_INDEX_OUTOFBOUNDS                     ((uint32_t)73)
#define MIRcatSDK_RET_START_MULTISPECTRALSCAN_FAILURE       ((uint32_t)74)
#define MIRcatSDK_RET_TOO_MANY_ELEMENTS                     ((uint32_t)75)
#define MIRcatSDK_RET_NOT_ENOUGH_ELEMENTS                   ((uint32_t)76)
#define MIRcatSDK_RET_BUFFER_TOO_SMALL                      ((uint32_t)77)
#define MIRcatSDK_RET_FAVORITE_NAME_NOTRECOGNIZED           ((uint32_t)78)
#define MIRcatSDK_RET_FAVORITE_RECALL_FAILURE               ((uint32_t)79)
#define MIRcatSDK_RET_WW_OUTOFTUNINGRANGE                   ((uint32_t)80)
#define MIRcatSDK_RET_NO_SCAN_INPROGRESS                    ((uint32_t)81)
#define MIRcatSDK_RET_EMISSION_ON_FAILURE                   ((uint32_t)82)
#define MIRcatSDK_RET_EMISSION_ALREADY_OFF                  ((uint32_t)83)
#define MIRcatSDK_RET_EMISSION_OFF_FAILURE                  ((uint32_t)84)
#define MIRcatSDK_RET_EMISSION_ALREADY_ON                   ((uint32_t)85)
#define MIRcatSDK_RET_PULSERATE_OUTOFRANGE                  ((uint32_t)86)
#define MIRcatSDK_RET_PULSEWIDTH_OUTOFRANGE                 ((uint32_t)87)
#define MIRcatSDK_RET_CURRENT_OUTOFRANGE                    ((uint32_t)88)
#define MIRcatSDK_RET_SAVE_SETTINGS_FAILURE                 ((uint32_t)89)
#define MIRcatSDK_RET_QCL_NUM_OUTOFRANGE                    ((uint32_t)90)
#define MIRcatSDK_RET_LASER_ALREADY_ARMED                   ((uint32_t)91)
#define MIRcatSDK_RET_LASER_ALREADY_DISARMED                ((uint32_t)92)
#define MIRcatSDK_RET_LASER_NOT_ARMED                       ((uint32_t)93)
#define MIRcatSDK_RET_LASER_NOT_TUNED                       ((uint32_t)94)
#define MIRcatSDK_RET_TECS_NOT_AT_SET_TEMPERATURE           ((uint32_t)95)
#define MIRcatSDK_RET_CW_NOT_ALLOWED_ON_QCL                 ((uint32_t)96)
#define MIRcatSDK_RET_INVALID_LASER_MODE                    ((uint32_t)97)
#define MIRcatSDK_RET_TEMPERATURE_OUT_OF_RANGE              ((uint32_t)98)
#define MIRcatSDK_RET_LASER_POWER_OFF_ERROR                 ((uint32_t)99)
#define MIRcatSDK_RET_COMM_ERROR                            ((uint32_t)100)
#define MIRcatSDK_RET_NOT_INITIALIZED                       ((uint32_t)101)
#define MIRcatSDK_RET_ALREADY_CREATED                       ((uint32_t)102)
#define MIRcatSDK_RET_START_SWEEP_ADVANCED_SCAN_FAILURE	    ((uint32_t)103)
#define MIRcatSDK_RET_INJECT_PROC_TRIG_ERROR                ((uint32_t)104)
#define MIRcatSDK_RET_PASSED_NULL_POINTER					((uint32_t)105)
#define MIRcatSDK_RET_TABLE_NUM_OUT_OF_RANGE				((uint32_t)106)
#define MIRcatSDK_RET_STRCPY_ERROR							((uint32_t)107)
#define MIRcatSDK_RET_TOO_MANY_CAL_ENTRIES					((uint32_t)108)
#define MIRcatSDK_RET_CANNOT_DELETE_FACTORY_CAL				((uint32_t)109)
#define MIRcatSDK_RET_CANNOT_OVERWRITE_FACTORY_CAL			((uint32_t)110)
#define MIRcatSDK_RET_ADMIN_PASSWORD_INCORRECT				((uint32_t)111)
#define MIRcatSDK_RET_NO_DEVICE_AT_HANDLE					((uint32_t)112)
#define MIRcatSDK_RET_CONNECT_FAIL_AT_HANDLE				((uint32_t)113)
#define MIRcatSDK_RET_NO_CONTROLLER_AT_HANDLE				((uint32_t)114)
#define MIRcatSDK_RET_DISCONNECT_ERROR						((uint32_t)115)



/* Group: Parameters */


/* Constant: Communication Parameters
   Parameters used to configure communication with MIRcat system.

   MIRcatSDK_COMM_SERIAL - Communication via Serial port.
   MIRcatSDK_COMM_UDP - Communication via UDP.
   MIRcatSDK_COMM_DEFAULT - Uses Serial Communication as the default.
*/
#define MIRcatSDK_COMM_SERIAL                               ((uint8_t)1)
#define MIRcatSDK_COMM_UDP                                  ((uint8_t)2)
#define MIRcatSDK_COMM_DEFAULT                              MIRcatSDK_COMM_SERIAL

/* Constant: Serial port parameters

   MIRcatSDK_SERIAL_PORT_AUTO - Automatically find the device on the port.
   MIRcatSDK_SERIAL_BAUD_USE_DEFAULT - desc
   MIRcatSDK_SERIAL_BAUD1 - desc
   MIRcatSDK_SERIAL_BAUD2 - desc
*/
#define MIRcatSDK_SERIAL_PORT_AUTO                          ((uint16_t)0)
#define MIRcatSDK_SERIAL_BAUD_USE_DEFAULT                   ((uint32_t)0)
#define MIRcatSDK_SERIAL_BAUD1                              ((uint16_t)115200)
#define MIRcatSDK_SERIAL_BAUD2                              ((uint16_t)921600)

/* Constant: Units
   Units for functions that use wavelength values.

   MIRcatSDK_UNITS_MICRONS - Micrometers, 1 x 10^-6 meters
   MIRcatSDK_UNITS_CM1 - Wavenumbers in cm^-1 units.  This is the spatial frequency of the wavelength and is in cycles per cm.
*/
#define MIRcatSDK_UNITS_MICRONS                             ((uint8_t)1)
#define MIRcatSDK_UNITS_CM1                                 ((uint8_t)2)


/* Group: Modes */


/* Constants: Laser Modes
   This is the mode the laser uses for emission.  Not all modes are supported by all laser heads

   MIRcatSDK_MODE_PULSED - Pulsed laser mode.  The laser pulses on/off at the set repetition rate and pulse width.
   MIRcatSDK_MODE_CW - Continuous Waveform Mode.  In this mode the laser emission is continuously on.
   MIRcatSDK_MODE_CW_MOD - Same as CW mode but with an analog modulation enable signal enabled.  This is only supported by laser heads that have a modulation enable input (such as MIRcat sleds).
   MIRcatSDK_MODE_CW_MR - Currently not supported in firmware.
   MIRcatSDK_MODE_CW_MR_MOD - Currently not supported in firmware.
   MIRcatSDK_MODE_CW_FLTR1 - desc
   MIRcatSDK_MODE_CW_FLTR2 - desc
   MIRcatSDK_MODE_CW_FLTR1_MOD - desc
*/

#define MIRcatSDK_MODE_ERROR                                ((uint8_t)0)
#define MIRcatSDK_MODE_PULSED                               ((uint8_t)1)
#define MIRcatSDK_MODE_CW                                   ((uint8_t)2)
#define MIRcatSDK_MODE_CW_MOD                               ((uint8_t)3)
#define MIRcatSDK_MODE_CW_MR                                ((uint8_t)6)	//currently not supported in firmware
#define MIRcatSDK_MODE_CW_MR_MOD                            ((uint8_t)7)	//currently not supported in firmware
#define MIRcatSDK_MODE_CW_FLTR1                             ((uint8_t)8)
#define MIRcatSDK_MODE_CW_FLTR2                             ((uint8_t)9)
#define MIRcatSDK_MODE_CW_FLTR1_MOD                         ((uint8_t)10)

/* Constant: Pulse Triggering Modes
   This is the laser triggering mode for controlling QCL on/off.

   MIRcatSDK_PULSE_MODE_INTERNAL - The laser internally controls pulse triggering based on set parameters.
   MIRcatSDK_PULSE_MODE_EXTERNAL_TRIGGER - The laser uses an external TTL trigger signal to control the start of a laser pulse.  The duration of the laser pulse is controlled by the laser pulse width setting.  A pulse is started on the rising edge of the external TTL signal with a jitter of up to 20 ns.
   MIRcatSDK_PULSE_MODE_EXTERNAL_PASSTHRU - This is similar to external trigger mode, but the laser output simply follows the external TTL signal, with limits.  CW lasers are not limited.  Pulsed only lasers are limited to BOTH their maximum pulse width and duty cycle.  This mode only uses combinational logic between the external TTL signal and the laser trigger enable to limit jitter to near zero.
   MIRcatSDK_PULSE_MODE_WAVELENGTH_TRIGGER - Description
*/
#define MIRcatSDK_PULSE_MODE_INTERNAL                       ((uint8_t)1)
#define MIRcatSDK_PULSE_MODE_EXTERNAL_TRIGGER               ((uint8_t)2)
#define MIRcatSDK_PULSE_MODE_EXTERNAL_PASSTHRU              ((uint8_t)3)
#define MIRcatSDK_PULSE_MODE_WAVELENGTH_TRIGGER             ((uint8_t)4)


/* Constant: Process Triggering Modes
   For step scan modes (Step & Measure and Multi-Spectral) a process trigger is used to go to the next step in the scan.  The system provides the option to use three different types of process trigger modes below.

   MIRcatSDK_PROC_TRIG_MODE_INTERNAL - Laser controller controls all timing for step scan modes.
   MIRcatSDK_PROC_TRIG_MODE_EXTERNAL - External trigger on MIRcat 9-pin I/O connector must be provided to advance to next step.  Signal must be pulled low for ~250 ms to trigger a step.
   MIRcatSDK_PROC_TRIG_MODE_MANUAL  - Manual trigger command from PC must be sent to advance to next step.
*/
#define MIRcatSDK_PROC_TRIG_MODE_INTERNAL                   ((uint8_t)1)
#define MIRcatSDK_PROC_TRIG_MODE_EXTERNAL                   ((uint8_t)2)
#define MIRcatSDK_PROC_TRIG_MODE_MANUAL                     ((uint8_t)3)


#ifdef __cplusplus
extern "C" {
#endif

/* Section: Functions */

/* Group: Communication Functions */

/* Function: GetAPIVersion
 *	Get Version of the API.
 *
 *	Parameters:
 *		papiVersionMajor - (out) Major Version of MIRcat API.
 *		papiVersionMinor - (out) Minor Version of MIRcat API.
 *		papiVersionPatch - (out) Patch Version of MIRcat API.
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS*
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetAPIVersion(uint16_t *papiVersionMajor,
                                            uint16_t *papiVersionMinor,
                                            uint16_t *papiVersionPatch);

/* Function: SetCommType
 *	Set the communications type.
 *
 *	Parameters:
 *		commType - Communications Interface Type.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If setting communication type if
 *successful. MIRcatSDK_RET_NOT_INITIALIZED - *[User Error]* If the controller
 *is not yet initialized. MIRcatSDK_RET_UNSUPPORTED_TRANSPORT - *[User Error]*
 *If the user specified `commType` is invalid.
 *
 *	See Also:
 *		<Communication Parameters>
 */
MIRCAT_LIB uint32_t MIRcatSDK_SetCommType(uint8_t commType);

/* Function: SetSerialParams
 *	Set Serial Port Parameters.
 *
 *	Parameters:
 *		port - COM port number.
 *		baud - Baud Rate.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If setting the serial port is
 *successful. MIRcatSDK_RET_NOT_INITIALIZED - *[User Error]* If the controller
 *is not yet initialized.
 *
 *	See Also:
 *		<Serial port parameters>
 *
 */
MIRCAT_LIB uint32_t MIRcatSDK_SetSerialParams(uint16_t port, uint32_t baud);

/* Function: CreateMIRcatObject
 *	Creates new MIRcat object.  If a previous call has been made to
 *MIRcatSDK_DeInitialize(), this function should be called before trying to call
 *other MIRcatSDK functions.
 *
 *	Returns:
 * 	MIRcatSDK_RET_SUCCESS - If creating MIRcatObject is successful.
 *		MIRcatSDK_RET_ALREADY_CREATED - *[User Error]* If the user
 *attempts to create a new MIRcatObject when an instance has already been
 *initialized.
 */
MIRCAT_LIB uint32_t MIRcatSDK_CreateMIRcatObject();

/*  Function: IsMIRcatObjectCreated
 *	Returns bool value indicating if MIRcat object has been created. The
 *object is destroyed following a call to MIRcatSDK_DeInitialize(). If it is
 *destroyed it must be created before any SDK function calls will be valid. A
 *call to MIRcatSDK_Initialize() will also create the object if it has been
 *destroyed.
 *
 *	Parameters:
 *		pbMIRcatObjectCreated - (out) The current MIRcat controller
 *object.
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS*.
 */
MIRCAT_LIB uint32_t
MIRcatSDK_IsMIRcatObjectCreated(bool *pbMIRcatObjectCreated);

/* Function: Initialize the API
 *	Initializes the API.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the MIRcat controller is successfully
 *initialized. MIRcatSDK_RET_INITIALIZATION_FAILURE - *[System Error]* If MIRcat
 *controller Initialization failed.
 */
MIRCAT_LIB uint32_t MIRcatSDK_Initialize();

/* Function: DeInitialize
 *	Disconnect and clean up ports/memory/threads associated with
 *initializing the MIRcatSDK. A call to this function requires a call to
 *MIRcatSDK_CreateMIRcatObject() or MIRcatSDK_Initialize() before any subsequent
 *calls to any SDK functions.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If DeInitializing the MIRcat controller
 *object was successful. MIRcatSDK_RET_NOT_INITIALIZED - *[User Error]* If user
 *tries to DeInitialize MIRcat object before controller initialized.
 */
MIRCAT_LIB uint32_t MIRcatSDK_DeInitialize();

/* Group: Information Functions */

/* Function: GetModelNumber
 *	Gets the model number of the MIRcat system.
 *
 *	Parameters:
 *		pszModelNumber - (out) Pointer to character array that will
 *contain model number after calling the function.  This array should be at
 *least 24 bytes. bSize - Size of pszModelNumber in bytes.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If retrieving the model number is
 *successful. MIRcatSDK_RET_NOT_INITIALIZED - If the controller is not yet
 *initialized. MIRcatSDK_RET_BUFFER_TOO_SMALL - *[User Error]* If the user
 *specified buffer is too small for the character array.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetModelNumber(char *pszModelNumber,
                                             uint8_t bSize);

/* Function: GetSerialNumber
 *	Gets the serial number of the MIRcat system
 *
 *	Parameters:
 *		pszSerialNumber - (out) Pointer to character array that will
 *contain serial number after calling the function.  This array should be at
 *least 24 bytes. bSize - Size of pszSerialNumber in bytes.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If retrieving the model number is
 *successful. MIRcatSDK_RET_NOT_INITIALIZED - If the controller is not yet
 *initialized. MIRcatSDK_RET_BUFFER_TOO_SMALL - *[User Error]* If the user
 *specified buffer is too small for the character array.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetSerialNumber(char *pszSerialNumber,
                                              uint8_t bSize);

/* Function: GetTuningRange
 *	Gets the tuning range of the MIRcat system.
 *
 *	Parameters:
 *		pfMinRange - (out) Minimum wavelength of the MIRcat system
 *		pfMaxRange - (out) Maximum wavelength of the MIRcat system.
 *		pbUnits - (out) Units for the min/max wavelength of the MIRcat
 *system.
 *
 *	See Also:
 *		<Units>
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetTuningRange(float *pfMinRange,
                                             float *pfMaxRange,
                                             uint8_t *pbUnits);

/* Function: GetNumInstalledQcls
 *	Gets the number of QCLs installed in the MIRcat system.
 *
 *	Parameters:
 *		pbNumQcls - (out) Number of installed QCLs
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetNumInstalledQcls(uint8_t *pbNumQcls);

/* Function: GetQclTuningRange
 *	Gets the tuning range of a particular QCL the MIRcat system.
 *
 *	Parameters:
 *		bQcl - QCL for which to get the tuning range, indexed 1-4.
 *		pfMinRange - (out) Minimum wavelength of the MIRcat system
 *		pfMaxRange - (out) Maximum wavelength of the MIRcat system.
 *		pbUnits - (out) Units for the min/max wavelength of the MIRcat
 *system.
 *
 *	See Also:
 *		<Units>
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the tuning range of the user specified
 *QCL is properly retrieved. MIRcatSDK_RET_NOT_INITIALIZED - If the MIRcat
 *controller is not yet initialized. MIRcatSDK_RET_QCL_NUM_OUTOFRANGE - *[User
 *Error]* If the user specified QCL is out of range. Must be 1-4.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetQclTuningRange(uint8_t bQcl, float *pfMinRange,
                                                float *pfMaxRange,
                                                uint8_t *pbUnits);


/* Function: GetHoursOfOperation
*	Gets the hours of operation for the lasers in the system.
*
*	Parameters:
*		hours - (out) Gets the sum total of laser hours of operation for all laser channels.
*
*	Returns:
*		MIRcatSDK_RET_SUCCESS - If the tuning range of the user specified QCL is properly retrieved. 
*		MIRcatSDK_RET_NOT_INITIALIZED - If the MIRcat controller is not yet initialized. 		
*/
MIRCAT_LIB uint32_t MIRcatSDK_GetHoursOfOperation(float *hours);

/* Group: Status APIs */

/* Function: isConnectedToLaser
 *	Is there a valid connection to the laser?
 *
 *	Parameters:
 *		pbConnected - (out) Bool value that indicates if the API is
 *connected to the MIRcat system.
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_IsConnectedToLaser(bool *pbConnected);

/* Function: IsInterlockedStatusSet
 *	Is the interlock set?
 *
 *	Parameters:
 *		pbSet - (out) Bool value that indicates if the interlock circuit
 *is closed.
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_IsInterlockedStatusSet(bool *pbSet);

/* Function: IsKeySwitchStatusSet
 *	Is the laser emission on?
 *
 *	Parameters:
 *		pbSet - (out) Bool value that indicates if the key switch is in
 *the ON position.
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_IsKeySwitchStatusSet(bool *pbSet);

/* Function: IsEmissionOn
 *	Is the laser emission on?
 *
 *	Parameters:
 *		pbIsOn - (out) Bool value that indicates if the laser is currently
 *emitting light.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system is successfully able to
 *return a value. MIRcatSDK_RET_NOT_INITIALIZED - If the MIRcat controller is
 *not yet initialized. MIRcatSDK_RET_COMM_ERROR - If the MIRcat controller is
 *unable to Read Info regarding the light from the system.
 */
MIRCAT_LIB uint32_t MIRcatSDK_IsEmissionOn(bool *pbIsOn);

/* Function: IsLaserArmed
 *	Is the laser armed?
 *
 *	Parameters:
 *		pbIsArmed - (out) Bool value that indicates if the laser is
 *armed
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_IsLaserArmed(bool *pbIsArmed);

/* Function: IsSystemError
 *	Is there a system error?
 *
 *	Parameters:
 *		pbIsError - (out) Bool value that indicates if there is a system
 *error.
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_IsSystemError(bool *pbIsError);

/* Function: ClearSystemError
 *	Attempt to clear system error.  If the error cannot be cleared it is
 *likely a serious system error.
 *
 *	Parameters:
 *		pbErrorCleared - (out) Bool value that indicates the error could
 *be cleared.
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_ClearSystemError(bool *pbErrorCleared);

/* Function: AreTECsAtSetTemperature
 *	Are all of the TECs at the set temperature?
 *
 *	Parameters:
 *		pbIsAtSetTemperature - (out) Bool value that indicates if the TECs
 *are at the set temperatures.
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_AreTECsAtSetTemperature(bool *pbIsAtSetTemperature);

/* Function: GetSystemErrorWord
 *	Gets the system error word.
 *
 *	Parameters:
 *		pwErrorWord - (out) 16-bit error code.  See user's manual for a
 *list of error codes.
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetSystemErrorWord(uint16_t *pwErrorWord);

/* Function: GetWWDisplayUnits
 *	Gets the wavelength display units specified in the laser settings.
 *
 *	Parameters:
 *		pbDisplayUnits - (out) Display units for wavelength in the laser
 *settings.
 *
 *	See Also:
 *		<Units>
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetWWDisplayUnits(uint8_t *pbDisplayUnits);

/* Function: GetScanStatus
 *	Gets the status of the current scan/tune.
 *
 *	Parameters:
 *		pbIsScanInProgress - (out) Bool value that indicates if the scan
 *is in progress. pbIsScanActive - (out) Bool value that indicates if the scan
 *is active. pbIsScanPaused - (out) Bool value that indicates if the scan is
 *paused. pwCurScanNum - (out) Current scan number in repeated scan sequence.
 *		pwCurrentScanPercent - (out) Current scan percentage completed.
 *		pfCurrentWW - (out) Current wavelength of the laser.
 *		pbUnits - (out) Wavelength units.
 *		pbIsTECInProgress - (out) Bool value that indicates if the laser
 *is waiting for a TEC to get to the target temperature before firing.
 *		pbIsMotionInProgress - (out) Bool value that indicates if a QCL is
 *currently tuning.
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetScanStatus(
    bool *pbIsScanInProgress, bool *pbIsScanActive, bool *pbIsScanPaused,
    uint16_t *pwCurScanNum, uint16_t *pwCurrentScanPercent, float *pfCurrentWW,
    uint8_t *pbUnits, bool *pbIsTECInProgress, bool *pbIsMotionInProgress);

/* Function: GetScanWaitingProcessTrigger
 *	Is the system waiting for a user trigger?
 *
 *	Parameters:
 *		bWaitProcTrig - (out) Bool value that indicates whether the system
 *is waiting for a user trigger.
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetScanWaitingProcessTrigger(bool *bWaitProcTrig);

/* Function: GetActiveQcl
 *	Gets the active QCL during a scan/tune.
 *
 *	Parameters:
 *		pbActiveQcl - (out) The QCL that is active during this part of the
 *scan/tune.
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetActiveQcl(uint8_t *pbActiveQcl);

/* Group: Utility Functions */

/* Function: ConvertWW
 *	Converts the wavelength from from cm-1 to microns and vice-versa.
 *
 *	Parameters:
 *		fWW - The wavelength to convert.
 *		bcurrentUnits - The units to convert from.
 *		bnewUnits -  The units to convert to.
 *		pfConvertedWW - (out) The value of the converted units.
 *
 *	See Also:
 *		<Units>
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS*
 */
MIRCAT_LIB uint32_t MIRcatSDK_ConvertWW(float fWW, uint8_t bcurrentUnits,
                                        uint8_t bnewUnits,
                                        float *pfConvertedWW);

/* Group: Arm/Disarm Laser */

/* Function: ArmLaser
 *	Arms the Laser.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully arms the
 *laser. MIRcatSDK_RET_NOT_INITIALIZED - If the MIRcat controller is not yet
 *initialized. MIRcatSDK_RET_LASER_ALREADY_ARMED - *[User Error]* If the user
 *attempts to arm the laser when it has already been armed.
 *		MIRcatSDK_RET_INTERLOCKS_KEYSWITCH_NOTSET - *[User Error]* If the
 *interlock status is not set or the key switch is not set.
 *		MIRcatSDK_RET_ARMDISARM_FAILURE - *[System Error]* If the system
 *fails to arm the laser.
 */
MIRCAT_LIB uint32_t MIRcatSDK_ArmLaser();

/* Function: DisarmLaser
 *	Disarm the Laser.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully disarms the
 *laser. MIRcatSDK_RET_NOT_INITIALIZED - If the MIRcat controller is not yet
 *initialized. MIRcatSDK_RET_LASER_ALREADY_ARMED - *[User Error]* If the user
 *attempts to disarm the laser when it has already been disarmed.
 *		MIRcatSDK_RET_INTERLOCKS_KEYSWITCH_NOTSET - *[User Error]* If the
 *interlock status is not set or the key switch is not set.
 *		MIRcatSDK_RET_ARMDISARM_FAILURE - *[System Error]* If the system
 *fails to disarm the laser.
 */
MIRCAT_LIB uint32_t MIRcatSDK_DisarmLaser();

/* Function: ArmDisarmLaser
 *	Toggle the armed state of the laser based on the current state (i.e., if
 *the laser is disarmed, this command will arm it and vice versa).
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully toggled laser
 *arming. MIRcatSDK_RET_NOT_INITIALIZED - If the MIRcat controller is not yet
 *initialized. MIRcatSDK_RET_INTERLOCKS_KEYSWITCH_NOTSET - *[User Error]* If the
 *interlock status is not set or the key switch is not set.
 *		MIRcatSDK_RET_ARMDISARM_FAILURE - *[System Error]* If the system
 *fails to toggle laser arming.
 */
MIRCAT_LIB uint32_t MIRcatSDK_ArmDisarmLaser();

/* Group: General Scan Operations */

/* Function: StopScanInProgress
 *	Stops the current scan.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the scan is successfully stopped.
 *		MIRcatSDK_RET_NOT_INITIALIZED - If the MIRcat controller is not
 *yet initialized. MIRcatSDK_RET_STOP_SCAN_FAILURE - *[System Error]* If the
 *system fails to successfully stop the scan in progress.
 *		MIRcatSDK_RET_NO_SCAN_INPROGRESS - *[User Error]* If the user
 *attempts to stop a scan when there is no current scan in progress.
 */
MIRCAT_LIB uint32_t MIRcatSDK_StopScanInProgress();

/* Function: PauseScanInProgress
 *	Pauses the current scan.  This function sends a pause command to the
 *laser, but currently the laser does not support pausing of a scan.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system is successfully able to
 *pause the scan in progress. MIRcatSDK_RET_NOT_INITIALIZED - If the MIRcat
 *controller is not yet initialized. MIRcatSDK_RET_PAUSE_SCAN_FAILURE - *[System
 *Error]* If the system fails to pause the scan in progress.
 *		MIRcatSDK_RET_NO_SCAN_INPROGRESS - *[User Error]* If the user
 *attempts to pause a scan when there is no current scan in progress.
 */
MIRCAT_LIB uint32_t MIRcatSDK_PauseScanInProgress();

/* Function: ResumeScanInProgress
 *	Resumes the current scan.  This function sends a resume command to the
 *laser, but currently the laser does not support pausing of a scan, so will not
 *resume.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system is successfully able to
 *resume the scan in progress. MIRcatSDK_RET_NOT_INITIALIZED - If the MIRcat
 *controller is not yet initialized. MIRcatSDK_RET_RESUME_SCAN_FAILURE -
 **[System Error]* If the system fails to resume the scan in progress.
 *		MIRcatSDK_RET_NO_SCAN_INPROGRESS - *[User Error]* If the user
 *attempts to resume a scan when there is no current scan in progress.
 */
MIRCAT_LIB uint32_t MIRcatSDK_ResumeScanInProgress();

/* Function: ManualStepScanInProgress
 *	Tells the laser to go to the next step in a Step and Measure or
 *Multi-Spectral scan if the process trigger mode is set to Manual.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - The system successfully moves to the next
 *step. MIRcatSDK_RET_NOT_INITIALIZED - If the MIRcat controller is not yet
 *initialized. MIRcatSDK_RET_MANUAL_STEP_SCAN_FAILURE - *[System Error]* If the
 *system fails to manually move to the next step.
 *		MIRcatSDK_RET_NO_SCAN_INPROGRESS - *[User Error]* If the user
 *attempts to manually step a scan when there is no current scan in progress.
 */
MIRCAT_LIB uint32_t MIRcatSDK_ManualStepScanInProgress();

/* Group: Tune APIs */

// TODO: RudyB 5/23/17 - Is this function in the right group? This does not look
// like a tuning API function?
/* Function: GetActualWW
 *	Gets the actual tuned wavelength.  This can be used during a sweep or
 *tune to indicate when target is reached.
 *
 *	Parameters:
 *		pfActualWW - (out) The actual wavelength the laser is currently
 *tuned to. pbUnits - (out) The wavelength units for the tuning. pbLightValid -
 *(out) Indicates if laser light is valid (tuned and emitting).
 *
 *	See Also:
 *		<Units>
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - Reason
 *		MIRcatSDK_RET_NOT_INITIALIZED - If the MIRcat controller is not
 *yet initialized. MIRcatSDK_RET_COMM_ERROR - If the MIRcat controller is unable
 *to Read Info regarding the light from the system.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetActualWW(float *pfActualWW, uint8_t *pbUnits,
                                          bool *pbLightValid);

/* Function: GetTuneWW
 *	Gets the currently tuned target wavelength.
 *
 *	Parameters:
 *		pfTuneWW - (out) The wavelength the laser is currently tuned to.
 *		pbUnits - (out) The wavelength units for the tuning.
 *		pbPreferredQcl - (out) The preferred QCL as specified in the last
 *TuneToWW command indexed 1-4.  A value of 0 indicates no preferred QCL.
 *
 *	See Also:
 *		<Units>
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - Reason
 *		MIRcatSDK_RET_NOT_INITIALIZED - If the MIRcat controller is not
 *yet initialized. ReturnItem - Reason
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetTuneWW(float *pfTuneWW, uint8_t *pbUnits,
                                        uint8_t *pbPreferredQcl);

/* Function: TuneToWW
 *	Tune the laser to the specified wavelength with a preferred QCL.
 *
 *	Parameters:
 *		fTuneWW - The target wavelength to tune the laser to.
 *		bUnits - The wavelength units for tuning the laser.
 *		bPreferredQcl - The preferred QCL for this tune command indexed
 *1-4.  A value of 0 indicates no preferred QCL.
 *
 *	See Also:
 *		<Units>
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system is successfully able to tune
 *to the user specified wavelength. MIRcatSDK_RET_NOT_INITIALIZED - If the
 *MIRcat controller is not yet initialized.
 *		MIRcatSDK_RET_TECS_NOT_AT_SET_TEMPERATURE - *[System Error]* If
 *the system is not operating at the set temperature.
 *		MIRcatSDK_RET_STARTTUNE_FAILURE - *[System Error]* If the system
 *fails to tune the laser to the user specified wavelength.
 *		MIRcatSDK_RET_LASER_NOT_ARMED - *[User Error]* If the user
 *attempts to tune the laser when the laser is not yet armed.
 *		MIRcatSDK_RET_WW_OUTOFTUNINGRANGE - *[User Error]* If the user
 *specified wavelength is out of the valid range.
 */
MIRCAT_LIB uint32_t MIRcatSDK_TuneToWW(float fTuneWW, uint8_t bUnits,
                                       uint8_t bPreferredQcl);

/* Function: IsTuned
 *	Is the laser tuned?
 *
 *	Parameters:
 *		pbIsTuned - (out) Bool value that indicates if the laser is
 *currently tuned.
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_IsTuned(bool *pbIsTuned);

/* Function: CancelManualTuneMode
 *	Cancel the current single tune.  If the laser is tuned in single tune
 *mode, this command must be sent before performing a scan.
 *
 *	See Also:
 *		<StopScanInProgress>
 *
 *	Returns:
 *		Returns the output of *MIRcatSDK_StopScanInProgress*
 */
MIRCAT_LIB uint32_t MIRcatSDK_CancelManualTuneMode();

/* Function: TurnEmissionOn
 *	Turns laser emission on.  Laser must have been tuned to a wavelength
 *prior to sending this command.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system is successfully able to
 *enable the laser emission. MIRcatSDK_RET_NOT_INITIALIZED - *[User Error]* If
 *the MIRcat controller is not yet initialized. MIRcatSDK_RET_LASER_NOT_ARMED -
 **[User Error]* If the user attempts to enable laser emission before the laser
 *is armed. MIRcatSDK_RET_EMISSION_ALREADY_ON - *[User Error]* If the user
 *attempts to enable the laser emission while the laser is already emitting.
 *		MIRcatSDK_RET_LASER_NOT_TUNED - *[User Error]* If the user
 *attempts to enable laser emission before tuning the laser.
 *		MIRcatSDK_RET_EMISSION_ON_FAILURE - *[System Error]* If the system
 *fails to enable the laser emission.
 */
MIRCAT_LIB uint32_t MIRcatSDK_TurnEmissionOn();

/* Function: TurnEmissionOff
 *	Turns laser emission off.  If the laser emission is already off, this
 *will return error *MIRcatSDK_RET_EMISSION_ALREADY_OFF*.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system is successfully able to
 *disable the laser emission. MIRcatSDK_RET_NOT_INITIALIZED - *[User Error]* If
 *the MIRcat controller is not yet initialized.
 *		MIRcatSDK_RET_EMISSION_ALREADY_OFF - *[User Error]* If the user
 *attempts to diable laser emission when it is already disabled.
 *		MIRcatSDK_RET_EMISSION_OFF_FAILURE - *[System Error]* If the
 *system fails to disable the laser emission.
 */
MIRCAT_LIB uint32_t MIRcatSDK_TurnEmissionOff();

/* Group Sweep APIs */

/* Function: GetSweepStartWW
 *	Gets the sweep start wavelength from the last sweep scan.
 *
 *	Parameters:
 *		pfStartWW - (out) Start wavelength of the last scan.
 *		pbUnits - (out) Wavelength units.
 *
 *	See Also:
 *		<Units>
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetSweepStartWW(float *pfStartWW,
                                              uint8_t *pbUnits);

/* Function: GetSweepStopWW
 *	Gets the sweep stop wavelength from the last sweep scan.
 *
 *	Parameters:
 *		pfStopWW - (out) Stop wavelength of the last scan.
 *		pbUnits - (out) Wavelength units.
 *
 *	See Also:
 *		<Units>
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetSweepStopWW(float *pfStopWW, uint8_t *pbUnits);

/* Function: GetSweepScanSpeed
 *	Gets the sweep speed in the indicated units per second from the last
 *sweep scan.
 *
 *	Parameters:
 *		pfScanSpeed - (out) Scan speed in units per second.
 *		pbUnits - (out) Wavelength units.
 *
 *	See Also:
 *		<Units>
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetSweepScanSpeed(float *pfScanSpeed,
                                                uint8_t *pbUnits);

/* Function: GetSweepNumScans
 *	Gets the number of iterations to be performed for this scan.
 *
 *	Parameters:
 *		pwNumScans - (out) Number of scan iterations to be performed.
 *Note: A bi-directional scan will count the scan up and scan down as a single
 *scan.
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetSweepNumScans(uint16_t *pwNumScans);

/* Function: IsSweepBidirectional
 *	Is this scan bi-directional?
 *
 *	Parameters:
 *		pbIsBidirectional - (out) Bool value indicating if this scan is
 *bi-directional.
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_IsSweepBidirectional(bool *pbIsBidirectional);

/* Function: StartSweepScan
 *	Starts a sweep scan with the specified parameters.
 *
 *	Parameters:
 *		fStartWW - Start wavelength for this scan.
 *		fStopWW - Stop wavelength for this scan.
 *		fScanSpeed - Scan speed in specified units per second.
 *		bUnits - Wavelength units for this scan.
 *		wNumScans - Number of iterations of this scan to perform.
 *		bIsBiDirectional - Bool value indicating if this scan is
 *bi-directional. u8PreferredQcl - The preferred QCL for this sweep scan command
 *indexed 1-4.  A value of 0 indicates no preferred QCL.  If there is a
 *preferred QCL, the scan will switch to this QCL as soon as possible and stay
 *on this QCL as long as possible.
 *
 *	See Also:
 *		<Units>
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully starts a Sweep
 *Scan. MIRcatSDK_RET_NOT_INITIALIZED - *[User Error]* If the MIRcat controller
 *is not yet initialized. MIRcatSDK_RET_LASER_NOT_ARMED - *[User Error]* If the
 *user attempts to enable laser emission before the laser is armed.
 *		MIRcatSDK_RET_WW_OUTOFTUNINGRANGE - *[User Error]* If the user
 *specified wavelength is out of the valid range.
 *		MIRcatSDK_RET_START_SWEEPSCAN_FAILURE - *[System Error]* If the
 *system fails to start a Sweep Scan. MIRcatSDK_RET_TECS_NOT_AT_SET_TEMPERATURE
 *- *[System Error]* If the system is not operating at the set temperature.
 */
MIRCAT_LIB uint32_t MIRcatSDK_StartSweepScan(float fStartWW, float fStopWW,
                                             float fScanSpeed, uint8_t bUnits,
                                             uint16_t wNumScans,
                                             bool bIsBiDirectional,
                                             uint8_t u8PreferredQcl);

/* Group: STEP & MEASURE APIs */

/* Function: GetStepMeasureStartWW
 *	Gets the Step and Measure start wavelength from the last Step and
 *Measure scan.
 *
 *	Parameters:
 *		pfStartWW - (out) Start wavelength of the last scan.
 *		pbUnits - (out) Wavelength units.
 *
 *	See Also:
 *		<Units>
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetStepMeasureStartWW(float *pfStartWW,
                                                    uint8_t *pbUnits);

/* Function: GetStepMeasureStopWW
 *	Gets the Step and Measure stop wavelength from the last Step and Measure
 *scan.
 *
 *	Parameters:
 *		pfStopWW - (out) Stop wavelength of the last scan.
 *		pbUnits - (out) Wavelength units.
 *
 *	See Also:
 *		<Units>
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetStepMeasureStopWW(float *pfStopWW,
                                                   uint8_t *pbUnits);

/* Function: GetStepMeasureStepSizeWW
 *	Gets the Step and Measure step size from the last Step and Measure scan.
 *
 *	Parameters:
 *		pfStepSize - (out) Step size in the specified units.
 *		pbUnits - (out) Wavelength units.
 *
 *	See Also:
 *		<Units>
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetStepMeasureStepSizeWW(float *pfStepSize,
                                                       uint8_t *pbUnits);

/* Function: GetStepMeasureNumScans
 *	Gets the number of iterations for the Step and Measure scan.
 *
 *	Parameters:
 *		pwNumScans - (out) Number of scan iterations.
 *
 *	See Also:
 *		<Units>
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetStepMeasureNumScans(uint16_t *pwNumScans);

/* Function: StartStepMeasureModeScan
 *	Starts a Step and Measure scan with the specified parameters.
 *
 *	Parameters:
 *		fStart - Start wavelength in the specified units.
 *		fStop - Stop wavelength in the specified units.
 *		fStepSize - Step size in the specified units.
 *		bUnits - Wavelength units.
 *		wNumScans - Number of iterations to be performed for this scan.
 *
 *	See Also:
 *		<Units>
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully starts a step
 *and measure scan. MIRcatSDK_RET_NOT_INITIALIZED - *[User Error]* If the MIRcat
 *controller is not yet initialized. MIRcatSDK_RET_LASER_NOT_ARMED - *[User
 *Error]* If the user attempts to enable laser emission before the laser is
 *armed. MIRcatSDK_RET_WW_OUTOFTUNINGRANGE - *[User Error]* If the user
 *specified wavelength is out of the valid range.
 *		MIRcatSDK_RET_TECS_NOT_AT_SET_TEMPERATURE - *[System Error]* If
 *the system is not operating at the set temperature.
 *		MIRcatSDK_RET_START_STEPMEASURESCAN_FAILURE - *[System Error]* If
 *the system fails to start a step and measure scan.
 */
MIRCAT_LIB uint32_t MIRcatSDK_StartStepMeasureModeScan(float fStart,
                                                       float fStop,
                                                       float fStepSize,
                                                       uint8_t bUnits,
                                                       uint16_t wNumScans);

/* Group: MULTI-SPECTRAL APIs */

/* Function: GetNumMultiSpectralElements
 *	Gets the number of elements in the last Multi-Spectral scan.
 *
 *	Parameters:
 *		pbNumElements - (out) Number of elements in the Multi-Spectral
 *scan.
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t
MIRcatSDK_GetNumMultiSpectralElements(uint8_t *pbNumElements);

/* Function: GetMultiSpectralElement
 *	Gets the parameters for the specified element in a Multi-Spectral scan.
 *
 *	Parameters:
 *		bIndex - Element index.
 *		pfScanWW - (out) Element wavelength.
 *		pdwDwellTime - (out) Element dwell time.
 *		pdwOffTime - (out) Element off time.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully gets the
 *parameters for the user specified element MIRcatSDK_RET_NOT_INITIALIZED -
 **[User Error]* If the MIRcat controller is not yet initialized.
 *		MIRcatSDK_RET_INDEX_OUTOFBOUNDS - *[User Error]* If the user
 *specified Element Index is invalid and out of index bounds.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetMultiSpectralElement(uint8_t bIndex,
                                                      float *pfScanWW,
                                                      uint32_t *pdwDwellTime,
                                                      uint32_t *pdwOffTime);

/* Function: GetMultiSpectralWWUnits
 *	Gets the wavelength units for the last Multi-Spectral scan.
 *
 *	Parameters:
 *		pbUnits - (out) Wavelength units for the Multi-Spectral scan.
 *
 *	See Also:
 *		<Units>
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetMultiSpectralWWUnits(uint8_t *pbUnits);

/* Function: GetMultiSpectralNumScans
 *	Gets the number of iterations for the last Multi-Spectral scan.
 *
 *	Parameters:
 *		pwNumScans - (out) Number of scan iterations.
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetMultiSpectralNumScans(uint16_t *pwNumScans);

/* Function: SetNumMultiSpectralElements
 *	Sets the number of elements for a Multi-Spectral scan.
 *
 *	Parameters:
 *		bNumElements - Number of elements in a Multi-Spectral scan.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully sets the number
 *of elements for a Multi-Spectral scan. MIRcatSDK_RET_NOT_INITIALIZED - *[User
 *Error]* If the MIRcat controller is not yet initialized.
 *		MIRcatSDK_RET_TOO_MANY_ELEMENTS - *[User Error]* The user
 *specified number of elements is too large.
 */
MIRCAT_LIB uint32_t MIRcatSDK_SetNumMultiSpectralElements(uint8_t bNumElements);

/* Function: AddMultiSpectralElement
 *	Adds a Multi-Spectral scan element to the end of the element list.
 *
 *	Parameters:
 *		fScanWW - Element wavelength.
 *		bUnits - Element wavelength units.
 *		dwDwellTime - Element dwell time.
 *		dwOffTime - Element off time.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully adds an element
 *to the end of the element list. MIRcatSDK_RET_NOT_INITIALIZED - *[User Error]*
 *If the MIRcat controller is not yet initialized.
 *		MIRcatSDK_RET_INDEX_OUTOFBOUNDS - *[User Error]* If the user
 *specified Element Index is invalid and out of index bounds.
 *		MIRcatSDK_RET_WW_OUTOFTUNINGRANGE - *[User Error]* If the user
 *specified wavelength is out of the valid range.
 */
MIRCAT_LIB uint32_t MIRcatSDK_AddMultiSpectralElement(float fScanWW,
                                                      uint8_t bUnits,
                                                      uint32_t dwDwellTime,
                                                      uint32_t dwOffTime);

/* Function: StartMultiSpectralModeScan
 *	Starts a Multi-Spectral scan with the specified number of iterations.
 *The elements for this scan must have been setup previously.
 *
 *	Parameters:
 *		wNumScans - Number of iterations for this Multi-Spectral scan.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully starts a
 *Multi-Spectral Scan. MIRcatSDK_RET_NOT_INITIALIZED - *[User Error]* If the
 *MIRcat controller is not yet initialized. MIRcatSDK_RET_LASER_NOT_ARMED -
 **[User Error]* If the user attempts to enable laser emission before the laser
 *is armed. MIRcatSDK_RET_NOT_ENOUGH_ELEMENTS - *[User Error]* If the user does
 *not define enough Multi-Spectral scan elements.
 *		MIRcatSDK_RET_TECS_NOT_AT_SET_TEMPERATURE - *[System Error]* If
 *the system is not operating at the set temperature.
 *		MIRcatSDK_RET_START_MULTISPECTRALSCAN_FAILURE - *[System Error]*
 *If the system fails to start a Multi-Spectral Scan.
 *
 */
MIRCAT_LIB uint32_t MIRcatSDK_StartMultiSpectralModeScan(uint16_t wNumScans);

/* Group: Favorites APIs */

/* Function: GetNumFavorites
 *	Gets the number of user favorites that have been saved in the laser
 *memory.
 *
 *	Parameters:
 *		pbNumFavorites - (out) Number of favorites saved in the laser
 *memory.
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetNumFavorites(uint8_t *pbNumFavorites);

/* Function: GetFavoriteName
 *	Gets the name of the favorite at the specified index.
 *
 *	Parameters:
 *		bIndex - Index of the favorite.
 *		pszFavoriteName - (out) Name of the favorite.  This character
 *array should be 32 bytes. bSize - Length in bytes of the favorite name.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully gets the name
 *of the favorite at the user specified index. MIRcatSDK_RET_NOT_INITIALIZED -
 **[User Error]* If the MIRcat controller is not yet initialized.
 *		MIRcatSDK_RET_INDEX_OUTOFBOUNDS - *[User Error]* If the user
 *specified index is invalid and out of bounds. MIRcatSDK_RET_BUFFER_TOO_SMALL -
 **[User Error]* If the user specified buffer is too small for the character
 *array.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetFavoriteName(uint8_t bIndex,
                                              char *pszFavoriteName,
                                              uint8_t bSize);

/* Function: RecallFavorite
 *	Recalls the favorite with the given name.
 *
 *	Parameters:
 *		pszFavoriteName - Name of the favorite to recall.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully recalls the
 *favorite with the user specified name. MIRcatSDK_RET_NOT_INITIALIZED - *[User
 *Error]* If the MIRcat controller is not yet initialized.
 *		MIRcatSDK_RET_FAVORITE_NAME_NOTRECOGNIZED - *[User Error]* If the
 *user specifies an invalid favorite name. MIRcatSDK_RET_FAVORITE_RECALL_FAILURE
 *- *[System Error]* If the system fails to recall the favorite with the user
 *specified name.
 */
MIRCAT_LIB uint32_t MIRcatSDK_RecallFavorite(char *pszFavoriteName);

/* Group: SETTINGS APIs

        All QCLs are indexed starting from 1.

*/

/* Function: GetQCLPulseRate
 *	Gets the pulse rate of the specified QCL in Hz.
 *
 *	Parameters:
 *		bQcl - QCL number indexed from 1.
 *		pfPulseRateInHz - (out) Pulse Rate in Hz.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully gets the pulse
 *rate of the specified QCL. MIRcatSDK_RET_NOT_INITIALIZED - *[User Error]* If
 *the MIRcat controller is not yet initialized. MIRcatSDK_RET_QCL_NUM_OUTOFRANGE
 *- *[User Error]* If the user specified QCL is out of range. Must be 1-4.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetQCLPulseRate(uint8_t bQcl,
                                              float *pfPulseRateInHz);

/* Function: GetQCLPulseWidth
 *	Gets the pulse width of the specified QCL in ns.
 *
 *	Parameters:
 *		bQcl - QCL number indexed from 1.
 *		pfPulseWidthInNanoSec - (out) Pulse Width in ns.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully gets the pulse
 *width of the specified QCL. MIRcatSDK_RET_NOT_INITIALIZED - *[User Error]* If
 *the MIRcat controller is not yet initialized. MIRcatSDK_RET_QCL_NUM_OUTOFRANGE
 *- *[User Error]* If the user specified QCL is out of range. Must be 1-4.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetQCLPulseWidth(uint8_t bQcl,
                                               float *pfPulseWidthInNanoSec);

/* Function: GetQCLCurrent
 *	Gets the current setting of the specified QCL in mA.
 *
 *	Parameters:
 *		bQcl - QCL number indexed from 1.
 *		pfCurrentInMilliAmps - (out) Current setting in mA.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully gets the QCL
 *Current of the specified QCL. MIRcatSDK_RET_NOT_INITIALIZED - *[User Error]*
 *If the MIRcat controller is not yet initialized.
 *		MIRcatSDK_RET_QCL_NUM_OUTOFRANGE - *[User Error]* If the user
 *specified QCL is out of range. Must be 1-4.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetQCLCurrent(uint8_t bQcl,
                                            float *pfCurrentInMilliAmps);

/* Function: SetQCLParams
 *	Set the operating parameters for the specified QCL.
 *
 *	Parameters:
 *		bQcl - QCL number indexed from 1.
 *		fPulseRateInHz - Pulse rate in Hz.
 *		fPulseWidthInNanoSec - Pulse width in ns.
 *		fCurrentInMilliAmps - Current in mA.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - Reason
 *		MIRcatSDK_RET_NOT_INITIALIZED - *[User Error]* If the MIRcat
 *controller is not yet initialized. MIRcatSDK_RET_QCL_NUM_OUTOFRANGE - *[User
 *Error]* If the user specified QCL is out of range. Must be 1-4.
 *		MIRcatSDK_RET_PULSERATE_OUTOFRANGE - *[User Error]* If the user
 *specified pulse rate is invalid and out of range.
 *		MIRcatSDK_RET_PULSEWIDTH_OUTOFRANGE - *[User Error]* If the user
 *specified pulse width is invalid and out of range.
 *		MIRcatSDK_RET_CURRENT_OUTOFRANGE - *[User Error]* If the user
 *specifies an invalid current that is out of range.
 *		MIRcatSDK_RET_SAVE_SETTINGS_FAILURE - *[System Error]* If the
 *system fails to save the QCL settings.
 */
MIRCAT_LIB uint32_t MIRcatSDK_SetQCLParams(uint8_t bQcl, float fPulseRateInHz,
                                           float fPulseWidthInNanoSec,
                                           float fCurrentInMilliAmps);

/* Function: GetQCLPulseLimits
 *	Gets the pulse limits for the specified QCL.
 *
 *	Parameters:
 *		bQcl - QCL number indexed from 1-4.
 *		pfpfPulseRateMaxInHz - (out) Maximum pulse rate in Hz.
 *		pfPulseWidthMaxInNanoSec - (out) Maximum pulse width in ns.
 *		pfDutyCycleMax - (out) Maximum pulsed duty cycle.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully gets the QCL
 *Pulse Limits of the specified QCL. MIRcatSDK_RET_NOT_INITIALIZED - *[User
 *Error]* If the MIRcat controller is not yet initialized.
 *		MIRcatSDK_RET_QCL_NUM_OUTOFRANGE - *[User Error]* If the user
 *specified QCL is out of range. Must be 1-4.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetQCLPulseLimits(uint8_t bQcl,
                                                float *pfpfPulseRateMaxInHz,
                                                float *pfPulseWidthMaxInNanoSec,
                                                float *pfDutyCycleMax);

/* Function: GetQCLMaxPulsedCurrent
 *	Gets the max pulsed current setting of the specified QCL in mA.
 *
 *	Parameters:
 *		bQcl - QCL number indexed from 1-4.
 *		pfCurrentInMilliAmps - (out) Maximum QCL current in mA.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully gets the QCL
 *Pulse Limits of the specified QCL. MIRcatSDK_RET_NOT_INITIALIZED - *[User
 *Error]* If the MIRcat controller is not yet initialized.
 *		MIRcatSDK_RET_QCL_NUM_OUTOFRANGE - *[User Error]* If the user
 *specified QCL is out of range. Must be 1-4.
 */
MIRCAT_LIB uint32_t
MIRcatSDK_GetQCLMaxPulsedCurrent(uint8_t bQcl, uint16_t *pfCurrentInMilliAmps);

/* Function: GetQCLMaxCwCurrent
 *	Gets the max CW current setting of the specified QCL in mA.
 *
 *	Parameters:
 *		bQcl - QCL number indexed from 1-4.
 *		pfCurrentInMilliAmps - (out) Maximum QCL current in mA.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully gets the Max
 *Pulse Current of the specified QCL. MIRcatSDK_RET_NOT_INITIALIZED - *[User
 *Error]* If the MIRcat controller is not yet initialized.
 *		MIRcatSDK_RET_QCL_NUM_OUTOFRANGE - *[User Error]* If the user
 *specified QCL is out of range. Must be 1-4.
 */
MIRCAT_LIB uint32_t
MIRcatSDK_GetQCLMaxCwCurrent(uint8_t bQcl, uint16_t *pfCurrentInMilliAmps);

/* Function: isCwAllowed
 *	Gets the status of CW being supported for this QCL.
 *
 *	Parameters:
 *		bQcl - QCL number indexed from 1-4.
 *		pbCwAllowed - (out) Bool value that indicates if CW is supported
 *on this channel.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully gets the status
 *of CW being supported for the specified QCL. MIRcatSDK_RET_NOT_INITIALIZED -
 **[User Error]* If the MIRcat controller is not yet initialized.
 *		MIRcatSDK_RET_QCL_NUM_OUTOFRANGE - *[User Error]* If the user
 *specified QCL is out of range. Must be 1-4.
 */
MIRCAT_LIB uint32_t MIRcatSDK_isCwAllowed(uint8_t bQcl, bool *pbCwAllowed);

/* Function: areCwFiltersInstalled
 *	Gets the status of CW filters being supported for this QCL.
 *
 *	Parameters:
 *		bQcl - QCL number indexed from 1-4.
 *		pbFiltersInstalled - (out) Bool value that indicates if CW filters
 *are installed on this channel.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully gets the status
 *of CW filters being supported for the specified QCL.
 *		MIRcatSDK_RET_NOT_INITIALIZED - *[User Error]* If the MIRcat
 *controller is not yet initialized. MIRcatSDK_RET_QCL_NUM_OUTOFRANGE - *[User
 *Error]* If the user specified QCL is out of range. Must be 1-4.
 */
MIRCAT_LIB uint32_t MIRcatSDK_areCwFiltersInstalled(uint8_t bQcl,
                                                    bool *pbFiltersInstalled);

/* Function: GetTecCurrent
 *	Gets the TEC current for the specified channel.
 *
 *	Parameters:
 *		bTec - TEC number indexed from 1-4.
 *		pfCurrentInMilliAmps - (out) TEC current in mA.  
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully gets the TEC
 *current for the specified TEC. MIRcatSDK_RET_NOT_INITIALIZED - *[User Error]*
 *If the MIRcat controller is not yet initialized.
 *		MIRcatSDK_RET_QCL_NUM_OUTOFRANGE - *[User Error]* If the user
 *specified QCL is out of range. Must be 1-4.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetTecCurrent(uint8_t bTec,
                                            int16_t *pfCurrentInMilliAmps);

/* Function: GetQCLTemperature
 *	Gets the QCL temperature for the specified channel.
 *
 *	Parameters:
 *		bQcl - QCL number indexed from 1-4.
 *		pfQclTemperature - (out) QCL temperature in degrees C.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully gets the QCL
 *temperature for the specified QCL. MIRcatSDK_RET_NOT_INITIALIZED - *[User
 *Error]* If the MIRcat controller is not yet initialized.
 *		MIRcatSDK_RET_QCL_NUM_OUTOFRANGE - *[User Error]* If the user
 *specified QCL is out of range. Must be 1-4.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetQCLTemperature(uint8_t bQcl, float *pfQclTemperature);

/* Function: GetQCLOperatingMode
 *	Gets the QCL operating mode for the specified channel.
 *
 *	Parameters:
 *		bQcl - QCL number indexed from 1-4.
 *		pbMode - (out) QCL operating mode.
 *
 *	See Also:
 *		<Laser Modes>
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully gets the QCL
 *operating mode for the specified channel. MIRcatSDK_RET_NOT_INITIALIZED -
 **[User Error]* If the MIRcat controller is not yet initialized.
 *		MIRcatSDK_RET_QCL_NUM_OUTOFRANGE - *[User Error]* If the user
 *specified QCL is out of range. Must be 1-4.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetQCLOperatingMode(uint8_t bQcl,
                                                  uint8_t *pbMode);

/* Function: GetQclSetTemperature
 *	Gets the QCL set temperature for the specified channel in degrees C.
 *
 *	Parameters:
 *		bQcl - QCL number indexed from 1-4.
 *		pfQclSetTemperature - (out) QCL set temperature.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully gets the QCL
 *set temperature for the specified channel. MIRcatSDK_RET_NOT_INITIALIZED -
 **[User Error]* If the MIRcat controller is not yet initialized.
 *		MIRcatSDK_RET_QCL_NUM_OUTOFRANGE - *[User Error]* If the user
 *specified QCL is out of range. Must be 1-4.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetQclSetTemperature(uint8_t bQcl, float *pfQclSetTemperature);

/* Function: GetQCLTemperatureRange
 *	Gets the QCL temperature range for the specified channel in degrees C.
 *
 *	Parameters:
 *		bQcl - QCL number indexed from 1-4.
 *		pfQclNominalTemperature - (out) QCL nominal factory temperature.
 *		pfQclMinTemperature - (out) QCL minimum temperature.
 *		pfQclMaxTemperature - (out) QCL maximum temperature.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully gets the QCL
 *temperature range for the specified channel. MIRcatSDK_RET_NOT_INITIALIZED -
 **[User Error]* If the MIRcat controller is not yet initialized.
 *		MIRcatSDK_RET_QCL_NUM_OUTOFRANGE - *[User Error]* If the user
 *specified QCL is out of range. Must be 1-4.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetQCLTemperatureRange(
    uint8_t bQcl, float *pfQclNominalTemperature, float *pfQclMinTemperature,
    float *pfQclMaxTemperature);

/* Function: SetAllQclParams
 *	Set all of the operating parameters for the specified QCL.
 *
 *	Parameters:
 *		bQcl - QCL number indexed from 1-4.
 *		fPulseRate - Pulse rate in Hz.
 *		fPulseWidth - Pulse width in ns.
 *		fCurrentInMilliAmps - Current in mA.
 *		fTemperature - Temperature in degrees Celsius.
 *		u8laserMode - Laser Mode (Pulsed, CW, or CW+Mod).
 *
 *	See Also:
 *		<Laser Modes>
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully sets and saves
 *the operating parameters for the specified QCL. MIRcatSDK_RET_NOT_INITIALIZED
 *- *[User Error]* If the MIRcat controller is not yet initialized.
 *		MIRcatSDK_RET_QCL_NUM_OUTOFRANGE - *[User Error]* If the user
 *specified QCL is out of range. Must be 1-4. MIRcatSDK_RET_PULSERATE_OUTOFRANGE
 *- *[User Error]* If the user specified pulse rate is invalid and out of range.
 *		MIRcatSDK_RET_PULSEWIDTH_OUTOFRANGE - *[User Error]* If the user
 *specified pulse width is invalid and out of range.
 *		MIRcatSDK_RET_CW_NOT_ALLOWED_ON_QCL - *[User Error]* If the user
 *specified QCL does not support CW. MIRcatSDK_RET_INVALID_LASER_MODE - *[User
 *Error]* If the user specifies an invalid laser mode.
 *		MIRcatSDK_RET_CURRENT_OUTOFRANGE - *[User Error]* If the user
 *specifies an invalid current that is out of range.
 *		MIRcatSDK_RET_TEMPERATURE_OUT_OF_RANGE - *[User Error]* If the
 *user specifies an invalid temperature that is out of range.
 *		MIRcatSDK_RET_SAVE_SETTINGS_FAILURE - *[System Error]* If the
 *system fails to save the QCL settings.
 */
MIRCAT_LIB uint32_t MIRcatSDK_SetAllQclParams(uint8_t bQcl, float fPulseRate,
                                              float fPulseWidth,
                                              float fCurrentInMilliAmps,
                                              float fTemperature,
                                              uint8_t u8laserMode);
/* Function: PowerOffSystem
 *	Send command to power the system off.
 */
MIRCAT_LIB uint32_t MIRcatSDK_PowerOffSystem(void);

/*	Group: Wavelength Triggers */

/* Function: GetWlTrigParams
 *	Gets the current wavelength trigger parameters in the laser settings.
 *
 *	Parameters:
 *		pbPulseMode - (out) Pulse Triggering Mode.
 *		pbProcTrigMode - (out) Process Triggering Mode.
 *		pfWlTrigStart - (out) Wavelength Trigger Start Wavelength.
 *		pfWlTrigStop - (out) Wavelength Trigger Stop Wavelength.
 *		pfWlTrigInterval - (out) Wavelength Trigger Interval.
 *		pbUnits - (out) Wavelength Units for trigger parameters.
 *		pDwellTime - (out) The amount of time (in microseconds) to remain
 *on a wavelength during a step and measure scan. pAfterOffTime - (out) Interval
 *of time (in microseconds) for the timer that controls the delay between steps.
 *
 *
 *	See Also:
 *		<Pulse Triggering Modes>
 *
 *		<Process Triggering Modes>
 *
 *		<Units>
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully gets the
 *wavelength trigger parameters. MIRcatSDK_RET_NOT_INITIALIZED - [User Error] If
 *the MIRcat controller is not yet initialized. MIRcatSDK_RET_COMM_ERROR -
 *[System Error] If the system fails to communicate with the MIRcat laser.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetWlTrigParams(
    uint8_t *pbPulseMode, uint8_t *pbProcTrigMode, float *pfWlTrigStart,
    float *pfWlTrigStop, float *pfWlTrigInterval, uint8_t *pbUnits,
    uint32_t *pDwellTime, uint32_t *pAfterOffTime);

/* Function: SetWlTrigParams
 *	Sets the current wavelength trigger parameters in the laser settings.
 *
 *	Parameters:
 *		pbPulseMode - Pulse Triggering Mode.
 *		pbProcTrigMode - Process Triggering Mode.
 *		pfWlTrigStart - Wavelength Trigger Start Wavelength.
 *		pfWlTrigStop - avelength Trigger Stop Wavelength.
 *		pfWlTrigInterval - Wavelength Trigger Interval.
 *		pbUnits - Microns or Wavenumbers. See <Units>
 *		pDwellTime - (out) The amount of time (in microseconds) to remain
 *on a wavelength during a step and measure scan. pAfterOffTime - (out) Interval
 *of time (in microseconds) for the timer that controls the delay between steps.
 *
 *	See Also:
 *		<Pulse Triggering Modes>
 *
 *		<Process Triggering Modes>
 *
 *		<Units>
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully sets the
 *wavelength trigger parameters. MIRcatSDK_RET_NOT_INITIALIZED - [User Error] If
 *the MIRcat controller is not yet initialized. MIRcatSDK_RET_COMM_ERROR -
 *[System Error] If the system fails to communicate with the MIRcat laser.
 */
MIRCAT_LIB uint32_t MIRcatSDK_SetWlTrigParams(
    uint8_t pbPulseMode, uint8_t pbProcTrigMode, float pfWlTrigStart,
    float pfWlTrigStop, float pfWlTrigInterval, uint8_t pbUnits,
    uint32_t pDwellTime, uint32_t pAfterOffTime);
// FIXME: RudyB 5/23/17 - Documentation Incomplete
/* Function: GetWlTrigChanParams
 *	Description
 *
 *	Parameters:
 *		bChan - Channel indexed from 1.
 *		units - (out) Microns or Wavenumbers. See <Units>
 *		start_ww - (out) Starting Wavelength
 *		stop_ww - (out) Stopping Wavelength
 *		spacing - (out) desc
 *		numTrigs - (out) desc
 *
 *	See Also:
 *		<Units>
 *
 *		<item>
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - Reason
 *		MIRcatSDK_RET_NOT_INITIALIZED - If the MIRcat controller is not
 *yet initialized. MIRcatSDK_RET_COMM_ERROR - Reason
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetWlTrigChanParams(uint8_t bChan, uint8_t *units,
                                                  float *start_ww,
                                                  float *stop_ww,
                                                  float *spacing,
                                                  uint16_t *numTrigs);

/*	Function: GetSystemTemperatures
 *	Gets the system temperatures.
 *
 *	Parameters:
 *		pfBenchTemp1 - (out) Bench Temperature Sensor 1 (degrees C)
 *		pfBenchTemp2 - (out) Bench Temperature Sensor 2 (degrees C)
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_GetSystemTemperatures(float *pfBenchTemp1,
                                                    float *pfBenchTemp2,
                                                    float *pfPcbTemp);

MIRCAT_LIB uint32_t MIRcatSDK_ReadWriteAdvancedSweepParams(bool fWrite);
MIRCAT_LIB uint32_t MIRcatSDK_SetAdvancedSweepParams(
    uint8_t pbUnits, float pfStartWave, float pfStopWave, float pfSpeed,
    uint16_t psNumScans, bool pbBidirectional);

MIRCAT_LIB uint32_t MIRcatSDK_GetAdvancedSweepParams(
    uint8_t *pbUnits, float *pfStartWave, float *pfStopWave, float *pfSpeed,
    uint16_t *psNumScans, bool *pbBidirectional);

MIRCAT_LIB uint32_t MIRcatSDK_SetAdvancedSweepChanParams(uint8_t bQcl,
                                                         float chStartWave,
                                                         float chStopWave,
                                                         bool useChannel);
MIRCAT_LIB uint32_t MIRcatSDK_GetAdvancedSweepChanParams(uint8_t bQcl,
                                                         float *chStartWave,
                                                         float *chStopWave,
                                                         bool *useChannel);

/*	Function: StartSweepAdvancedScan
 *	Starts Sweep Advanced Scan.
 *
 *
 *	Returns:
 *		Always returns *MIRcatSDK_RET_SUCCESS* if the controller is
 *initialized, else returns *MIRcatSDK_RET_NOT_INITIALIZED*.
 */
MIRCAT_LIB uint32_t MIRcatSDK_StartSweepAdvancedScan(void);

/*	Function: InjectProcessTrigger
 *	Inject a manual process into the system for scans when in manual process
 *trigger mode.
 *
 *	Returns:
 *		MIRcatSDK_RET_SUCCESS - If the system successfully injects a
 *process trigger. MIRcatSDK_RET_INJECT_PROC_TRIG_ERROR - *[System Error]* If
 *the system fails to inject a process trigger.
 */
MIRCAT_LIB uint32_t MIRcatSDK_InjectProcessTrigger(void);

MIRCAT_LIB uint32_t MIRcatSDK_GetReadbackParameters(uint8_t bQcl,
                                                    float *actualQclCurrent,
                                                    float *actualQclVoltage,
                                                    float *actualVsrc,
                                                    float *actualVfet);

MIRCAT_LIB uint32_t MIRcatSDK_GetAllTecParams(uint8_t bTec, float *voltage,
                                              float *current,
                                              float *resistance);

MIRCAT_LIB uint32_t MIRcatSDK_GetMoveDuration(uint8_t chan,
                                              uint32_t *moveDuration_us);

MIRCAT_LIB uint32_t MIRcatSDK_GetWlTrigPulseWidth(uint16_t *wlTrigWidth_us);

MIRCAT_LIB uint32_t MIRcatSDK_SetWlTrigPulseWidth(uint16_t wlTrigWidth_us);

MIRCAT_LIB uint32_t MIRcatSDK_EnableRedLaserPointer(bool enable);

/*********************************************************************************************************
 *	Pointing Control Functions
 *********************************************************************************************************/

#define MIRCATSDK_POINTING_MAX_TABLES_PER_CHANNEL	8
#define MIRCATSDK_POINTING_TABLE_NAME_LEN_MAX		32
#define MIRCATSDK_MAX_CAL_ENTRIES_PER_TABLE			1024


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
MIRCAT_LIB uint32_t MIRcatSDK_PointingControlsSupported(bool *enabled);

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
MIRCAT_LIB uint32_t MIRcatSDK_PointingGetCompensationEnabled(bool *xEnabled, bool *yEnabled);

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
MIRCAT_LIB uint32_t MIRcatSDK_PointingCompensationEnable(bool enableX, bool enableY);


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
MIRCAT_LIB uint32_t MIRcatSDK_PointingGoToPosition(int xCounts, int yCounts);

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
MIRCAT_LIB uint32_t MIRcatSDK_PointingGetPosition(int *xCounts, int *yCounts);


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
MIRCAT_LIB uint32_t MIRcatSDK_PointingGetActiveChannel(uint8_t *chan);

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
MIRCAT_LIB uint32_t MIRcatSDK_PointingSetActiveChannel(uint8_t chan);

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
MIRCAT_LIB uint32_t MIRcatSDK_PointingGetActiveBasePosition(uint8_t chan, int *baseX, int *baseY);

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
MIRCAT_LIB uint32_t MIRcatSDK_PointingSetActiveBasePosition(uint8_t chan, int baseX, int baseY);

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
MIRCAT_LIB uint32_t MIRcatSDK_PointingGetFactoryBasePosition(uint8_t chan, int *baseX, int *baseY);

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
MIRCAT_LIB uint32_t MIRcatSDK_PointingReadCalTableInfo(uint8_t chan, uint8_t tableNum,
														bool *tableExists,
														uint16_t *numEntries,
														uint8_t *wlUnits,
														uint8_t *laserMode,
														char *tableName);


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
MIRCAT_LIB uint32_t MIRcatSDK_PointingExportCalTable(uint8_t chan, uint8_t tableNum,
														uint16_t *numEntries,
														float *wavelengths,
														int32_t *xCal,
														int32_t *yCal);
	

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
MIRCAT_LIB uint32_t MIRcatSDK_PointingImportCalTable(uint8_t chan, uint8_t tableNum,
													uint16_t numEntries, uint8_t wlUnits, uint8_t laserMode,
													char *tableName,
													float *wavelengths,
													int32_t *xCal,
													int32_t *yCal);


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
MIRCAT_LIB uint32_t MIRcatSDK_PointingActivateCalTable(uint8_t chan, uint8_t tableNum);

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
MIRCAT_LIB uint32_t MIRcatSDK_PointingGetActiveCalTable(uint8_t chan, uint8_t *tableNum);


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
MIRCAT_LIB uint32_t MIRcatSDK_PointingDeleteCalTable(uint8_t chan, uint8_t tableNum);

MIRCAT_LIB uint32_t MIRcatSDK_GetAdminMode(bool *adminMode);
MIRCAT_LIB uint32_t MIRcatSDK_SetAdminMode(int32_t password, bool adminMode);

#ifdef __cplusplus
}
#endif

#endif // _MIRcatSDK_H_
