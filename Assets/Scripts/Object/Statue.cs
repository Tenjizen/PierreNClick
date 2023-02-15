using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour, IInteractable
{
    public GameObject prefabDrop;
    public Collider Collider;

    public void Execute()
    {

        if (BrainGame.Instance.Burin == true)
        {
            Debug.Log("Cassé");

            GameObject go = Instantiate(prefabDrop, this.transform);

            Inventory.Instance.AddItem(go.GetComponent<Item>());
            if (AllInteractable.Instance.IInteractableUses.ContainsKey(go.GetComponent<Item>().Name) == false)
                AllInteractable.Instance.IInteractableUses.Add(go.GetComponent<Item>().Name, go.GetComponent<Item>().ID);
            Destroy(go);

            Collider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Chandelier>() != null)
        {
            Debug.Log("Cassé");

            GameObject go = Instantiate(prefabDrop, this.transform);

            Inventory.Instance.AddItem(go.GetComponent<Item>());
            if (AllInteractable.Instance.IInteractableUses.ContainsKey(go.GetComponent<Item>().Name) == false)
                AllInteractable.Instance.IInteractableUses.Add(go.GetComponent<Item>().Name, go.GetComponent<Item>().ID);
            Destroy(go);

            Collider.enabled = false;
        }
    }
}
