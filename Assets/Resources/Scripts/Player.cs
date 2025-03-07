using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public string playerName = "";
    public float masterVolume, bgmVolume, sfxVolume, shaderIntensity, lightIntensity, lightDistance;
    public int colorBlind;
    public AudioClip[] correct, incorrect, jumping, falling;

    public Animator animator;
    void Awake()
    {
        if(instance != null)
            Destroy(instance);
        instance = this;
        DontDestroyOnLoad(this);
    }
}
