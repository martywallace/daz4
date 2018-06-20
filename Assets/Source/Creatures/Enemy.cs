using UnityEngine;

namespace DAZ4.Creatures
{
    public class Enemy : Creature
    {
        protected GameObject Player {
            get;
            private set;
        }

        protected Vector3 Cursor {
            get;
            private set;
        }

        public int CursorDelay;

        protected override void Start()
        {
            base.Start();

            Player = GameObject.Find("Player");
            Cursor = new Vector3(Transform.position.x, Transform.position.y);
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