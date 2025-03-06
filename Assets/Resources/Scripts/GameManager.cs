using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject interactionUI, playerPrefab;
    public Text interactionButtonText, interactionTypeText;
    public GameObject optionsMenu;
    public bool inMenu = false;
    public Room room;
    public string spawnTag;
    public bool isSpawning = false;
    public GameObject currentRoom;

    [Space(10)] [Header("Timer")] [Space(10)]
    public Text timer;
    public float minutes = 0;
    public float seconds = 0;
    public float miliseconds = 0;
    
    [Space(10)][Header("Riddle UI")][Space(10)]
    public Image image;

    public Sprite incomplete, complete;
    public Text riddleLine1Text, riddleLine2Text, riddleLine3Text, riddleLine4Text;

    void Awake()
    {
        if(instance != null)
            Destroy(this);
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        inMenu = false;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inMenu = !inMenu;
            CursorStatus();
        }
        optionsMenu.SetActive(inMenu);
        if (room.roomComplete)
        {
            image.sprite = complete;
        }
        else
        {
            image.sprite = incomplete;
        }
    }

    public void ExitMenu()
    {
        inMenu = false;
        CursorStatus();
    }

    public void CursorStatus()
    {
        if (inMenu)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
