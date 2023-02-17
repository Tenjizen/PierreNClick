using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chandelier : MonoBehaviour, IInteractable
{
    public string ID;
    public string Name;
    public Rigidbody Rb;

    private void Start()
    {
        if (AllInteractable.Instance.IInteractableUses.ContainsValue(ID))
        {
            Destroy(this.gameObject);
        }
    }
    public void Execute()
    {
        Rb.useGravity = true;
        var list = this.gameObject.GetComponents<SelectionManager>();
        for (int i = 0; i < list.Length; i++)
        {
            Destroy(list[i]);
        }

        if (AllInteractable.Instance.IInteractableUses.ContainsValue(ID) == false)
            AllInteractable.Instance.IInteractableUses.Add(Name, ID);
    }
}
