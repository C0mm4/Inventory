using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInventorySlot : MonoBehaviour, IPointerClickHandler
{
    Item item;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(item != null) 
            GameManager.instance.player.EquipItem(item);
    }

    public void SetData(Item item)
    {
        this.item = item;
    }


}
