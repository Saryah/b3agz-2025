using PSXShaderKit;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Wilberforce;

public class Options : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider masterSlider, bgmSlider, sfxSlider, shaderIntensitySlider, lightIntensitySlider, lightDistanceSlider;
    public Dropdown colorBlindOptions;

    void Start()
    {
        shaderIntensitySlider.value = Camera.main.GetComponent<PSXPostProcessEffect>()._PixelationFactor;
        lightIntensitySlider.value = Camera.main.GetComponent<PSXShaderManager>()._RetroLightingNormalFactor;
        lightIntensitySlider.value = Camera.main.GetComponent<PSXShaderManager>()._RetroLightFalloffStart;
    }
    
    public void MasterVolume(float volume)
    {
        masterSlider.value = volume;
        mixer.SetFloat("Master", volume);
    }

    public void BGMVolume(float volume)
    {
        bgmSlider.value = volume;
        mixer.SetFloat("BGM", volume);
    }

    public void SFXVolume(float volume)
    {
        sfxSlider.value = volume;
        mixer.SetFloat("SFX", volume);
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
    }

    public void LightDistance(float volume)
    {
            lightDistanceSlider.value = volume;
            PSXShaderManager shaders = Camera.main.gameObject.GetComponent<PSXShaderManager>();
            shaders._RetroLightFalloffStart = lightDistanceSlider.value;
    }

    public void ColourBlindNess(int options)
    {
        Colorblind type = Camera.main.gameObject.GetComponent<Colorblind>();
        type.Type = options;
    }
}
