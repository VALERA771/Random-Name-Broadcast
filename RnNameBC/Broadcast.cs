using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RnNameBc
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class Broadcast : ICommand
    {
        public string Command { get; } = "randombc";
        public string[] Aliases { get; } = { "rnbc" };
        public string Description { get; } = "Broadcasts random player's nickname";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("rnbc"))
            {
                response = "You don't have permissions to execute this command";
                return false;
            }

            if (Round.IsLobby)
            {
                if (!Plugin.Instance.Config.StartEx)
                {
                    response = "You can't execute this command when round isn't started";
                    return false;
                }
            }
            if (Round.IsEnded)
            {
                if (!Plugin.Instance.Config.EndEx)
                {
                    response = "You can't execute this command when round is ended";
                    return false;
                }
            }
            Random rn = new Random();
            int pos = rn.Next(Player.List.Count() + 1);
            if (pos < 2)
            {
                if (pos == 0)
                    pos += 2;
                if (pos == 1)
                    pos++;
            }
            Player player = Player.Get(pos);
            Player sen = Player.Get(sender);

            if (!Plugin.Instance.Config.SenderName)
            {
                if (sen.Nickname == player.Nickname)
                {
                    pos++;
                    player = Player.Get(pos);
                }
            }

            Map.Broadcast(message: Plugin.Instance.Config.Text.Replace("{0}", player.Nickname), duration: Plugin.Instance.Config.Duration);

            response = $"Successful! Player ID - {pos}";
            return true;
        }
    }
}
