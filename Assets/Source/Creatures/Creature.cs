using UnityEngine;

namespace DAZ4.Creatures
{

    public abstract class Creature : Base
    {
        public SpriteRenderer Graphics
        {
            get;
            private set;
        }

        public Collider2D Body
        {
            get;
            private set;
        }

        protected override void Start()
        {
            Graphics = GetComponent<SpriteRenderer>();
            Body = GetComponent<Collider2D>();
        }
    }
}