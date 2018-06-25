namespace DAZ4.Pickups
{
    public struct PickupData
    {
        public string Name
        {
            get;
            private set;
        }

        public int Amount
        {
            get;
            private set;
        }

        public bool Stackable
        {
            get;
            private set;
        }

        public PickupData(string name, int amount, bool stackable)
        {
            Name = name;
            Amount = amount;
            Stackable = stackable;
        }
    }
}
