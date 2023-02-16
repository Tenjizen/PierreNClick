using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainGame : MonoBehaviour
{
    public static BrainGame Instance;

    public bool Chisel;
    public bool Paint;
    public bool Paper;
    public bool Pen;


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
