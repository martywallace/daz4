using UnityEngine;
using DAZ4.Data;

namespace DAZ4.Creatures
{
    public abstract class Enemy : Creature
    {

        [SerializeField]
        private int cursorDelay;

        [SerializeField]
        private float meleeRange;

        [SerializeField]
        private GameObject[] loot;

        [SerializeField]
        private float dropLootChance;

        protected GameObject Player {
            get;
            private set;
        }

        protected Vector3 Cursor {
            get;
            private set;
        }

        protected float DistanceToPlayer {
            get {
                return Vector3.Distance(transform.position, Player.transform.position);
            }
        }

        protected override void Start()
        {
            base.Start();

            Player = GameObject.Find("Player");
            Cursor = new Vector3(transform.position.x, transform.position.y);

            // Start off immediately looking at the player.
            FacePoint(Player.transform.position);
        }

        protected override void Update()
        {
            base.Update();

            // Move the cursor toward the player.
            Cursor -= (Cursor - Player.transform.position) / cursorDelay;

            // Standard AI - face and move toward the cursor.
            FacePoint(Cursor);
            MoveForward();

            if (DistanceToPlayer < meleeRange) {
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