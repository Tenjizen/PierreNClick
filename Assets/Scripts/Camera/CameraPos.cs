using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    public Transform CameraTargetPos;


    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        if (CameraManager.Instance.CameraPos == null)
            CameraManager.Instance.CameraPos = this;
        else
            Debug.LogError("fdqgfsdfgdsfsdfsdfsdgfdhsd");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
