﻿using net.r_eg.SobaScript;
using net.r_eg.SobaScript.Z.Core;
using net.r_eg.Varhead;

namespace SobaScript.Z.CoreTest.Stubs
{
    internal static class SobaAcs
    {
        public static ISobaScript MakeWithBoxComponent(IUVars uvars = null)
        {
            var soba = MakeSoba(uvars);
            soba.Register(new BoxComponent(soba));
            soba.Register(new EvMSBuildComponent(soba));
            return soba;
        }

        public static ISobaScript MakeWithTryComponent(IUVars uvars = null)
        {
            var soba = MakeSoba(uvars);
            soba.Register(new TryComponent(soba));
            soba.Register(new ConditionComponent(soba));
            return soba;
        }

        public static ISobaScript MakeWithConditionComponent(IUVars uvars = null)
        {
            var soba = MakeSoba(uvars);
            soba.Register(new ConditionComponent(soba));
            return soba;
        }

        public static ISobaScript MakeNewCoreOnly()
            => RegisterCore(new Soba());

        public static ISobaScript MakeNewCoreOnly(IUVars uvars)
            => RegisterCore(new Soba(uvars));

        private static ISobaScript RegisterCore(ISobaScript soba)
        {
            soba.Register(new TryComponent(soba));
            soba.Register(new CommentComponent());
            soba.Register(new BoxComponent(soba));
            soba.Register(new ConditionComponent(soba));
            soba.Register(new UserVariableComponent(soba));
            soba.Register(new EvMSBuildComponent(soba));

            return soba;
        }

        private static ISobaScript MakeSoba(IUVars uvars = null)
            => uvars == null ? new Soba() : new Soba(uvars);
    }
}