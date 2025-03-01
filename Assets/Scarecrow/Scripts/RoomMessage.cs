using System;
using TMPro;
using UnityEngine;

public class RoomMessage : MonoBehaviour
{
    public static RoomMessage instance;
    public string riddle;
    public bool isRiddle = false;
    [SerializeField] private TMP_Text riddleText;
    [SerializeField] private GameObject achievoObj;
    //public Collider[] roomColidersList;

    private void Awake()
    {
        if(instance != null)
            Destroy(gameObject);
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        achievoObj.SetActive(isRiddle);
        riddleText.text = riddle;
    }

    
}
