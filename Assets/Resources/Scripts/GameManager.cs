using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject intactionUI;
    public Text interactionButtonText, interactionTypeText;

    void Awake()
    {
        if(instance != null)
            Destroy(this);
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
