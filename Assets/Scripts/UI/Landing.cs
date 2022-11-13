using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Landing : MonoBehaviour
{
    public Button playButton;
    
    public Button exitButton;
    
    public Button levelBackdropButton;
    
    public Slider levelRectSlider;
    
    void Start()
    {
        playButton.onClick.AddListener(LoadPlay);
        
        exitButton.onClick.AddListener(ExitGame);
        
        levelBackdropButton.onClick.AddListener(UnLoadPlay);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void LoadPlay()
    {
        playButton.interactable = false;
        
        levelRectSlider.direction = Slider.Direction.Down;
        
        levelRectSlider.Slide(Screen.height);
        
        AudioSource.PlayClipAtPoint(AudioManager.Instance.slideSound, Vector3.zero);
    }
    
    private void UnLoadPlay()
    {
        playButton.interactable = true;

        levelRectSlider.direction = Slider.Direction.Up;
        
        levelRectSlider.Slide(Screen.height);
        
        AudioSource.PlayClipAtPoint(AudioManager.Instance.clickSound, Vector3.zero);
    }
}
