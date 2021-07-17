using Newtonsoft.Json;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardewDumper
{
    public class ModEntry : StardewModdingAPI.Mod
    {
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.DayStarted += GameLoop_DayStarted;
        }

        public string GetGiftTasteName(int taste)
        {
            switch (taste)
            {
                case NPC.gift_taste_love:
                    return "Love";
                case NPC.gift_taste_like:
                    return "Like";
                case NPC.gift_taste_neutral:
                    return "Neutral";
                case NPC.gift_taste_dislike:
                    return "Dislike";
                case NPC.gift_taste_hate:
                    return "Hate";
                default:
                    return "Unknown";
            }
        }

        private void GameLoop_DayStarted(object sender, DayStartedEventArgs e)
        {
            var npcs = Utility.getAllCharacters(new List<NPC>());
            var output = new Dictionary<string, Dictionary<string, string>>();
            foreach (var npc in npcs)
            {
                if (!npc.isVillager())
                {
                    continue;
                }
                /*if (!(npc.CanSocialize || Game1.player.friendshipData.ContainsKey(npc.name)))
                {
                    continue;
                }*/

                var giftTastes = new Dictionary<string, string>();
                foreach (var id in Game1.objectInformation.Keys)
                {
                    try
                    {
                        var item = new StardewValley.Object(id, 1);
                        // apparently this loads the item properly
                        item.getDescription();
                        giftTastes[item.name] = GetGiftTasteName(npc.getGiftTasteForThisItem(item));
                    }
                    catch
                    {
                    }
                }
                output[npc.displayName] = giftTastes;
            }
            var json = JsonConvert.SerializeObject(output, Formatting.Indented);
            File.WriteAllText(Path.Combine(Helper.DirectoryPath, "gift_tastes.json"), json);
        }
    }
}
