using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TradeController
{
    public event Action<ITradable, Owner> OnStoreOperation;

    private IPurse _purse;

    private List<ItemPanel> _itemPanels;

    public TradeController(IPurse purse)
    {
        _purse = purse;
    }

    public void Init(List<ItemPanel> panels)
    {
        _itemPanels = panels;
        foreach(var panel in _itemPanels)
        {
            panel.OnItemDrop += AvailableForBuying;
        }
    }

    ~TradeController()
    {
        foreach (var panel in _itemPanels)
        {
            panel.OnItemDrop -= AvailableForBuying;
        }
    }
    
    private bool AvailableForBuying(Owner owner, DraggableItem item)
    {
        var tradable = item.GetComponent<ITradable>();

        if (owner == tradable.Owner)
            return true;

        if(owner == Owner.Merchant)
        {
            _purse.OnSell(tradable);
        }
        else
        {
            if(_purse.GoldAmount >= tradable.CurrentPrice)
            {
                _purse.OnBuy(tradable);
            }
            else
            {
                UnityEngine.Debug.Log("Not Enough Money!");
                return false;
            }
        }

        OnStoreOperation?.Invoke(tradable, owner);
        return true;
    }
}
