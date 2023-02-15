using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [field: SerializeField] public string ID { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }

    private void Start()
    {
        if (AllInteractable.Instance.IInteractableUses.ContainsKey(Name))
        {
            Destroy(this.gameObject);
        }
    }
    public void Execute()
    {
        Inventory.Instance.AddItem(this);

        if (AllInteractable.Instance.IInteractableUses.ContainsKey(Name) == false)
            AllInteractable.Instance.IInteractableUses.Add(Name, ID);
        Destroy(gameObject);
    }
}
