using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    bool isFindedMusic;

    [SerializeField] private Slider slider;

    AudioSource musicSound;

    Music music;
    private void Start()
    {
        music = Music.Instance;
        musicSound = music.GetComponent<AudioSource>();
        slider.value = musicSound.volume;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ChangeSoundLevel()
    {
        musicSound.volume = slider.value;
    }
}
