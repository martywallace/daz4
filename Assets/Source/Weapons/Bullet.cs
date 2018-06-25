using UnityEngine;
using System.Collections;

namespace DAZ4.Weapons
{
    public class Bullet : Base
    {
        private int lifetime = 3;

        protected override void Update()
        {
            base.Update();

            if (lifetime-- <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}