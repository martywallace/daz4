using UnityEngine;

namespace DAZ4.Pickups
{
    public class Ammo : Pickup
    {
        protected override PickupData GetData()
        {
            return new PickupData("ammo", Random.Range(3, 5), true);
        }
    }
}