using System;
using UnityEngine;
using DAZ4.Fixtures;
using DAZ4.Data;

namespace DAZ4.Creatures
{

    public abstract class Creature : Base
    {
        public SpriteRenderer Graphics
        {
            get;
            private set;
        }

        public Rigidbody2D Body
        {
            get;
            private set;
        }

        public CreatureStats Stats
        {
            get;
            private set;
        }

        protected override void Start()
        {
            Graphics = GetComponent<SpriteRenderer>();
            Body = GetComponent<Rigidbody2D>();
            Stats = GetComponent<CreatureStats>();
        }

        /// <summary>
        /// Apply damage to this Creature. Positive values indicate damage while
        /// negative values indicate healing.
        /// </summary>
        /// <param name="damage">The damage to apply.</param>
        public virtual void TakeDamage(Damage damage)
        {
            if (Stats)
            {
                if (Stats.Health == 0 && damage.Amount > 0) {
                    // No need to take damage when we are already dead.
                    return;
                }

                Stats.Health = Mathf.Clamp(Stats.Health - damage.Amount, 0, Stats.MaxHealth);

                if (Stats.Health <= 0)
                {
                    Die();
                }
            }
            else
            {
                throw new Exception(String.Format("Cannot take damage - no stats component attached to {0}.", this));
            }
        }

        protected virtual void Die()
        {
            // This creature is dead.
            // ...
        }

        protected void FacePoint(Vector3 point) {
            Vector3 delta = point - transform.position;
            transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg, Vector3.forward);
        }

        protected void MoveForward()
        {
            if (Body)
            {
                float speed = Stats ? Stats.Speed : 1;

                Body.AddForce(transform.right * speed);
            }
        }
    }
}