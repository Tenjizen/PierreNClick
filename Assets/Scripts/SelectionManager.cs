using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public SpriteRenderer Visual;

    public Material Outline;
    public Material Default;


    private void OnMouseOver()
    {
        Visual.material = Outline;
    }
    private void OnMouseExit()
    {
        Visual.material = Default;
    }
}
