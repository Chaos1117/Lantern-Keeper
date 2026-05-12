using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    Slider volumeSlider;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Load();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(volumeSlider != null)
        {
            volumeSlider.value = AudioListener.volume;
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        float savedVolume = PlayerPrefs.GetFloat("musicVolume", 1f);
        AudioListener.volume = savedVolume;
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
        PlayerPrefs.Save();
    }
}
