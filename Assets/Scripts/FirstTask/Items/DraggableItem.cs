using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Items
{
    public class DraggableItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private Image _image;

        //[HideInInspector]
        public Transform _parent;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _parent = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            _image.raycastTarget = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.SetParent(_parent);
            _image.raycastTarget = true;
        }
    }
}