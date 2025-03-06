using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Riddle riddle;
    public GameObject correctItem, wrongItem;
    public List<Transform> itemSpawnPoints;
    public bool roomComplete = false;

    void Awake()
    {
        correctItem = riddle.actualObj.itemPrefab;
        wrongItem = riddle.redHerring.itemPrefab;
    }
    void Start()
    {
        GameManager.instance.room = this;
        var randNum = Random.Range(0, itemSpawnPoints.Count);
        correctItem.GetComponent<Pickup>().isCorrect = true;
        Instantiate(correctItem, itemSpawnPoints[randNum]);
        itemSpawnPoints.RemoveAt(randNum);
        randNum = Random.Range(0, itemSpawnPoints.Count);
        Instantiate(wrongItem, itemSpawnPoints[randNum]);
    }
    void OnTriggerEnter(Collider other)
    {
        GameManager.instance.riddleLine1Text.text = riddle.riddleLine1;
        GameManager.instance.riddleLine2Text.text = riddle.riddleLine2;
        GameManager.instance.riddleLine3Text.text = riddle.riddleLine3;
        GameManager.instance.riddleLine4Text.text = riddle.riddleLine4;
        GameManager.instance.room = this;
        GameManager.instance.currentRoom = gameObject;
        
    }

    void OnTriggerExit(Collider other)
    {
        
    }
}
