using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour, IPointerClickHandler
{
    public Item item;
    [SerializeField]
    private Image outlineEffect;
    [SerializeField]
    private Image ItemImage;

    public Action OnClickAction;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(item != null)
        {
            var player = GameManager.instance.player;
            if (player != null)
            {
                if(player.currentEquipItem == item)
                {
                    player.UnEquipItem(item);
                }
                else
                {
                    if(player.currentEquipItem != null)
                    {
                        player.UnEquipItem(player.currentEquipItem);
                    }

                    player.EquipItem(item);
                }
            }
        }
        OnClickAction?.Invoke();
    }

    public void SetData(Item item)
    {
        this.item = item;
        if (item == null)
        {
            ItemImage.enabled = false;
            outlineEffect.enabled = false;
            return;
        }

        if(GameManager.instance.player.currentEquipItem == item)
        {
            outlineEffect.enabled = true;
        }
        else
        {
            outlineEffect.enabled = false;
        }

        ItemImage.sprite = item.GetSprite();
        if(ItemImage.sprite == null)
        {
            ItemImage.enabled = false;
        }
        else
        {
            ItemImage.enabled = true;
        }
    }
}
