using UnityEngine;
using UnityEngine.UI;
public class NewUI : MonoBehaviour
{
    public static NewUI instance;
    public Text timer;
    public float minutes = 0;
    public float seconds = 0;
    public float miliseconds = 0;

    void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;
    }

    void Update()
    {

        if (miliseconds >= 100)
        {
            if (seconds >= 59)
            {
                minutes++;
                seconds = 0;
            }
            else if (seconds <= 59)
            {
                seconds++;
            }

            miliseconds = 0;
        }

        miliseconds += Time.deltaTime * 100;

        //Debug.Log(string.Format("{0}:{1}:{2}", minutes, seconds, (int)miliseconds));
        timer.text = string.Format("{0}:{1}:{2}", minutes, seconds, (int)miliseconds);
    }
}
