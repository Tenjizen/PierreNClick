using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [field: SerializeField] public PlayerController Player { get; private set; }
    [field: SerializeField] public CanvasInventory CanvasInventory { get; private set; }
    public const string NextSceneKey = "NextScene";

    [SerializeField] private LayerMask _layerGround;
    [SerializeField] private LayerMask _layerInteractable;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("WTF");
        }
    }

    private void Start()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString(NextSceneKey, "Scene1"), LoadSceneMode.Additive);
        PlayerPrefs.DeleteKey(NextSceneKey);
    }

    private void Update()
    {
        if(MainGame.Instance.State == MainGame.GameState.FreeRoam)
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosWorld = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(mousePosWorld);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, float.MaxValue, _layerInteractable))
            {
                Debug.DrawRay(hit.point, transform.TransformDirection(Vector3.up), Color.green, 10f);
                if (hit.collider != null)
                {
                    IInteractable interactable = hit.collider.GetComponent<IInteractable>();

                    if (interactable != null)
                    {
                        Player.Move(hit.point);
                        Player.Interactable = interactable;
                    }
                }
            }
            else if (Physics.Raycast(ray, out hit, float.MaxValue, _layerGround))
            {
                Debug.DrawRay(hit.point, transform.TransformDirection(Vector3.up), Color.red, 10f);
                Player.Move(hit.point);
                Player.Interactable = null;
            }


        }
    }

    public void AddItem(Item item)
    {
        CanvasInventory.AddItem(item);
    }
}
