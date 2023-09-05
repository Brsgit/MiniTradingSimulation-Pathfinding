using Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Purse
{
    public interface IPurse
    {
        int GoldAmount { get; }

        void OnSell(ITradable item);
        void OnBuy(ITradable item);
    }
}