using Controllers;
using Observer;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class ItemController : MonoBehaviour
    {
        [SerializeField]
        private Item _prefab;

        [SerializeField]
        private Transform _container;

        private ItemGenerator _generator;

        private List<ITradable> _items;
        public IEnumerable<ITradable> Items => _items;

        private TradeController _tradeController;

        private Dictionary<ITradable, ItemObserver> _observers = new Dictionary<ITradable, ItemObserver>();

        public void Init(TradeController tradeController)
        {
            _tradeController = tradeController;

            _tradeController.OnStoreOperation += UpdateItemInfo;

            _generator = new ItemGenerator();
            _items = _generator.GenerateItems(_prefab, _container);

            foreach (var item in _items)
            {
                _observers[item] = new ItemObserver(item);
            }
        }

        private void OnDisable()
        {
            _tradeController.OnStoreOperation -= UpdateItemInfo;
        }

        private void UpdateItemInfo(ITradable item, Owner newOwner)
        {
            _observers[item].UpdateOwner(newOwner);
        }
    }
}