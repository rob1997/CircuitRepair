using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Map : Singleton<Map>
{
    public float time;
    
    public bool stopTimer;

    public Button exitButton;

    public Color onColor = Color.green;
    public Color offColor = Color.red;

    public TextMeshProUGUI timerText;
    public Image timerImage;

    public GameObject losePanel;
    public GameObject winPanel;
    
    public Button loseContinueButton;
    public Button winContinueButton;

    public Transform outletsParent;
    
    public Transform inletsParent;
    
    public Transform componentsParent;

    private float _timer;
    
    private void Start()
    {
        exitButton.onClick.AddListener(ExitLevel);

        _timer = time;
        
        timerText.text = $"{Math.Round(_timer, 0)}";
        
        loseContinueButton.onClick.AddListener(ExitLevel);
        winContinueButton.onClick.AddListener(ExitLevel);

        if (stopTimer)
        {
            timerImage.gameObject.SetActive(false);
        }
    }

    public void CheckGoals()
    {
        foreach (Dock dock in inletsParent.GetComponentsInChildren<Dock>())
        {
            if (!dock.gameObject.activeSelf || dock.Socket == null || Math.Abs(dock.goal - dock.value) > .05f)
            {
                return;
            }
        }

        //Win Scenario
        Debug.Log("<color=#00FF00>WIN!!!</color>");
        Win();

        stopTimer = true;
    }

    private void Update()
    {
        CountTimer();
    }

    private void CountTimer()
    {
        if (stopTimer) return;
        
        if (_timer <= 0)
        {
            //Lose Scenario
            Lose();

            stopTimer = true;
        }

        else
        {
            timerText.text = $"{Math.Round(_timer, 0)}";

            float progress = _timer / time;
            
            timerImage.fillAmount = Mathf.Clamp(progress, 0 , 1f);

            if (progress < .25f)
            {
                timerImage.color = Color.red;
            }
            
            _timer -= Time.deltaTime;
        }
    }
    
    public void ExitLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void Lose()
    {
        losePanel.SetActive(true);
        
        AudioSource.PlayClipAtPoint(AudioManager.Instance.loseSound, Vector3.zero);
    }

    public void Win()
    {
        winPanel.SetActive(true);
        
        AudioSource.PlayClipAtPoint(AudioManager.Instance.winSound, Vector3.zero);
    }
}
