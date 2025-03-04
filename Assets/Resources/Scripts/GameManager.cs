using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject intactionUI;
    public Text interactionButtonText, interactionTypeText;
    public GameObject optionsMenu;
    public bool inMenu = false;

    void Awake()
    {
        if(instance != null)
            Destroy(this);
        instance = this;
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
