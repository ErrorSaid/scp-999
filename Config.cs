using System.ComponentModel;
using Exiled.API.Interfaces;

namespace SCP_999
{
    public class Config : IConfig
    {
        [Description("is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;
        [Description("Chance to spawn object to transform scp-999")]
        public int Chance { get; set; } = 50; 
    }
}
