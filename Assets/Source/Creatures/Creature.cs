using System;
using UnityEngine;
using DAZ4.Fixtures;
using DAZ4.Data;

namespace DAZ4.Creatures
{

    public abstract class Creature : Base
    {
        public Transform Transform {
            get;
            private set;
        }

        public SpriteRenderer Graphics
        {
            get;
            private set;
        }

        public Collider2D Body
        {
            get;
            private set;
        }

        public CreatureStats Stats {
            get;
            private set;
        }

        protected override void Start()
        {
            Transform = GetComponent<Transform>();
            Graphics = GetComponent<SpriteRenderer>();
            Body = GetComponent<Collider2D>();
            Stats = GetComponent<CreatureStats>();
        }

        /// <summary>
        /// Apply damage to this Creature. Positive values indicate damage while
        /// negative values indicate healing.
        /// </summary>
        /// <param name="damage">The damage to apply.</param>
        public virtual void TakeDamage(Damage damage) {
            if (Stats) {
                Stats.Health -= damage.Amount;

                // Clamp health between 0 and maximum value.
                Stats.Health = Math.Max(Stats.Health, 0);
                Stats.Health = Math.Min(Stats.Health, Stats.MaxHealth);

                if (Stats.Health <= 0) {
                    Die();
                }
            } else {
                throw new Exception(String.Format("Cannot take damage - no stats component attached to {0}.", this));
            }
        }

        protected virtual void Die() {
            // This creature is dead.
            // ...
        }
    }
}