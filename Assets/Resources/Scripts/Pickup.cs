using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isCorrect;


    public void PickUp()
    {
        AudioSource audio = GameObject.FindWithTag("SFX").GetComponent<AudioSource>();
        Debug.Log(audio.gameObject.name);
        if (isCorrect)
        {
            Destroy(gameObject);
            GameManager.instance.currentRoom.GetComponent<Room>().roomComplete = true;
            GameManager.instance.roomsDone++;
            AudioClip clipToPlay = Player.instance.correct[Random.Range(0, Player.instance.correct.Length)];
            audio.PlayOneShot(clipToPlay);
        }
        else
        {
            GameManager.instance.seconds += 10;
            AudioClip clipToPlay = Player.instance.incorrect[Random.Range(0, Player.instance.incorrect.Length)];
            audio.PlayOneShot(clipToPlay);
        }
    }
}
