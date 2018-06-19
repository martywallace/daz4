using UnityEngine;

namespace DAZ4.Creatures
{
    public class Player : Creature
    {
        protected override void Update()
        {
            base.Update();

            Vector3 position = Camera.main.WorldToScreenPoint(Transform.position);
            Vector3 delta = Input.mousePosition - position;

            Transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg, Vector3.forward);

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Body.AddForce(new Vector2(horizontalInput * Stats.Speed, verticalInput * Stats.Speed));
        }
    }
}