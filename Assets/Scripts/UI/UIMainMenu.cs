using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField]
    private Button StatusButton;
    [SerializeField]
    private Button InventoryButton;
    [SerializeField]
    private Button AddItemButton;

    [SerializeField]    
    private TMP_Text PlayerName;
    [SerializeField]
    private TMP_Text PlayerEXP;
    [SerializeField]
    private TMP_Text PlayerLv;

    private void Start()
    {
        StatusButton.onClick.AddListener(OnClickStatusUIButton);
        InventoryButton.onClick.AddListener(OnClickInventoryButton);
        AddItemButton.onClick.AddListener(OnClickAddItemButton);
    }

    private void OnEnable()
    {
        Debug.Log(GameManager.instance);
        Debug.Log(GameManager.instance.player);
        PlayerName.text = GameManager.instance.player.Name;
        PlayerEXP.text = $"{GameManager.instance.player.curExp} / {GameManager.instance.player.reqExp}";
        PlayerLv.text = GameManager.instance.player.Level.ToString();
    }

    public void OnClickStatusUIButton()
    {
        UIManager.Instance.OpenStatus();
    }

    public void OnClickInventoryButton()
    {
        UIManager.Instance.OpenInventory();
    }

    public void OnClickAddItemButton()
    {
        var item = ItemDatamManager.Instance.CreateRandomItem();
        if (item == null)
        {
            return;
        }

        GameManager.instance.player.AddItem(item);
    }
}
