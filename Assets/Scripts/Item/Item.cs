using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemData;

public class Item : MonoBehaviour, IInteractable
{
    [field: SerializeField] public ItemDropable itemDrop;
    [field:SerializeField]public string ID { get; set; }
    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField] public Sprite Sprite { get; set; }

    private void Start()
    {
        if (AllInteractable.Instance.IInteractableUses.ContainsValue(ID))
        {
           Destroy(this.gameObject);
        }
    }
    public void Execute()
    {
        switch (itemDrop)
        {
            case ItemDropable.Chisel:
                BrainGame.Instance.Chisel = true;
                break;
            case ItemDropable.Paint:
                BrainGame.Instance.Paint = true;
                break;
            case ItemDropable.Paper:
                BrainGame.Instance.Paper = true;
                break;
            case ItemDropable.Pen:
                BrainGame.Instance.Pen = true;
                break;
            default:
                break;
        }
        Inventory.Instance.AddItem(this);

        if (AllInteractable.Instance.IInteractableUses.ContainsValue(ID) == false)
            AllInteractable.Instance.IInteractableUses.Add(Name, ID);
        Destroy(this.gameObject);
    }
}



