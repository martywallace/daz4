using System.Collections.Generic;
using UnityEngine;

namespace DAZ4.Pickups
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        private List<PickupData> contents;

        public void Start()
        {
            contents = new List<PickupData>();
        }

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
