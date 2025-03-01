using UnityEngine;

[CreateAssetMenu(fileName = "Riddle", menuName = "Riddle")]
public class Riddle : ScriptableObject
{
    public string riddle;
    public Item redHerring, actualObj;
}
