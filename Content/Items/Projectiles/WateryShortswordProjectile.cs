//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;
//using Microsoft.Xna.Framework;


//namespace Test.Content.Items.Projectiles
//{

//    internal class WateryShortswordProjectile : ModProjectile
//    {

//        public override void SetDefaults()
//        {
//            Projectile.width = 24;
//            Projectile.height = 24;

//            Projectile.friendly = true;
//            Projectile.penetrate = -1;
//            Projectile.tileCollide = false;
//            Projectile.DamageType = DamageClass.Melee;
//            Projectile.ownerHitCheck = true;
//            Projectile.extraUpdates = 1;
//            Projectile.timeLeft = 300;
//            Projectile.aiStyle = ProjAIStyleID.ShortSword;


//        }

//        public override void AI()
//        {
//            base.AI();

//            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

//            int halfprojWidth = Projectile.width / 2;
//            int halfprojHeight = Projectile.height / 2;
//            Projectile.ai[0]++;
//            if(Projectile.ai[0] < 60f)
//            {
//                Projectile.velocity *= 1.01f;
//            }else
//            {
//                Projectile.velocity *= 1.05f;
//            }
//            DrawOriginOffsetX = 0;
//            DrawOffsetX = -((32/2) - halfprojWidth);
//            DrawOriginOffsetY = -((32/2) - halfprojHeight);

//        }
//    }
//}
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Test.Content.Items.Projectiles
{
    internal class WateryShortswordProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 24;

            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.ownerHitCheck = true;
            Projectile.extraUpdates = 1;
            Projectile.timeLeft = 300;

            Projectile.aiStyle = ProjAIStyleID.ShortSword;
        }

        public override void AI()
        {
            base.AI();

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((32 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((32 / 2) - halfProjHeight);
        }
    }
}