using UnityEngine;

namespace DAZ4.Creatures
{
    public class Player : Creature
    {
        protected override void Update()
        {
            base.Update();

            FacePoint(Input.mousePosition - Camera.main.WorldToScreenPoint(Transform.position));

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            if (
                horizontalInput < -0.01 || horizontalInput > 0.01
                || verticalInput < -0.01 || verticalInput > 0.01
            )
            {
                float inputAngle = Mathf.Atan2(verticalInput, horizontalInput);

                Vector2 force = new Vector2(
                    Mathf.Cos(inputAngle) * Stats.Speed,
                    Mathf.Sin(inputAngle) * Stats.Speed
                );

                Body.AddForce(force);
            }
        }
    }
}