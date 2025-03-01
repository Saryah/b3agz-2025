using System.Collections;
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
    private bool dropOff;
    
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
                GameObject item = hit.collider.gameObject;
                if (item.tag == "RedHerring")
                {
                    NewUI.instance.seconds += 10;
                }

                if (item.tag == "CorrectObject")
                {
                    itemPickedUp = item.gameObject;
                    Player.instance.animator.SetTrigger("Grab");
                    StartCoroutine(AchievoReached(item));
                }
            }
        }
        
    }

    void FindObj()
    {
        
    }
    
    void DisplayObject()
    {
        GameObject objectToHold = Instantiate(itemPickedUp, itemDisplay);;
        objectToHold.tag = "Held";
        //isHolding = true;
        //StartCoroutine(DestroyHeldItem());
    }

    
    IEnumerator AchievoReached(GameObject item)
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(item);
        DisplayObject();
        yield return new WaitForSeconds(1f);
        GameObject objToDestroy = GameObject.FindWithTag("Held");
        Destroy(objToDestroy,.25f);
        itemPickedUp = null;
        
    }
}
