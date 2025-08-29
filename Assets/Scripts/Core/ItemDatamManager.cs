using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatamManager : MonoBehaviour
{
    public static ItemDatamManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public List<Item> itemDatas = new();

    public Item CreateItem(int index)
    {
        if (index < 0 || index >= itemDatas.Count) { return null; }

        // 인덱스 아이템 복사해서 반환
        Item targetItem = itemDatas[index].Instantiate();
        return targetItem;
    }

    public Item CreateRandomItem()
    {
        int rand = Random.Range(0, itemDatas.Count);
        return CreateItem(rand);
    }
}
