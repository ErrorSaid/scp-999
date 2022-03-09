using System;
using Exiled.API.Features;
using Exiled.CustomRoles.API;

namespace SCP_999
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Singleton;
        public override string Name { get; } = "Scp999";
        public override string Prefix { get; } = "scp_999";
        public override string Author { get; } = "ErrorSaid";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);
        
        public Scp999 Scp999;

        public override void OnEnabled()
        {
            Singleton = this;

            SCP999();

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Singleton = null;

            base.OnDisabled();
        }
        public void SCP999()
        {
            Scp999 = new Scp999 { Role = RoleType.Tutorial };
            Scp999.Register();
        }
    }
}
