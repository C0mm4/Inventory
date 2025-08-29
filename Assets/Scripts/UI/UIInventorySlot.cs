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

    public Action OnClickAction { get; set; }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(item != null)
        {
            var player = GameManager.instance.player;
            if (player != null)
            {
                // 장착된 아이템이면 해제
                if(player.currentEquipItem == item)
                {
                    player.UnEquipItem(item);
                }
                else
                {
                    // 이미 장착된게 있으면 해제
                    if(player.currentEquipItem != null)
                    {
                        player.UnEquipItem(player.currentEquipItem);
                    }
                    // 해당 아이템 장착
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

        // 장착 시 아웃라인 활성화
        if(GameManager.instance.player.currentEquipItem == item)
        {
            outlineEffect.enabled = true;
        }
        else
        {
            outlineEffect.enabled = false;
        }

        // 아이템 스프라이트 설정
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
