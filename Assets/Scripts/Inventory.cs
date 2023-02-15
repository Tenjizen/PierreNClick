using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    [field: SerializeField] public CanvasInventory CanvasInventory { get; private set; }
    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK");

        DontDestroyOnLoad(this);
    }
    public void AddItem(Item item)
    {
        CanvasInventory.AddItem(item);
    }
}
