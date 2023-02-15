using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinjController : MonoBehaviour, IInteractable
{

    [SerializeField] List<Information> _firstTalk;
    [SerializeField] List<Information> _alreadyTalking;
    public bool AlreadyTalking;

    public void Execute()
    {
        MainGame.Instance.PinjController = this;
        if (AlreadyTalking == false)
            StartCoroutine(DialogManager.Instance.ShowDialog(_firstTalk));
        else
            StartCoroutine(DialogManager.Instance.ShowDialog(_alreadyTalking));
    }
}
