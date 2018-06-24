namespace DAZ4.Data
{
    public struct Damage
    {
        public int Amount
        {
            get;
            private set;
        }

        public Damage(int amount)
        {
            Amount = amount;
        }
    }
}
