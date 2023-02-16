using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameCommon : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("GameCommon");
    }
}
