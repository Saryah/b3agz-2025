using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isCorrect;


    public void PickUp()
    {
        if (isCorrect)
        {
            Destroy(gameObject);
            GameManager.instance.currentRoom.GetComponent<Room>().roomComplete = true;
        }
        else
        {
            GameManager.instance.seconds += 10;
        }
    }
}
