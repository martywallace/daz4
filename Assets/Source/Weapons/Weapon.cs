using UnityEngine;
using System.Collections;

namespace DAZ4.Weapons
{
    public abstract class Weapon : Base
    {

        private int cooldownTimer;

        protected WeaponAttributes Attributes
        {
            get;
            private set;
        }

        protected bool CanAttack
        {
            get {
                return cooldownTimer <= 0;
            }
        }

        protected override void Start()
        {
            base.Start();

            Attributes = GetComponent<WeaponAttributes>();
        }

        public abstract void Attack();

        protected void ResetCooldown() {
            if (Attributes)
            {
                cooldownTimer = Attributes.Cooldown;
            }
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
