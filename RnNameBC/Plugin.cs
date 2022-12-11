using Exiled.API.Features;
using System;

namespace RnNameBc
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "CASSIE Info";
        public override string Prefix => "CASSIEInfo";
        public override string Author => "VALERA771#1471";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(5, 3, 0);

        public override void OnEnabled()
        {
            Plugin.singleton = this;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Plugin.singleton = null;
            base.OnDisabled();
        }

        public override void OnReloaded()
        {
            base.OnReloaded();
        }


        public static Plugin Instance => singleton;
        private static Plugin singleton;
    }
}
