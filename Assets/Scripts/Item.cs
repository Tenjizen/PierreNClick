using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [field:SerializeField] public string Name { get; private set; }
    [field:SerializeField] public int ID { get; private set; }

    public void Execute()
    {
        GameManager.Instance.AddItem(this);
        if(AllInteractable.Instance.IInteractableUses.ContainsKey(Name) == false)
        AllInteractable.Instance.IInteractableUses.Add(Name, ID);
        Destroy(gameObject);
    }
}
