using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
    public Animator animator;
    public bool isOpen;
    [SerializeField] Collider collider;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("Open", isOpen);
        if (collider == null)
            return;
        if(isOpen)
            collider.enabled = false;
        else
            collider.enabled = true;
    }
    
    public void OpenDoor()
    {
        isOpen = !isOpen;
    }
}
