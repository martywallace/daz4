using UnityEngine;
using System.Collections;

namespace DAZ4.Weapons
{
    public abstract class Weapon : Base
    {

        private int cooldownTimer;

        public int Power;
        public int Cooldown;

        protected bool CanAttack
        {
            get {
                return cooldownTimer <= 0;
            }
        }

        public abstract void Attack();

        protected void ResetCooldown() {
            cooldownTimer = Cooldown;
        }

		protected override void Update()
        {
            base.Update();

            if (cooldownTimer > 0)
            {
                cooldownTimer--;
            }
        }
    }
}
