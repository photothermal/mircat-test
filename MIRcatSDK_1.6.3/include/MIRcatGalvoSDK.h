#ifndef _MIRcatGalvoSDK_H
#define _MIRcatGalvoSDK_H
#include <stdint.h>

#ifdef WIN32_EXPORT
#define MIRCAT_LIB __declspec(dllexport)
#elif __linux__
#define MIRCAT_LIB
#else
#define MIRCAT_LIB __declspec(dllimport)
#endif

#define MIRcatSDK_GALVO_DEFAULT_DISPLACEMENT 500
#define MIRcatSDK_GALVO_MIN_DISPLACEMENT 0
#define MIRcatSDK_GALVO_MAX_DISPLACEMENT 2047

#ifdef __cplusplus
extern "C" {
#endif

/**
<summary>Set the galvo displacement for galvo on/off mode.  This will set the
displacement value in the laser.</summary> <param name="wDisplacement">16-bit
integer value for galvo displacement.  This function will enforce limits on the
min/max displacement value.</param> <returns>Error code.</returns>
*/
MIRCAT_LIB uint32_t MIRcatSDK_SetGalvoDisplacement(uint16_t wDisplacement);

/**
<summary>Get the galvo displacement for galvo on/off mode.  This gets the
displacement value in the laser.</summary> <param name="pwDisplacement">Pointer
tp 16-bit integer value for galvo displacement.  Read from the laser.</param>
<returns>Error code.</returns>
*/
MIRCAT_LIB uint32_t MIRcatSDK_GetGalvoDisplacement(uint16_t *pwDisplacement);

/**
<summary>Enable or Disable laser on/off control using the galvo.</summary>
<param name="bEnable">Bool value to enable or disable galvo on/off control of
the laser.</param> <returns>Error code.</returns>
*/
MIRCAT_LIB uint32_t MIRcatSDK_EnableGalvoLaserOnOff(bool bEnable);

/**
<summary>Get the galvo on/off laser control status.</summary>
<param name="bEnabled">Bool value that indicates the status of galvo on/off
control of the laser.</param> <returns>Error code.</returns>
*/
MIRCAT_LIB uint32_t MIRcatSDK_GetGalvoLaserOnOffEnabled(bool *bEnabled);

/**
<summary>Gets the number of actuations of the galvo used to turn the laser
on/off in galvo on/off mode.</summary> <param name="dwNumFlips">Unsigned int
that indicates number of times the galvo has been actuated during this power on
state.</param> <returns>Error code.</returns>
*/
MIRCAT_LIB uint32_t MIRcatSDK_GetNumGalvoFlips(uint32_t *dwNumFlips);

#ifdef __cplusplus
}
#endif

#endif
