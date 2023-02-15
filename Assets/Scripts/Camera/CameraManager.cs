using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    private Camera _camera;
    public CameraPos CameraPos;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("hein????????????");


        if (_camera == null)
            _camera = Camera.main;
        else
            Debug.LogError("cc ckc");
    }
    void Update()
    {
        if (CameraPos != null)
        {
            this.transform.position = CameraPos.CameraTargetPos.position;
            this.transform.rotation = CameraPos.CameraTargetPos.rotation;
        }
    }

}
