using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatusSlot : MonoBehaviour
{
    [SerializeField]
    private TMP_Text statusNameText;
    [SerializeField]
    private TMP_Text statusValueText;
    [SerializeField]
    private Image spriteSlot;

    public void SetData(Status status)
    {
        statusNameText.text = status.Name;
        statusValueText.text = status.Value.ToString();
        try
        {
            Sprite spr = Resources.Load<Sprite>(status.SpritePath);
            spriteSlot.sprite = spr;

        }
        catch
        {
            Debug.LogError($"{status.SpritePath} 에 이미지가 없습니다");
            spriteSlot.sprite = null;
        }

    }
}
