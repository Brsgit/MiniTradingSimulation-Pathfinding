using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private int _startingGold;

    [SerializeField]
    private List<ItemPanel> _panels;

    [SerializeField]
    private ItemController _itemController;

    private TradeController _tradeController;

    private PurseController _purseController;

    [SerializeField]
    private PurseView _purseView;

    private void Start()
    {
        _purseController = new PurseController(_startingGold, _purseView);
        _purseController.Init();

        _tradeController = new TradeController(_purseController);
        _tradeController.Init(_panels);

        _itemController.Init(_tradeController);
    }
}
