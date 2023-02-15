using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    public Transform CameraTargetPos;
    void Start()
    {
        if (CameraManager.Instance.CameraPos == null)
            CameraManager.Instance.CameraPos = this;
        else
            Debug.LogError("fdqgfsdfgdsfsdfsdfsdgfdhsd");
    }
}
