using UnityEngine;

namespace DAZ4.Creatures
{
    public class Player : Creature
    {
        protected override void Start()
        {
            base.Start();

            Debug.Log(Graphics);
            Debug.Log(Body);
        }
    }
}