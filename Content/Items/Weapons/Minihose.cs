using Test.Content.Items.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Test.Content.Items.Weapons
{
	public class Minihose : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("An amalgamation of a minishark and a water gun");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			// Common Properties
			Item.width = 27; // Hitbox width of the item.
			Item.height = 12; // Hitbox height of the item.
			Item.scale = 2f;
			Item.rare = ItemRarityID.Green; // The color that the item's name will be in-game.

			// Use Properties
			Item.useTime = 4; // The item's use time in ticks (60 ticks == 1 second.)
			Item.useAnimation = 4; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
			Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.

			// The sound that this item plays when used.
			Item.UseSound = SoundID.Item11;

			// Weapon Properties
			Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
			Item.damage = 7; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			Item.knockBack = 1f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			Item.noMelee = true; // So the item's animation doesn't do damage.

			// Gun Properties
			Item.shoot = ProjectileID.ChlorophyteBullet; // For some reason, all the guns in the vanilla source have this.
			Item.shootSpeed = 50f; // The speed of the projectile (measured in pixels per frame.)
			Item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Minishark, 1)
				.AddIngredient(ItemID.WaterGun, 1)
				.AddIngredient(ModContent.ItemType<Essences.WaterEssence>(), 25)
				.AddTile(TileID.Anvils)
				.Register();
		}

		// This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(2f, -2f);
		}
        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref int knockback)
        {
            Vector2 offset = new Vector2(speedX * 3, speedY * 3);
			position += offset;
			return true;
        }*/
    
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float numberProjectiles = 25 + Main.rand.Next(3); // 3, 4, or 5 shots
			float rotation = MathHelper.ToRadians(5);
			position += Vector2.Normalize(velocity) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}
			return false; // return false to stop vanilla from calling Projectile.NewProjectile.
		}
	}

}

//TODO: Move this to a more specifically named example. Say, a paint gun?


/*
* Feel free to uncomment any of the examples below to see what they do
*/

// What if I wanted it to work like Uzi, replacing regular bullets with High Velocity Bullets?
// Uzi/Molten Fury style: Replace normal Bullets with High Velocity
/*public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
	if (type == ProjectileID.Bullet) { // or ProjectileID.WoodenArrowFriendly
		type = ProjectileID.BulletHighVelocity; // or ProjectileID.FireArrow;
	}
}*/

//What if I wanted multiple projectiles in a even spread? (Vampire Knives)
// Even Arc style: Multiple Projectile, Even Spread
