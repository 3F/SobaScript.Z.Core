// This code was generated by a vsSolutionBuildEvent. 
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
namespace net.r_eg.SobaScript.Z.Core
{
    using System;

    public struct ZCoreVersion
    {
        public static readonly Version number = new Version(S_NUM_REV);

        public const string S_NUM = "1.14.0";
        public const string S_REV = "10671";

        public const string S_NUM_REV = S_NUM + "." + S_REV;

        public const string B_SHA1 = "c0aeebf";
        public const string B_NAME = "local/init/stage3";
        public const string B_REVC = "9";

        internal const string S_INFO      = S_NUM_REV + "+" + B_SHA1;
        internal const string S_INFO_FULL = S_INFO + ":" + B_NAME + "-" + B_REVC;
    }
}