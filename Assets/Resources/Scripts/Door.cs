using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    Door door;
    public bool needsKey;
    private bool openClose;
    private bool isOpen;
    Animator animator;
    

    void Awake()
    {
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && openClose && !needsKey)
        {
            isOpen = !isOpen;
            animator.SetBool("Open", isOpen);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!needsKey)
        {
            openClose = true;
            GameManager.instance.intactionUI.SetActive(true);
            GameManager.instance.interactionButtonText.text = "E";
            if (isOpen)
                GameManager.instance.interactionTypeText.text = "To Close Door";
            else
                GameManager.instance.interactionTypeText.text = "To Open Door";
        }
    }

    void OnTriggerExit(Collider other)
    {
        openClose = false;
        GameManager.instance.intactionUI.SetActive(false);
        Debug.Log("Exited Doorway");
    }
}
