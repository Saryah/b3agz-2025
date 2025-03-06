using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class PlayerLook : MonoBehaviour
{
    public float InteractRange;
    public string InteractableTag, DoorTag, PickupTag;
    
    void Start()
    {
        
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, InteractRange))
        {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
            if (hit.collider.gameObject.CompareTag("Untagged"))
                return;
            if (hit.collider.gameObject.CompareTag(InteractableTag))
            {
                GameManager.instance.interactionButtonText.text = "E";
                GameManager.instance.interactionTypeText.text = "To Interact";
                GameManager.instance.interactionUI.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject _target = hit.collider.gameObject;
                    Interact(_target);
                }
            }

            else if (hit.collider.gameObject.CompareTag(DoorTag))
            {
                GameManager.instance.interactionButtonText.text = "E";
                GameManager.instance.interactionTypeText.text = "To Move To Next Room";
                GameManager.instance.interactionUI.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject _target = hit.collider.gameObject;
                    Interact(_target);
                }
            }
            else if (hit.collider.gameObject.CompareTag(PickupTag))
            {
                GameManager.instance.interactionButtonText.text = "E";
                GameManager.instance.interactionTypeText.text = "To Pick Up Item";
                GameManager.instance.interactionUI.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject _target = hit.collider.gameObject;
                    Interact(_target);
                }
            }
        }
        else
        {
            GameManager.instance.interactionUI.SetActive(false);
        }
    }

    void Interact(GameObject other)
    {
        Debug.Log(other.name);
        Door hasDoor = other.GetComponent<Door>();
        Interactable hasInteractable = other.GetComponent<Interactable>();
        Pickup hasPickup = other.GetComponent<Pickup>();

        if (hasDoor == null && hasInteractable == null && hasPickup == null)
            return;
        if (hasDoor != null)
        {
            hasDoor.OpenDoor();
        }

        if (hasInteractable != null)
        {
            hasInteractable.Interact();
        }

        if (hasPickup != null)
        {
            hasPickup.PickUp();
        }
    }
}
