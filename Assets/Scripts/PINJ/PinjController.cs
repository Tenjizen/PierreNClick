using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinjController : MonoBehaviour, IInteractable
{
    [SerializeField] public string StringID;
    [SerializeField] int IntID;
    [SerializeField] List<Information> _firstTalk;
    [SerializeField] List<Information> _alreadyTalking;
    [HideInInspector] public bool AlreadyTalking;

    private void Start()
    {
        if (AllInteractable.Instance.IInteractableUses.ContainsKey(StringID))
        {
            this.AlreadyTalking = true;
        }
    }
    public void Execute()
    {
        MainGame.Instance.PinjController = this;

        if (AllInteractable.Instance.IInteractableUses.ContainsKey(StringID) == false)
            AllInteractable.Instance.IInteractableUses.Add(StringID, IntID);

        if (AlreadyTalking == false)
            StartCoroutine(DialogManager.Instance.ShowDialog(_firstTalk));
        else
            StartCoroutine(DialogManager.Instance.ShowDialog(_alreadyTalking));
    }
}
