using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public Button closeButon;

    [Header("BaseData")]
    [SerializeField]
    private TMP_Text PlayerName;
    [SerializeField]
    private TMP_Text PlayerEXP;
    [SerializeField]
    private TMP_Text PlayerLv;

    [Header("Inventory")]

    [SerializeField]
    private GameObject InventorySlotPref;
    [SerializeField]
    private Transform SlotContentTrans;
    private List<UIInventorySlot> slots;
    private Character player;

    [SerializeField]
    private ScrollRect scrollRect;


    private void Awake()
    {
        closeButon.onClick.AddListener(OnClickCloseButton);
        player = GameManager.instance.player;
        InitUI();
    }

    private void OnEnable()
    {
        PlayerName.text = GameManager.instance.player.Name;
        PlayerEXP.text = $"{GameManager.instance.player.curExp} / {GameManager.instance.player.reqExp}";
        PlayerLv.text = GameManager.instance.player.Level.ToString();

        scrollRect.verticalNormalizedPosition = 1f;
        UpdateUI();
    }

    public void OnClickCloseButton() 
    {
        UIManager.Instance.OpenMainMenu();
    }


    private void InitUI()
    {
        slots = new();
        foreach (var status in player.inventorySlots)
        {
            var go = Instantiate(InventorySlotPref, SlotContentTrans);
            UIInventorySlot slot = go.GetComponent<UIInventorySlot>();
            slot.OnClickAction += UpdateUI;
            slots.Add(slot);
            
        }

        UpdateUI();
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 1f;
    }

    private void UpdateUI()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].SetData(player.inventorySlots[i]);
        }
    }
}
