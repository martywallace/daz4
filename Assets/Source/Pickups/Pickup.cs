using UnityEngine;

namespace DAZ4.Pickups
{
    public abstract class Pickup : Base
    {
        [SerializeField]
        private float initialMovement;

        protected override void Start()
        {
            base.Start();

            Rigidbody2D body = GetComponent<Rigidbody2D>();

            // Add some random movement to give a more interesting intro.
            body.AddForce(new Vector2(
                Random.Range(-initialMovement, initialMovement),
                Random.Range(-initialMovement, initialMovement)
            ));

            body.angularVelocity = Random.Range(-100, 100);
        }

        public void OnTriggerEnter(Collider collider)
        {
            Debug.Log(collider);
        }


        protected virtual void Consume()
        {
            Destroy(gameObject);
        }
    }
}
