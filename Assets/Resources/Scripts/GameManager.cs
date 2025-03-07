using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string playerName;
    public GameObject[] riddleRooms;
    public int roomsDone;
    private bool gameOver;
    public static GameManager instance;
    public GameObject interactionUI, playerPrefab;
    public Text interactionButtonText, interactionTypeText;
    public GameObject optionsMenu, gameOverMenu;
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
    
    public HighScore highScore;
    public Text playerNameTxt, minutesTxt, secondsTxt, milisecondsTxt;

    void Awake()
    {
        if(instance != null)
            Destroy(this);
        instance = this;
    }

    void Start()
    {
        gameOver = false;
        inMenu = false;
        gameOverMenu.SetActive(false);
        playerName = Player.instance.playerName;
        highScore = Resources.Load("Scriptable Objects/HighScore") as HighScore;
    }

    void Update()
    {
        if (gameOver)
            return;
        if (roomsDone == riddleRooms.Length)
        {
            GameOver();
            return;
        }
        
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

        #region Timer

        if(!inMenu)
        {
            if (miliseconds >= 100)
            {
                if (seconds >= 59)
                {
                    minutes++;
                    seconds = 0;
                }
                else if (seconds <= 59)
                {
                    seconds++;
                }

                miliseconds = 0;
            }

            miliseconds += Time.deltaTime * 100;
        }
        

        //Debug.Log(string.Format("{0}:{1}:{2}", minutes, seconds, (int)miliseconds));
        timer.text = string.Format("{0}:{1}:{2}", minutes, seconds, (int)miliseconds);

        #endregion
    }

    void GameOver()
    {
        gameOver = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playerName = Player.instance.playerName;
        CheckHighScore(minutes, seconds, miliseconds, playerName);
        gameOverMenu.SetActive(true);
        playerNameTxt.text = PlayerPrefs.GetString("PlayerName");
        minutesTxt.text = PlayerPrefs.GetFloat("Minutes").ToString();
        secondsTxt.text = PlayerPrefs.GetFloat("Seconds").ToString();
        milisecondsTxt.text = Mathf.Round(PlayerPrefs.GetFloat("Miliseconds")).ToString();
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

    public void TryAgain()
    {
        Destroy(GameObject.Find("PlayerData"));
        SceneManager.LoadScene("MainMenu");
    }
    public void CheckHighScore(float _minutes, float _seconds, float _miliseconds, string _playerName)
    {
        if (_minutes < PlayerPrefs.GetFloat("Minutes", 5f) ||
            (_minutes == PlayerPrefs.GetFloat("Minutes", 5f) && _seconds < PlayerPrefs.GetFloat("Seconds", 59f)) ||
            (_minutes == PlayerPrefs.GetFloat("Minutes", 5f) && _seconds == PlayerPrefs.GetFloat("Seconds", 59f) && _miliseconds < PlayerPrefs.GetFloat("Miliseconds", 100f)))
        {
            SetHighScore(_minutes, _seconds, _miliseconds, _playerName);
        }
    }

    void SetHighScore(float _minutes, float _seconds, float _miliseconds, string _playerName)
    {
        PlayerPrefs.SetString("PlayerName", _playerName);
        Debug.Log("Player Name set as " + highScore.PlayerName);
        PlayerPrefs.SetFloat("Minutes", _minutes);
        PlayerPrefs.SetFloat("Seconds", _seconds);
        PlayerPrefs.SetFloat("Miliseconds", _miliseconds);
        Debug.Log("Time " + highScore.minutes + " : " + highScore.seconds + " : " + highScore.miliseconds);
    }
}
