using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chandelier : MonoBehaviour, IInteractable
{
    public Rigidbody Rb;
    public void Execute()
    { 
        Rb.useGravity = true;
    }
}
