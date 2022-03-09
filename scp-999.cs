using Exiled.API.Features;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;
using System.Collections.Generic;
using Exiled.Events.EventArgs;
using UnityEngine;
using Scp999Handler_Player = Exiled.Events.Handlers.Player;
using Exiled.API.Features.Attributes;
using Exiled.CustomItems.API;

namespace SCP_999
{
    [CustomRole(RoleType.Tutorial)]
    public class Scp999 : CustomRole
    {
        public override uint Id { get; set; } = 100;
        public override string Name { get; set; } = "SCP999";
        public override string Description { get; set; } = "SCP 999";
        public override RoleType Role { get; set; } = RoleType.Tutorial;
        public override int MaxHealth { get; set; } = 5000;
        public override string CustomInfo { get; set; } = "SCP-999 cute xd";

        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties
        {
            Limit = 1,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
            {
                new DynamicSpawnPoint
                {
                    Chance = Plugin.Singleton.Config.Chance,
                    Location = SpawnLocation.Inside914,
                }
            }
        };
        public override List<string> Inventory { get; set; } = new List<string>
        {
            $"{ItemType.Coin}",
            $"{ItemType.Flashlight}",
            $"{ItemType.KeycardO5}",
        };
        protected override void RoleAdded(Player player)
        {
            player.Broadcast(5, "<i>You are the <color=green>Scp999</color></i>");
            player.Scale = new Vector3(0.4f, 0.4f, 0.4f);
            player.IsGodModeEnabled = true;
            player.RankName = "SCP 999";
            player.RankColor = "green";
            base.RoleAdded(player);
        }
        protected override void SubscribeEvents()
        {
            Scp999Handler_Player.DroppingItem += this.OnDroppingItem;
            Scp999Handler_Player.PickingUpItem += this.OnPickingUpItem;
            base.SubscribeEvents();
        }
        protected override void UnsubscribeEvents()
        {
            Scp999Handler_Player.DroppingItem -= this.OnDroppingItem;
            Scp999Handler_Player.PickingUpItem -= this.OnPickingUpItem;
            base.UnsubscribeEvents();
        }
        public void OnDroppingItem(DroppingItemEventArgs ev)
        {
            if (Check(ev.Player))
            {
                ev.IsAllowed = false;
                ev.Player.ShowHint("<i>You cant drop items while you are <color=green>scp-999</color></i>");
            }
        }
        public void OnPickingUpItem(PickingUpItemEventArgs ev)
        {
            if (Check(ev.Player))
            {
                ev.IsAllowed = false;
                ev.Player.ShowHint("<i>You cant pickup items while you are <color=green>scp-999</color></i>");
            }
        }
    }
}
