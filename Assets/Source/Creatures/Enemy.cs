using UnityEngine;
using DAZ4.Fixtures;
using DAZ4.Data;

namespace DAZ4.Creatures
{
    public class Enemy : Creature
    {

        public int CursorDelay;
        public float MeleeRange;

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
            Cursor -= (Cursor - Player.transform.position) / CursorDelay;

            // Standard AI - face and move toward the cursor.
            FacePoint(Cursor);
            MoveForward();

            if (DistanceToPlayer < MeleeRange) {
                Damage damage = new Damage(1);
                Player.GetComponent<Creature>().TakeDamage(damage);
            }
        }
    }
}