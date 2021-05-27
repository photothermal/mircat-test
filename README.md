# mircat-test
Demonstration/test code for PSC sweep speed issue w/ MIRcatSDK v1.6.3

When upgrading MIRcat SDK from version 1.4.3 to version 1.6.3 there were a few issues.  

Currently we are unable to set the IR sweep speed through the SDK.  This is confirmed
both by calling the MIRcatSDK_GetAdvancedSweepParams method, and experimentally.  

This VisualStudio project demonstrates the problem.
