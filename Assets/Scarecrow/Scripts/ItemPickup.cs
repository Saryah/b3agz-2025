using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Camera cam;

    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask itemLayer;
    
    [SerializeField] private GameObject itemPickedUp;
    [SerializeField] private Transform itemDisplay;
    private bool isHolding;
    RaycastHit hit;
    Ray ray;
    
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        
        ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, rayDistance, itemLayer))
        {
            Debug.Log(hit.collider.gameObject.name);
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject tmpItem = hit.collider.gameObject;
                itemPickedUp = Resources.Load("Prefabs/" + tmpItem.name) as GameObject;
                Destroy(hit.collider.gameObject);
            }
        }

        if (!isHolding && itemPickedUp != null)
            DisplayObject();
    }

    void FindObj()
    {
        
    }
    
    void DisplayObject()
    {
        Instantiate(itemPickedUp, itemDisplay);
        isHolding = true;
    }
}
