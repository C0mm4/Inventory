using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public Button closeButon;

    private void Start()
    {
        closeButon.onClick.AddListener(OnClickCloseButton);
    }

    public void OnClickCloseButton() 
    {
        UIManager.Instance.OpenMainMenu();
    }
}
