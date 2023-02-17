using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    public enum GameState { FreeRoam, Dialog }

    public PlayerController PlayerController;

    public GameState State;

    public PinjController PinjController;

    public static MainGame Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("allo?");
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
            PlayerController.CanMove = true;
        else if (State == GameState.Dialog)
        {
            DialogManager.Instance.HandleUpdate();
            PlayerController.CanMove = false;
        }


    }
}
