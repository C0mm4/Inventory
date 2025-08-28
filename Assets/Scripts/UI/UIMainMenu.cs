using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField]
    private Button StatusButton;
    [SerializeField]
    private Button InventoryButton;

    private void Start()
    {
        StatusButton.onClick.AddListener(OnClickStatusUIButton);
        InventoryButton.onClick.AddListener(OnClickInventoryButton);
    }

    public void OnClickStatusUIButton()
    {
        UIManager.Instance.OpenStatus();
    }

    public void OnClickInventoryButton()
    {
        UIManager.Instance.OpenInventory();
    }
}
