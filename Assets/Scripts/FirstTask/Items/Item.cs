using UnityEngine;

public class Item : MonoBehaviour, ITradable
{
    private ItemInfo _info;
    public ItemInfo ItemInfo => _info;

    private int _currentPrice;
    public int CurrentPrice => _currentPrice;

    private Owner _owner;
    public Owner Owner => _owner;

    private ItemRarity _rarity;

    private ItemView _itemView;


    public void Init(ItemInfo info, Owner owner)
    {
        _info = info;
        // By default Merchant has all items on the beginning
        _owner = owner;
        _currentPrice = ItemInfo.Price;
        _rarity = GetItemRarityAccordingToPrice(ItemInfo.Price);
        InitView();
    }

    private void InitView()
    {
        _itemView = GetComponent<ItemView>();
        _itemView.Init(ItemInfo.Name, ItemInfo.Price, _rarity);
    }

    public void UpdateOwner(Owner owner)
    {
        _owner = owner;
        UpdatePrice();
    }

    private void UpdatePrice()
    {

        _currentPrice = Mathf.CeilToInt(_owner == Owner.Merchant ? ItemInfo.Price : ItemInfo.Price * 0.5f);
        _itemView.UpdateText(ItemInfo.Name, _currentPrice);
    }

    private ItemRarity GetItemRarityAccordingToPrice(int price) => price switch
    {
        var p when p < 50 => ItemRarity.Common,
        var p when p >= 50 && p < 100 => ItemRarity.Rare,
        var p when p >= 100 && p < 1000 => ItemRarity.Legendary,
        var p when p >= 1000 => ItemRarity.Unique,
        _ => ItemRarity.Common,
    };
}
