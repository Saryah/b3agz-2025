using System;
using UnityEngine.UI;
using UnityEngine;

public class RoomMessage : MonoBehaviour
{
    public static RoomMessage instance;
    public string riddle1, riddle2, riddle3, riddle4;
    public bool isRiddle = false;
    [SerializeField] private Text riddleText1, riddleText2, riddleText3, riddleText4;
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
        riddleText1.text = riddle1;
        riddleText2.text = riddle2;
        riddleText3.text = riddle3;
        riddleText4.text = riddle4;
    }

    
}
