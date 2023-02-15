using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllInteractable : MonoBehaviour
{
    public static AllInteractable Instance;


    public Dictionary<string,string> IInteractableUses = new Dictionary<string, string>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("tout pt");
        }
        DontDestroyOnLoad(this);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (var item in IInteractableUses)
            {
                Debug.Log(item.Value + "value / key" + item.Key);
            }
        }
    }
}
