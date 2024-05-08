using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer _audioMixer;
    
    public Slider _bgmSlider;
    public Slider _sfxSlider;
    
    public void SetBgmVolume()
    {
        float sound = _bgmSlider.value;
        
        if (sound == -40)
        {
            _audioMixer.SetFloat("BGM", -80);
        }
        else
        {
            _audioMixer.SetFloat("BGM", sound);
        }
    }
    
    public void SetSfxVolume()
    {
        float sound = _sfxSlider.value;
        
        if (sound == -40)
        {
            _audioMixer.SetFloat("SFX", -80);
        }
        else
        {
            _audioMixer.SetFloat("SFX", sound);
        }
    }
}
