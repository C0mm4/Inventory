using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/New Item")]
public class Item : ScriptableObject
{
    [field :SerializeField]
    public string Name {  get; private set; }
    [field :SerializeField]
    public List<ItemStatus> AddStatus { get; private set; }

}

[Serializable]
public class ItemStatus
{
    [field: SerializeField]
    public StatusType Type { get; private set; }
    [field: SerializeField]
    public int Value { get; private set; }
}
