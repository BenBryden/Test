using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Test.Content;
using Microsoft.Xna.Framework;
using Test.Content.Items.Projectiles;

namespace Test.Content.Items.Weapons
{
    internal class WateryShortsword : ModItem
    {
        
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.Rapier;

            Item.UseSound = SoundID.Item1;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 20;
            Item.knockBack = 4f;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shootSpeed = 2.1f;
            Item.shoot = ModContent.ProjectileType<WateryShortswordProjectile>();


            Item.value = Item.buyPrice(silver: 40);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
        }






        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            // Inflict the OnFire debuff for 1 second onto any NPC/Monster that this hits.
            // 60 frames = 1 second
            target.AddBuff(BuffID.Wet, 240);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Essences.WaterEssence>(), 25)
                .AddTile(TileID.Anvils)
                .Register();

        }

    }
}
