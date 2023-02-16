using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drum : MonoBehaviour, IInteractable
{
    public AudioClip AudioClip;

    public void Execute()
    {
        Debug.Log("JOUER SON");
    }
}
