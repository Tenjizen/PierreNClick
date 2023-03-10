using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUi : MonoBehaviour
{
    public Image image;
    public void Initialize(Item item)
    {
        image.sprite = item.Sprite;
        //GetComponentInChildren<TMPro.TMP_Text>().text = item.Name;
    }
}
