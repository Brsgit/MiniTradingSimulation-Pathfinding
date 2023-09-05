using UnityEngine;

public class ItemFactory 
{
    private Item _prefab;
    private Transform _container;

    public ItemFactory(Item prefab, Transform transform)
    {
        _prefab = prefab;
        _container = transform;
    }

    public Item CreateItem(ItemInfo itemInfo)
    {
        Item item = Object.Instantiate(_prefab, _container);
        item.Init(itemInfo, ItemOwner.Merchant);

        return item;
    }
}
