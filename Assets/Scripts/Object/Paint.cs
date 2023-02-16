using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour, IInteractable
{
    public string ID;
    public string Name;
    public GameObject prefabDrop;
    public Collider Collider;
    public bool AlreadyUse = false;
    [SerializeField] ItemData itemData;

    private void Start()
    {
        if (AllInteractable.Instance.IInteractableUses.ContainsValue(ID))
        {
            AlreadyUse = true;
        }
    }
    public void Execute()
    {
        if (AlreadyUse == false)
        {
            if (BrainGame.Instance.Pen == true && BrainGame.Instance.Paint == true)
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
                if (AllInteractable.Instance.IInteractableUses.ContainsValue(ID) == false)
                    AllInteractable.Instance.IInteractableUses.Add(Name, ID);
            }
        }

    }


}
