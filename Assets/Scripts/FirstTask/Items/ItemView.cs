using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    public class ItemView : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        private Image _image;

        private void Awake()
        {
            _image = GetComponentInChildren<Image>();
            _text = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void Init(string name, int price, ItemRarity rarity)
        {
            UpdateText(name, price);
            UpdateImage(rarity);
        }

        public void UpdateText(string name, int price)
        {
            if (_text == null)
            {
                _text = GetComponentInChildren<TextMeshProUGUI>();
            }

            _text.text = $"{name}: {price}";
        }

        private void UpdateImage(ItemRarity rarity)
        {
            if (_image == null)
            {
                _image = GetComponentInChildren<Image>();
            }

            var color = GetColor(rarity);

            _image.color = color;

        }

        private Color GetColor(ItemRarity rarity) => rarity switch
        {
            ItemRarity.Common => Color.gray,
            ItemRarity.Rare => Color.yellow,
            ItemRarity.Legendary => Color.magenta,
            ItemRarity.Unique => Color.red,
            _ => Color.white,

        };
    }
}