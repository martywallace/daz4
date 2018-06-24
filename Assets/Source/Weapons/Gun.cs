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
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);

                if (hit.collider)
                {
                    Debug.DrawLine(transform.position, hit.point, Color.white, 0.1f, false);

                    Creature creature = hit.collider.gameObject.GetComponent<Creature>();

                    if (creature)
                    {
                        if (Attributes)
                        {
                            Damage damage = new Damage(Attributes.Power);

                            creature.TakeDamage(damage);
                        }
                    }
                }
                else
                {
                    Debug.DrawLine(transform.position, transform.position + transform.right * 40, Color.white, 0.1f, false);
                }

                ResetCooldown();
            }
        }
    }
}
