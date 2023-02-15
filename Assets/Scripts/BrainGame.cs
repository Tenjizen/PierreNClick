using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainGame : MonoBehaviour
{
    public static BrainGame Instance;

    public bool Burin;
    public bool Painceau;
    public bool Peinture;
    public bool Clef;
    public bool Feuille;


    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("fdsfdsfsdfdsfsdfhqsdifnhsvkfnj");
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
    }
}
