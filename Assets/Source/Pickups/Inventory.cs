using System.Collections.Generic;
using UnityEngine;

namespace DAZ4.Pickups
{
    public class Inventory : MonoBehaviour
    {
        private List<PickupData> contents = new List<PickupData>();

        public void Add(PickupData item)
        {
            contents.Add(item);
        }

        public void Remove(PickupData item)
        {
            // todo
        }
    }
}
