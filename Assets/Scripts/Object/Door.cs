using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _nextScene;
    [SerializeField] private bool _needObject;

    public void Execute()
    {
        if (_needObject == true && BrainGame.Instance.Paper == true)
        {
            GameManager.Instance.Player.Move(this.transform.position);
            PlayerPrefs.SetString(GameManager.NextSceneKey, _nextScene);
            SceneManager.LoadScene("GameCommon");
        }
        else if(_needObject == false)
        {
            GameManager.Instance.Player.Move(this.transform.position);
            PlayerPrefs.SetString(GameManager.NextSceneKey, _nextScene);
            SceneManager.LoadScene("GameCommon");
        }
    }
}
