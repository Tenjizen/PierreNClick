using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.Collections.Generic;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject buttonSkip;
    public event Action onShowDialog;
    public event Action onCloseDialog;

    [SerializeField] TextMeshProUGUI _dialogNext;
    [SerializeField] TextMeshProUGUI _dialogText;
    [SerializeField] TextMeshProUGUI _nameText;
    [SerializeField] int _lettersPerSecond;

    [SerializeField] private CanvasGroup CanvasDialogBox;


    private List<Information> _info;
    private Action _onDialogueFinished;
    private int _currentLine = 0;
    private int _currentDialog = 0;
    private bool _isTyping;
    private Coroutine _maCoroutine;

    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }


    public IEnumerator ShowDialog(List<Information> info, Action onFinished = null)
    {
        yield return new WaitForEndOfFrame();
        onShowDialog?.Invoke();

        _info = info;

        _onDialogueFinished = onFinished;

        var PNJController = MainGame.Instance.PinjController;
        if (PNJController.AlreadyTalking)
            buttonSkip.SetActive(true);
        else
            buttonSkip.SetActive(false);

        dialogBox.SetActive(true);
        _maCoroutine = StartCoroutine(TypeDialog(info[0].Dialog[0]));
        _nameText.text = info[0].Name;
    }
    public void HandleUpdate()
    {
        var PNJController = MainGame.Instance.PinjController;
        if (_currentLine == _info[_currentDialog].Dialog.Count - 1 && _currentDialog == _info.Count - 1)
            _dialogNext.text = "End - Press E";
        else
            _dialogNext.text = "Next - Press E";

        if (Input.GetKeyDown(KeyCode.E) && !_isTyping)
        {
            _currentLine++;
            if (_currentLine < _info[_currentDialog].Dialog.Count)
                _maCoroutine = StartCoroutine(TypeDialog(_info[_currentDialog].Dialog[_currentLine]));
            else if (_currentDialog < _info.Count - 1)
            {
                _currentDialog++;
                _currentLine = 0;
                _nameText.text = _info[_currentDialog].Name;
                _maCoroutine = StartCoroutine(TypeDialog(_info[_currentDialog].Dialog[_currentLine]));
            }
            else
            {
                _currentDialog = 0;
                _currentLine = 0;
                _onDialogueFinished?.Invoke();
                onCloseDialog?.Invoke();
                MainGame.Instance.PinjController = null;
                if (PNJController.AlreadyTalking == false)
                    PNJController.AlreadyTalking = true;
                dialogBox.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && PNJController.AlreadyTalking)
        {
            _currentDialog = 0;
            _currentLine = 0;
            dialogBox.SetActive(false);
            _onDialogueFinished?.Invoke();
            onCloseDialog?.Invoke();
            StopCoroutine(_maCoroutine);
            MainGame.Instance.PinjController = null;
        }
    }
    public void OnClickNext()
    {
        var PNJController = MainGame.Instance.PinjController;

        if (_currentLine == _info[_currentDialog].Dialog.Count - 1 && _currentDialog == _info.Count - 1)
            _dialogNext.text = "End - Press E";
        else
            _dialogNext.text = "Next - Press E";


        if (!_isTyping)
        {
            _currentLine++;
            if (_currentLine < _info[_currentDialog].Dialog.Count)
                _maCoroutine = StartCoroutine(TypeDialog(_info[_currentDialog].Dialog[_currentLine]));
            else if (_currentDialog < _info.Count - 1)
            {
                _currentDialog++;
                _currentLine = 0;
                _nameText.text = _info[_currentDialog].Name;
                _maCoroutine = StartCoroutine(TypeDialog(_info[_currentDialog].Dialog[_currentLine]));
            }
            else
            {
                _currentDialog = 0;
                _currentLine = 0;
                _onDialogueFinished?.Invoke();
                onCloseDialog?.Invoke();
                MainGame.Instance.PinjController = null;
                if (PNJController.AlreadyTalking == false)
                    PNJController.AlreadyTalking = true;
                dialogBox.SetActive(false);
            }
        }
    }

    public void OnClickSkip()
    {
        _currentDialog = 0;
        _currentLine = 0;
        dialogBox.SetActive(false);
        _onDialogueFinished?.Invoke();
        onCloseDialog?.Invoke();
        StopCoroutine(_maCoroutine);
        MainGame.Instance.PinjController = null;
    }

    public IEnumerator TypeDialog(string line)
    {
        _isTyping = true;
        _dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            _dialogText.text += letter;
            yield return new WaitForSeconds(1f / _lettersPerSecond);
        }
        _isTyping = false;
    }
}


