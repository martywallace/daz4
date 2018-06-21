using UnityEngine;

namespace DAZ4.Creatures
{
    public class Player : Creature
    {
        protected override void Update()
        {
            base.Update();

            FacePoint(Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position));

            int horizontalInput = 0;
            int verticalInput = 0;

            if (Input.GetKey(KeyCode.W)) verticalInput = 1;
            else if (Input.GetKey(KeyCode.S)) verticalInput = -1;
            if (Input.GetKey(KeyCode.A)) horizontalInput = -1;
            else if (Input.GetKey(KeyCode.D)) horizontalInput = 1;

            if (verticalInput != 0 || horizontalInput != 0)
            {
                float inputAngle = Mathf.Atan2(verticalInput, horizontalInput);

                Vector2 force = new Vector2(
                    Mathf.Cos(inputAngle) * Stats.Speed,
                    Mathf.Sin(inputAngle) * Stats.Speed
                );

                Body.AddForce(force);
            }

            //
        }

        protected override void Die()
        {
            base.Die();

            Debug.Log("Player has died");
        }
    }
}