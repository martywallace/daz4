using UnityEngine;

namespace DAZ4.Creatures
{
    public class Enemy : Creature
    {
        protected GameObject Player {
            get;
            private set;
        }

        protected override void Start()
        {
            base.Start();

            Player = GameObject.Find("Player");
        }

        protected override void Update()
        {
            base.Update();

            // Face player.
            Vector3 delta = Player.transform.position - Transform.position;
            Transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg, Vector3.forward);
        }
    }
}