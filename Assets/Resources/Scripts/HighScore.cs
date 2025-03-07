using UnityEngine;

[CreateAssetMenu(fileName = "HighScore", menuName = "High Score")]
public class HighScore : ScriptableObject
{
    public string PlayerName;
    public float minutes, seconds, miliseconds;
    
}
