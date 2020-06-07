using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.5f;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 1;

    // Cached References
    MusicPlayer musicPlayer;

    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficultyLevel();
    }

    // TODO Change this code to run when one of the Sliders changes instead on every frame
    void Update()
    {
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found...did you start from splash screen?");
        }
    }

    public void SaveAndExit()
    {
        // Save the volume level & difficulty before we go back to the Main Menu
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficultyLevel(difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
