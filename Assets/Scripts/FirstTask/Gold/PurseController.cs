using Items;

namespace Purse
{
    public class PurseController : IPurse
    {
        private int _goldAmount;
        public int GoldAmount => _goldAmount;

        private PurseView _purseView;

        public PurseController(int goldAmount, PurseView purseView)
        {
            _goldAmount = goldAmount;
            _purseView = purseView;
        }

        public void Init()
        {
            UpdateView();
        }

        public void OnBuy(ITradable item)
        {
            _goldAmount -= item.CurrentPrice;
            UpdateView();
        }

        public void OnSell(ITradable item)
        {
            _goldAmount += item.CurrentPrice;
            UpdateView();
        }

        private void UpdateView()
        {
            _purseView.UpdateText(_goldAmount.ToString());
        }
    }
}