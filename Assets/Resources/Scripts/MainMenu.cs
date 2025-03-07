using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Options, Main;
    public InputField nameInput;
    [SerializeField] AudioSource sfxSource;

    void Start()
    {
        MainMenuActive();
    }
    
    public void MainMenuActive()
    {
        Main.SetActive(true);
        Options.SetActive(false);
    }

    public void OptionsActive()
    {
        Main.SetActive(false);
        Options.SetActive(true);
    }

    public void NameInput(string newName)
    {
        nameInput.text = newName;
        Player.instance.playerName = newName;
    }

    public void StartGame()
    {
        if (Player.instance.playerName == "")
        {
            sfxSource.clip = Player.instance.incorrect[Random.Range(0, Player.instance.incorrect.Length)];
            sfxSource.Play();
        }
        else
        {
            sfxSource.clip = Player.instance.correct[Random.Range(0, Player.instance.correct.Length)];
            sfxSource.Play();
            SceneManager.LoadScene("MainGame");
        }
    }
}
