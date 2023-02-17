using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinjController : MonoBehaviour, IInteractable
{
    [SerializeField] public string StringID;
    [SerializeField] string Name;
    [SerializeField] List<Information> _firstTalk;
    [SerializeField] List<Information> _alreadyTalking;
    [HideInInspector] public bool AlreadyTalking;

    private void Start()
    {
        if (AllInteractable.Instance.IInteractableUses.ContainsValue(StringID))
        {
            this.AlreadyTalking = true;
        }
    }
    public void Execute()
    {
        MainGame.Instance.PinjController = this;

        if (AllInteractable.Instance.IInteractableUses.ContainsValue(StringID) == false)
            AllInteractable.Instance.IInteractableUses.Add(Name, StringID);

        if (AlreadyTalking == false)
            StartCoroutine(DialogManager.Instance.ShowDialog(_firstTalk));
        else if (_alreadyTalking.Count > 0)
            StartCoroutine(DialogManager.Instance.ShowDialog(_alreadyTalking));
        else
            StartCoroutine(DialogManager.Instance.ShowDialog(_firstTalk));
    }
}
