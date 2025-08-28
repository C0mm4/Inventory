using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public Button closeButon;

    [SerializeField]
    private TMP_Text PlayerName;
    [SerializeField]
    private TMP_Text PlayerEXP;
    [SerializeField]
    private TMP_Text PlayerLv;

    private void Start()
    {
        closeButon.onClick.AddListener(OnClickCloseButton);
    }

    private void OnEnable()
    {
        PlayerName.text = GameManager.instance.player.Name;
        PlayerEXP.text = $"{GameManager.instance.player.curExp} / {GameManager.instance.player.reqExp}";
        PlayerLv.text = GameManager.instance.player.Level.ToString();
    }

    public void OnClickCloseButton() 
    {
        UIManager.Instance.OpenMainMenu();
    }
}
