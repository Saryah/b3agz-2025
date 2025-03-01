using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Riddle riddle;

    public List<Transform> spawnPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int index = Random.Range(0, spawnPoints.Count);
        Instantiate(riddle.actualObj.itemPrefab, spawnPoints[index]);
        Debug.Log( riddle.actualObj.itemPrefab.name+ " is spawned at " + spawnPoints[index].name);
        spawnPoints.RemoveAt(index);
        index = Random.Range(0, spawnPoints.Count);
        Instantiate(riddle.redHerring.itemPrefab, spawnPoints[index]);
        Debug.Log( riddle.redHerring.itemPrefab.name+ " is spawned at " + spawnPoints[index].name);
        spawnPoints.RemoveAt(index);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
