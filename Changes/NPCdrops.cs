using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;

namespace Test.Changes
{
    internal class NPCLOOT : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.LavaSlime || npc.type == NPCID.Hellbat || npc.type == NPCID.FireImp || npc.type == NPCID.Demon || npc.type == NPCID.BoneSerpentHead)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.Essences.FireEssence>(), 5, 1, 1));
            }
            if (npc.type == NPCID.Shark || npc.type == NPCID.PinkJellyfish || npc.type == NPCID.Squid || npc.type == NPCID.Piranha || npc.type == NPCID.FlyingFish || npc.type == NPCID.AngryNimbus || npc.type == NPCID.UmbrellaSlime)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.Essences.WaterEssence>(), 5, 1, 1));
            }

        }
        
    }
}
//namespace Test.Changes
//{
//    public class ModGlobalNPC : GlobalNPC
//    {
//        public override void ModifyGlobalLoot(GlobalLoot globalLoot)
//        { 
            
//            NPC npc = null;
//            if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneUnderworldHeight)
//            { 
//                globalLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.Essences.FireEssence>(), 1));
//            }



//        }
//    }
//}