using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour, IInteractable
{
    public GameObject prefabDrop;
    public Collider Collider;


    public void Execute()
    {
        if (BrainGame.Instance.Painceau == true && BrainGame.Instance.Peinture == true)
        {
            Debug.Log("Peint");

            GameObject go = Instantiate(prefabDrop, this.transform);
            Inventory.Instance.AddItem(go.GetComponent<Item>());

            if (AllInteractable.Instance.IInteractableUses.ContainsKey(go.GetComponent<Item>().Name) == false)
                AllInteractable.Instance.IInteractableUses.Add(go.GetComponent<Item>().Name, go.GetComponent<Item>().ID);
            Destroy(go);

            Collider.enabled = false;
        }

    }


}
