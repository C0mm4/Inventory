using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private UIMainMenu mainMenuUI;
    public UIMainMenu MainMenu {  get { return mainMenuUI; } }

    [SerializeField]
    private UIStatus statusUI;
    public UIStatus Status { get { return statusUI; } }

    [SerializeField]
    private UIInventory inventoryUI;
    public UIInventory Inventory { get { return inventoryUI; } }

    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OpenMainMenu()
    {
        mainMenuUI.gameObject.SetActive(true);
        statusUI.gameObject.SetActive(false);
        inventoryUI.gameObject.SetActive(false);
    }

    public void OpenStatus()
    {
        mainMenuUI.gameObject.SetActive(false);
        statusUI.gameObject.SetActive(true);
        inventoryUI.gameObject.SetActive(false);
    }

    public void OpenInventory()
    {
        mainMenuUI.gameObject.SetActive(false);
        statusUI.gameObject.SetActive(false);
        inventoryUI.gameObject.SetActive(true);
    }
}
