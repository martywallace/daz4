using UnityEngine;
using DAZ4.Creatures;
using DAZ4.Data;

namespace DAZ4.Weapons
{
    public abstract class Gun : Weapon
    {
        public override void Attack()
        {
            if (CanAttack)
            {
                LayerMask layers = 1;

                // Add layer exclusions.
                foreach (string layer in IgnoredLayers())
                {
                    layers |= (1 << LayerMask.NameToLayer(layer));
                }

                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 10, ~layers);

                if (hit.collider)
                {
                    Debug.DrawLine(transform.position, hit.point, Color.white, 0.1f, false);

                    Creature creature = hit.collider.gameObject.GetComponent<Creature>();

                    if (creature)
                    {
                        Damage damage = new Damage(Power);

                        creature.TakeDamage(damage);
                    }
                }
                else
                {
                    Debug.DrawLine(transform.position, transform.position + transform.right * 40, Color.white, 0.1f, false);
                }

                ResetCooldown();
            }
        }

        protected virtual string[] IgnoredLayers()
        {
            return new string[] { "Pickups" };
        }
    }
}
