using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator
{
    private ItemFactory _factory;
    private ItemParser _parser;

    private List<ITradable> _items = new List<ITradable>();

    public List<ITradable> GenerateItems(Item go, Transform container)
    {
        _parser = new ItemParser();
        _factory = new ItemFactory(go, container);

        var jsonStr = Resources.Load<TextAsset>("Items/items01");

        var itemInfoList = _parser.ParseFromJson(jsonStr.ToString());

        foreach(var itemInfo in itemInfoList)
        {
            var item = _factory.CreateItem(itemInfo);
            _items.Add(item);
        }

        return _items;
    }
}
