using Exiled.API.Interfaces;
using System.ComponentModel;

namespace RnNameBc
{
    public sealed class Config : IConfig
    {
        [Description("Is plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Text for broadcast ({0} replaces with player's nickname)")]
        public string Text { get; set; } = "{0}";

        [Description("Duration for broadcast")]
        public ushort Duration { get; set; } = 20;

        [Description("Can command returns sender's nickname?")]
        public bool SenderName { get; set; } = true;

        [Description("Can command be execute if round isn't started?")]
        public bool StartEx { get; set; } = false;

        [Description("Can command be execute if round is ended?")]
        public bool EndEx { get; set; } = false;
    }
}
