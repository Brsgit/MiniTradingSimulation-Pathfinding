

public class ItemObserver : IObserver
{
    private ITradable _item;

    public ItemObserver(ITradable item)
    {
        _item = item;
    }

    public void UpdateOwner(Owner owner)
    {
        _item.UpdateOwner(owner);
    }
    
}
