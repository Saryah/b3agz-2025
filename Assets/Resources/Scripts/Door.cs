using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    Door door;
    private bool openClose;
    private bool isOpen;
    Animator animator;
    

    void Awake()
    {
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && openClose)
        {
            isOpen = !isOpen;
            animator.SetBool("Open", isOpen);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        openClose = true;
    }

    void OnTriggerExit(Collider other)
    {
        openClose = false;
        Debug.Log("Exited Doorway");
    }
}
