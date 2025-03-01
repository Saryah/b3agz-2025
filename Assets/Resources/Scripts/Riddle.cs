using UnityEngine;

[CreateAssetMenu(fileName = "Riddle", menuName = "Riddle")]
public class Riddle : ScriptableObject
{
    public string riddleLine1, riddleLine2, riddleLine3, riddleLine4;
    public Item redHerring, actualObj;
}
