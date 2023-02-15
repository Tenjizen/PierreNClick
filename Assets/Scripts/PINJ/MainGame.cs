using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    public enum GameState { FreeRoam, Dialog}

    [SerializeField] private PlayerController _playerController;

    public GameState State;

    public PinjController PinjController;

    public static MainGame Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        DialogManager.Instance.onShowDialog += () =>
        {
            State = GameState.Dialog;

        };
        DialogManager.Instance.onCloseDialog += () =>
        {
            if (State == GameState.Dialog)
                State = GameState.FreeRoam;
        };
    }

    void Update()
    {
        if (State == GameState.FreeRoam)
            _playerController.CanMove = true;
        else if (State == GameState.Dialog)
        {
            DialogManager.Instance.HandleUpdate();
            _playerController.CanMove = false;
        }

    
    }
}
