using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Items
{
    public class ItemPanel : MonoBehaviour, IDropHandler
    {
        [SerializeField]
        private Owner _owner;

        public event Func<Owner, DraggableItem, bool> OnItemDrop;
        public void OnDrop(PointerEventData eventData)
        {
            var dropped = eventData.pointerDrag;
            DraggableItem draggedItem = dropped.GetComponent<DraggableItem>();

            bool? availableToDrop = OnItemDrop?.Invoke(_owner, draggedItem);

            if (availableToDrop != null && availableToDrop == true)
            {
                draggedItem._parent = transform;
            }
        }

    }
}