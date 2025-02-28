using UnityEngine;
using TMPro;
public class NewUI : MonoBehaviour
{
    public TMP_Text timer;
    float minutes = 0;
    float seconds = 0;
    float miliseconds = 0;

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
