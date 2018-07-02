using UnityEngine;
using DAZ4.Creatures;
using DAZ4.Data;

namespace DAZ4.Weapons
{
    public abstract class Gun : Weapon
    {
        
        public static readonly int MaxBulletDistance = 10;

        [SerializeField]
        [Tooltip("The type of bullet this weapon fires.")]
        private GameObject bullet;

        [SerializeField]
        [Tooltip("Maximum error angle in radians.")]
        private float errorRadians;

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

                float straight = Mathf.Atan2(transform.right.y, transform.right.x);
                float actual = straight + Random.Range(-errorRadians, errorRadians);
                Vector3 direction = new Vector2(Mathf.Cos(actual), Mathf.Sin(actual));

                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, MaxBulletDistance, ~layers);

                if (hit.collider)
                {
                    Hit(hit);
                }
                else
                {
                    CreateBullet(transform.position, transform.position + direction * MaxBulletDistance);
                }

                ResetCooldown();
            }
        }

        protected void Hit(RaycastHit2D hit)
        {
            // Draw the bullet.
            CreateBullet(transform.position, hit.point);

            // Activate potential particles.
            ParticleSystem particles = hit.collider.gameObject.GetComponent<ParticleSystem>();

            if (particles)
            {
                particles.Play();
            }

            // Determine if the object was a creature and should receive damage.
            Creature creature = hit.collider.gameObject.GetComponent<Creature>();

            if (creature)
            {
                Damage damage = new Damage(Power);

                creature.TakeDamage(damage);
            }
        }

        protected GameObject CreateBullet(Vector3 from, Vector3 to)
        {
            // todo: fix this
            from.z = to.z = -1;

            GameObject instance = Instantiate(bullet);
            LineRenderer line = instance.GetComponent<LineRenderer>();
            Vector3[] positions = new Vector3[] { from, to };

            line.SetPositions(positions);

            return instance;
        }

        protected virtual string[] IgnoredLayers()
        {
            return new string[] { "Pickups" };
        }
    }
}
