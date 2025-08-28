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

    public void AddStatus(StatusType type, int value)
    {
        bool isExists = false;
        foreach(var status in Statuses)
        {
            if(status.Type == type)
            {
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
        for (int i = 0; i < targetItem.AddStatus.Count; i++)
        {
            AddStatus(targetItem.AddStatus[i].Type, targetItem.AddStatus[i].Value);
        }
    }

    public void UnEquipItem(Item targetItem)
    {
        for (int i = 0; i < targetItem.AddStatus.Count; i++)
        {
            AddStatus(targetItem.AddStatus[i].Type, -targetItem.AddStatus[i].Value);
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
    [field: SerializeField]
    public string SpritePath {  get; private set; }

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

