using UnityEngine;

namespace DAZ4.Creatures
{
    public class Enemy : Creature
    {

        public int CursorDelay;
        public int MeleeRange;

        protected GameObject Player {
            get;
            private set;
        }

        protected Vector3 Cursor {
            get;
            private set;
        }

        protected override void Start()
        {
            base.Start();

            Player = GameObject.Find("Player");
            Cursor = new Vector3(Transform.position.x, Transform.position.y);

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
        }
    }
}