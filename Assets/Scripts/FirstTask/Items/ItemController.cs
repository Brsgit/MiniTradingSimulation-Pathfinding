using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] 
    private Item _prefab;

    [SerializeField] 
    private Transform _container;

    private ItemGenerator _generator;

    private List<Item> _items;

    public void Start()
    {
        _generator = new ItemGenerator();
        _items = _generator.GenerateItems(_prefab, _container);
    }
}
