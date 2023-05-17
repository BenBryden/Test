using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Test.Content;
using Microsoft.Xna.Framework;
using Test.Content.Items.Dusts;

namespace Test.Content.Items.Weapons
{
    internal class Adara : ModItem
    {
        public override void UpdateInventory(Player player)
        {
            Item.useTurn = Item.favorited;
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.scale = 1.8f;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.autoReuse = true;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 32;
            Item.knockBack = 3.5f;
            Item.crit = 5;


            Item.value = Item.buyPrice(silver: 60);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Dust.NewDust(Item.position, Item.width, Item.height, ModContent.DustType<AdaraDust>());
           

        }


        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<AdaraDust>(), 0f, 0f, 0, default(Color), 1f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 0f;
        }



        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            // Inflict the OnFire debuff for 1 second onto any NPC/Monster that this hits.
            // 60 frames = 1 second
            target.AddBuff(BuffID.OnFire, 60);
        }
        
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Essences.FireEssence>(), 25)
                .AddTile(TileID.Anvils)
                .Register();

        }
        
    }
}
