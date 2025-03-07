using PSXShaderKit;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Wilberforce;

public class Options : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider masterSlider, bgmSlider, sfxSlider, shaderIntensitySlider, lightIntensitySlider, lightDistanceSlider;
    public Dropdown colorBlindOptions;

    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
        {
            shaderIntensitySlider.value = Camera.main.GetComponent<PSXPostProcessEffect>()._PixelationFactor;
            lightIntensitySlider.value = Camera.main.GetComponent<PSXShaderManager>()._RetroLightingNormalFactor;
            lightIntensitySlider.value = Camera.main.GetComponent<PSXShaderManager>()._RetroLightFalloffStart;
            Player.instance.masterVolume = masterSlider.value;
            Player.instance.bgmVolume = bgmSlider.value;
            Player.instance.sfxVolume = sfxSlider.value;
            Player.instance.shaderIntensity = shaderIntensitySlider.value;
            Player.instance.lightIntensity = lightIntensitySlider.value;
            Player.instance.lightDistance = lightDistanceSlider.value;
            Player.instance.colorBlind = colorBlindOptions.value;
        }
        else
        {
            masterSlider.value = Player.instance.masterVolume;
            bgmSlider.value = Player.instance.bgmVolume;
            sfxSlider.value = Player.instance.sfxVolume;
            shaderIntensitySlider.value = Player.instance.shaderIntensity;
            lightIntensitySlider.value = Player.instance.lightIntensity;
            lightDistanceSlider.value = Player.instance.lightDistance;
            colorBlindOptions.value = Player.instance.colorBlind;
        }
        Camera.main.gameObject.GetComponent<Colorblind>().Type = Player.instance.colorBlind;
        Camera.main.GetComponent<PSXPostProcessEffect>()._PixelationFactor = Player.instance.shaderIntensity;
        Camera.main.GetComponent<PSXShaderManager>()._RetroLightingNormalFactor = Player.instance.lightIntensity;
        Camera.main.GetComponent<PSXShaderManager>()._RetroLightFalloffStart = Player.instance.lightDistance;
        
    }
    
    public void MasterVolume(float volume)
    {
        masterSlider.value = volume;
        mixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        Player.instance.masterVolume = masterSlider.value;
    }

    public void BGMVolume(float volume)
    {
        bgmSlider.value = volume;
        mixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
        Player.instance.bgmVolume = bgmSlider.value;
    }

    public void SFXVolume(float volume)
    {
        sfxSlider.value = volume;
        mixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        Player.instance.sfxVolume = sfxSlider.value;
    }

    public void ShaderIntensity(float volume)
    {
        shaderIntensitySlider.value = volume;
        PSXPostProcessEffect shaders = Camera.main.gameObject.GetComponent<PSXPostProcessEffect>();
        shaders._PixelationFactor = shaderIntensitySlider.value;
    }

    public void LightIntensity(float volume)
    {
        lightIntensitySlider.value = volume;
        PSXShaderManager shaders = Camera.main.gameObject.GetComponent<PSXShaderManager>();
        shaders._RetroLightingNormalFactor = lightIntensitySlider.value;
        Player.instance.lightIntensity = lightIntensitySlider.value;
    }

    public void LightDistance(float volume)
    {
            lightDistanceSlider.value = volume;
            PSXShaderManager shaders = Camera.main.gameObject.GetComponent<PSXShaderManager>();
            shaders._RetroLightFalloffStart = lightDistanceSlider.value;
            Player.instance.lightDistance = lightDistanceSlider.value;
    }

    public void ColourBlindNess(int options)
    {
        Colorblind type = Camera.main.gameObject.GetComponent<Colorblind>();
        type.Type = options;
        Player.instance.colorBlind = options;
    }
}
