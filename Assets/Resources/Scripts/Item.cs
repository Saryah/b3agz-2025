using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public int itemID;
    public GameObject itemPrefab;
    public Sprite itemIcon;
}

public enum ItemType
{
    RedHerring,
    Collection
}
