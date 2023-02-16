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

        if (AllInteractable.Instance.IInteractableUses.ContainsValue(ID) == false)
            AllInteractable.Instance.IInteractableUses.Add(Name, ID);
    }
}
