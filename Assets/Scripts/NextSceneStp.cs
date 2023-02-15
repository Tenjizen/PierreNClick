using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneStp : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("GameCommon");
    }
}
