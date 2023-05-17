using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Test.Content;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Test.Content.Items.Tools.Pickaxe
{
    internal class WetPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wet Pickaxe");
            Tooltip.SetDefault("A soaking pickaxe which holds shape surprisingly well");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(10,3));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;


            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.scale = 1f;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 13;
            Item.useAnimation = 15;
            Item.autoReuse = true;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 12;
            Item.knockBack = 3.5f;
            Item.crit = 0;
            Item.useTurn = true;
            Item.pick = 75;

            Item.value = Item.buyPrice(silver: 40);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
        }






        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            // Inflict the OnFire debuff for 1 second onto any NPC/Monster that this hits.
            // 60 frames = 1 second
            target.AddBuff(BuffID.Wet, 120);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 8)
                .AddIngredient(ModContent.ItemType<Essences.WaterEssence>(), 25)
                .AddTile(TileID.Anvils)
                .Register();

        }

    }
}
