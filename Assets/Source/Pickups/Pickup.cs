using UnityEngine;

namespace DAZ4.Pickups
{
    public abstract class Pickup : Base
    {
        [SerializeField]
        private float initialMovement;

        private GameObject player;

        protected override void Start()
        {
            base.Start();

            player = GameObject.FindWithTag("Player");

            Rigidbody2D body = GetComponent<Rigidbody2D>();

            // Add some random movement to give a more interesting intro.
            body.AddForce(new Vector2(
                Random.Range(-initialMovement, initialMovement),
                Random.Range(-initialMovement, initialMovement)
            ));

            body.angularVelocity = Random.Range(-100, 100);
        }

        public void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                Consume();
            }
        }
         

        protected virtual void Consume()
        {
            Inventory inventory = player.GetComponent<Inventory>();

            if (inventory)
            {
                inventory.Add(GetData());
            }

            Destroy(gameObject);
        }

        protected abstract PickupData GetData();
    }
}
