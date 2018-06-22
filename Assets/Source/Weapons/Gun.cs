using UnityEngine;

namespace DAZ4.Weapons
{
    public abstract class Gun : Weapon
    {
        public override void Attack()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);

            if (hit.collider)
            {
                Debug.DrawLine(transform.position, hit.point, Color.white, 0.1f, false);
            }
            else
            {
                Debug.DrawLine(transform.position, transform.position + transform.right * 40, Color.white, 0.1f, false);
            }
        }
    }
}
