using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Character : MonoBehaviour
{
    [field :Header("Status")]
    [field: SerializeField]
    public string Name {  get; private set; }

    [field: SerializeField]
    public List<Status> Statuses { get; private set; }

    [field :Header("Level")]
    [field: SerializeField]
    public int Level {  get; private set; }
    [field: SerializeField]
    public int reqExp {  get; private set; }
    [field: SerializeField]
    public int curExp {  get; private set; }

    [Header("Inventory")]
    [SerializeField]
    public List<Item> inventorySlots = new(12);

    public Item currentEquipItem;

    public void AddStatus(StatusType type, int value)
    {
        // 타겟 스테이터스 찾기
        bool isExists = false;
        foreach(var status in Statuses)
        {
            if(status.Type == type)
            {
                // 스테이터스 반영
                status.AddValue(value);
                isExists = true;

                break;
            }
        }

        // 만약 해당 캐릭터가 해당 타입의 수치가 없었다면 해당 스테이터스 추가
        if (!isExists)
        {
            Status newStatus = new(type, value);
            Statuses.Add(newStatus);
        }
    }

    public void EquipItem(Item targetItem)
    {
        // 아이템 장착 시 아이템에 들어있는 스테이터스 적용
        for (int i = 0; i < targetItem.AddStatus.Count; i++)
        {
            AddStatus(targetItem.AddStatus[i].Type, targetItem.AddStatus[i].Value);
        }
        currentEquipItem = targetItem;
    }

    public void UnEquipItem(Item targetItem)
    {
        // 아이템 해제 시 아이템에 들어있는 스테이터스 제거
        for (int i = 0; i < targetItem.AddStatus.Count; i++)
        {
            AddStatus(targetItem.AddStatus[i].Type, -targetItem.AddStatus[i].Value);
        }
        currentEquipItem = null;
    }

    public void AddItem(Item newItem)
    {
        for(int i = 0; i < inventorySlots.Count; i++)
        {
            // 빈 슬롯 찾기
            if(inventorySlots[i] == null)
            {
                // 새로운 객체로 만들어서 넣어줌
                inventorySlots[i] = newItem.Instantiate();
                return;
            }
        }
    }
}


public enum StatusType
{
    None, Atk, Def, Health, Critical
}

[Serializable]
public class Status
{
    [field: SerializeField]
    public StatusType Type { get; private set; }
    [field: SerializeField]
    public int Value {  get; private set; }
    public string SpritePath => $"Sprite/Status/{Type}";

    public void AddValue(int value)
    {
        Value += value;
    }

    public Status(StatusType type, int value)
    {
        Type = type;
        Value = value;
    }
}

