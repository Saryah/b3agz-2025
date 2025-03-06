using UnityEngine;

public class Interactable : MonoBehaviour
{
    Animator _animator;
    bool isOpen = false;

    [SerializeField] private Collider colliderToDisable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        isOpen = !isOpen;
        _animator.SetBool("Open", isOpen);
        if (colliderToDisable == null)
            return;
        colliderToDisable.enabled = false;
    }
}
