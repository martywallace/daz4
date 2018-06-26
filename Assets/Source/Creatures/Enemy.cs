using UnityEngine;
using DAZ4.Data;

namespace DAZ4.Creatures
{
    public abstract class Enemy : Creature
    {

        public static readonly int MinRoamCooldown = 50;
        public static readonly int MaxRoamCooldown = 500;
        public static readonly int DelayUntilRoam = 65;

        [SerializeField]
        private int cursorDelay;

        [SerializeField]
        [Tooltip("The distance the enemy is able to see and approach the player at.")]
        private float visualRange;

        [SerializeField]
        [Tooltip("The melee range within which the enemy can attack the player.")]
        private float meleeRange;

        [SerializeField]
        [Tooltip("Possible items that can be dropped by this enemy.")]
        private GameObject[] loot;

        [SerializeField]
        [Tooltip("Percent chance that an item from the loot list will be dropped.")]
        private float dropLootChance;

        [SerializeField]
        [Tooltip("Whether or not this enemy will roam around once the player goes out of sight.")]
        private bool willRoam;

        [SerializeField]
        [Tooltip("The radius from the last position where the player was seen in which the enemy will roam around.")]
        private float roamRadius;

        private int roamCooldown = 0;

        private Vector2 roamTarget;

        protected Vector2 PlayerLastSeenAt
        {
            get;
            private set;
        }

        protected int TimeSincePlayerLastSeen
        {
            get;
            private set;
        }

        protected GameObject Player
        {
            get;
            private set;
        }

        protected Vector2 Cursor
        {
            get;
            private set;
        }

        protected float DistanceToPlayer
        {
            get
            {
                return Vector3.Distance(transform.position, Player.transform.position);
            }
        }

        protected float AngleToPlayer
        {
            get
            {
                Vector3 diff = Player.transform.position - transform.position;

                return Mathf.Atan2(diff.y, diff.x);
            }
        }

        protected bool CanSeePlayer
        {
            get
            {
                if (DistanceToPlayer <= visualRange)
                {
                    LayerMask mask = 1 << LayerMask.NameToLayer("Creatures") | 1 << LayerMask.NameToLayer("Obstacles");
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(Mathf.Cos(AngleToPlayer), Mathf.Sin(AngleToPlayer), 0), visualRange, mask);

                    return hit.collider && hit.collider.CompareTag("Player");
                }

                return false;
            }
        }

        protected override void Start()
        {
            base.Start();

            Player = GameObject.Find("Player");
            Cursor = new Vector3(transform.position.x, transform.position.y);
            PlayerLastSeenAt = transform.position;
            TimeSincePlayerLastSeen = DelayUntilRoam;

            // Start off immediately looking at the player.
            FacePoint(Player.transform.position);
        }

        protected override void Update()
        {
            base.Update();

            if (CanSeePlayer)
            {
                // Move the cursor toward the player.
                Cursor -= (Cursor - (Vector2)Player.transform.position) / cursorDelay;

                // Remember the last place we saw the player in case it goes out
                // of sight.
                PlayerLastSeenAt = transform.position;
                TimeSincePlayerLastSeen = 0;

                // Move directly forward if we can see the player.
                MoveForward();

                Debug.DrawLine(transform.position, Player.transform.position, Color.white, 0.03f);
            }
            else
            {
                Debug.DrawLine(transform.position, PlayerLastSeenAt, Color.blue, 0.03f);
                Debug.DrawLine(transform.position, roamTarget, Color.white, 0.03f);

                // Roam around the place where we last saw the player.
                roamCooldown -= 1;
                TimeSincePlayerLastSeen += 1;

                if (roamCooldown <= 0)
                {
                    roamCooldown = Random.Range(MinRoamCooldown, MaxRoamCooldown);
                    roamTarget = PlayerLastSeenAt + Random.insideUnitCircle * roamRadius;
                }

                if (TimeSincePlayerLastSeen >= DelayUntilRoam)
                {
                    // Move the cursor toward the randomly chosen roam target.
                    Cursor -= (Cursor - roamTarget) / cursorDelay;

                    if (Vector2.Distance(transform.position, roamTarget) > 0.1)
                    {
                        // Move forward if not super close to target.
                        MoveForward();
                    }
                }
            }

            // Standard AI - face and move toward the cursor.
            FacePoint(Cursor);

            if (DistanceToPlayer < meleeRange)
            {
                Damage damage = new Damage(1);
                Player.GetComponent<Creature>().TakeDamage(damage);
            }
        }

        protected override void Die()
        {
            base.Die();

            // Select a pickup to drop.
            if (loot.Length > 0)
            {
                if (Random.value <= dropLootChance)
                {
                    // Select and instantiate a random pickup from the
                    // configured list of possible options.
                    GameObject selection = loot[Random.Range(0, loot.Length)];
                    GameObject pickup = Instantiate(selection);

                    pickup.transform.position = transform.position;
                }
            }

            // Remove this enemy from the game.
            Destroy(gameObject);
        }
    }
}