using UnityEngine;
using System.Collections;

namespace DAZ4.Weapons
{
    public abstract class Weapon : Base
    {
        public int Power;

        public abstract void Attack();
    }
}
