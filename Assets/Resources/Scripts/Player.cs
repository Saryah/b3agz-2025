using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public Animator animator;
    void Awake()
    {
        if(instance != null)
            Destroy(instance);
        instance = this;
        animator = GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
