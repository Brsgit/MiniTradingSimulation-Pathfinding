using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPurse
{
    int GoldAmount { get; }

    void OnSell(ITradable item);
    void OnBuy(ITradable item);
}
