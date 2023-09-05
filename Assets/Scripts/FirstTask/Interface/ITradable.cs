namespace Items
{
    public interface ITradable
    {
        int CurrentPrice { get; }

        Owner Owner { get; }

        ItemInfo ItemInfo { get; }

        void UpdateOwner(Owner owner);
    }
}