using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _nextScene;
    [SerializeField] private Vector3 _playerPosNextScene;

    public void Execute()
    {
        GameManager.Instance.Player.Move(this.transform.position);
        PlayerPrefs.SetString(GameManager.NextSceneKey, _nextScene);
        SceneManager.LoadScene("GameCommon");
    }
}
