using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    public Button closeButon;

    [SerializeField]
    private TMP_Text PlayerName;
    [SerializeField]
    private TMP_Text PlayerEXP;
    [SerializeField]
    private TMP_Text PlayerLv;

    public GameObject slotUIPref;
    [SerializeField]
    private Transform SlotContentTrans;
    private List<UIStatusSlot> slots = new();
    Character player;

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
        UpdateUI();
    }

    public void OnClickCloseButton()
    {
        UIManager.Instance.OpenMainMenu();
    }

    private void InitUI()
    {
        slots = new();
        foreach (var status in player.Statuses)
        {
            var go = Instantiate(slotUIPref, SlotContentTrans);
            slots.Add(go.GetComponent<UIStatusSlot>());
        }

        UpdateUI();
    }

    private void UpdateUI() 
    {
        for(int i = 0; i < slots.Count; i++) 
        {
            slots[i].SetData(player.Statuses[i]);
        }
    }
}
