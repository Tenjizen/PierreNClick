using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour, IInteractable
{
    public string ID;
    public string Name;

    public GameObject prefabDrop;
    public Collider Collider;
    [SerializeField] ItemData itemData;
    public bool AlreadyDestroy = false;
    private void Start()
    {
        if (AllInteractable.Instance.IInteractableUses.ContainsKey(ID))
        {
            AlreadyDestroy = true;
        }
    }
    public void Execute()
    {
        if (BrainGame.Instance.Chisel == true && AlreadyDestroy == false)
        {
            //if (prefabDrop != null)
            //{

            //    GameObject go = Instantiate(prefabDrop, this.transform);

            //    if (go.GetComponent<Item>() != null)
            //    {
            //        Item item = go.GetComponent<Item>();
            //        item.ID = itemData.DataID;
            //        item.Name = itemData.DataName;
            //        item.Sprite = itemData.DataSprite;
            //        item.itemDrop = itemData.DataItemDrop;
            //        item.Execute();
            //    }
            //}
            //if (AllInteractable.Instance.IInteractableUses.ContainsValue(ID) == false)
            //    AllInteractable.Instance.IInteractableUses.Add(Name, ID);
            //AlreadyDestroy = true;
            //Collider.enabled = false;
            DropAndDestroy();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Chandelier>() != null && AlreadyDestroy == false)
        {
            DropAndDestroy();
        }
    }


    private void DropAndDestroy()
    {
            if (prefabDrop != null)
            {
                GameObject go = Instantiate(prefabDrop, this.transform);

                if (go.GetComponent<Item>() != null)
                {
                    Item item = go.GetComponent<Item>();
                    item.ID = itemData.DataID;
                    item.Name = itemData.DataName;
                    item.Sprite = itemData.DataSprite;
                    item.itemDrop = itemData.DataItemDrop;
                    item.Execute();
                }
            }
            if (AllInteractable.Instance.IInteractableUses.ContainsValue(ID) == false)
                AllInteractable.Instance.IInteractableUses.Add(Name, ID);
            AlreadyDestroy = true;
            Collider.enabled = false;
    }
}
