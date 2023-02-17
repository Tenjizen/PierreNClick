using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{

    [SerializeField] private string Name;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private string ID;
    [SerializeField] private string _nextScene;
    [SerializeField] private bool _needObject;

    private void Awake()
    {
        Debug.Log("door");
        if (MainGame.Instance.PlayerController.gameObject.activeInHierarchy == false)
        {
            if (AllInteractable.Instance.IInteractableUses.ContainsValue(Name) == false)
            {
                MainGame.Instance.PlayerController.gameObject.SetActive(true);

            }
            else if (AllInteractable.Instance.IInteractableUses.ContainsKey(ID))
            {
                Transform transformPos = MainGame.Instance.PlayerController.gameObject.transform;
                transformPos.position = this.transform.position + _offset;
                MainGame.Instance.PlayerController.gameObject.transform.position = transformPos.position;
                AllInteractable.Instance.IInteractableUses.Remove(ID);
                MainGame.Instance.PlayerController.gameObject.SetActive(true);
            }
        }
    }
    public void Execute()
    {
        if (_needObject == true && BrainGame.Instance.Paper == true)
        {
            GameManager.Instance.Player.Move(this.transform.position);
            PlayerPrefs.SetString(GameManager.NextSceneKey, _nextScene);
            SceneManager.LoadScene("GameCommon");
        }
        else if (_needObject == false)
        {
            GameManager.Instance.Player.Move(this.transform.position);
            PlayerPrefs.SetString(GameManager.NextSceneKey, _nextScene);
            SceneManager.LoadScene("GameCommon");
        }
        if (AllInteractable.Instance.IInteractableUses.ContainsKey(ID) == false)
            AllInteractable.Instance.IInteractableUses.Add(ID, Name);
        AudioManager.Instance.PlaySFXSound("porte");
    }
}
