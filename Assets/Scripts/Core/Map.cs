using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Map : Singleton<Map>
{
    [Serializable]
    public struct LogicGoal
    {
        public Wire Wire;

        public bool Value;
    }

    public LogicGoal[] LogicGoals;

    public float time;

    public Button exitButton;

    public Color onColor = Color.green;
    public Color offColor = Color.red;

    public TextMeshProUGUI timerText;
    public Image timerImage;

    public GameObject losePanel;
    public GameObject winPanel;
    
    public Button loseContinueButton;
    public Button winContinueButton;

    private float _timer;

    private bool _stopTimer;
    
    private void Start()
    {
        exitButton.onClick.AddListener(ExitLevel);

        foreach (var goal in LogicGoals)
        {
            goal.Wire.Input.GetComponent<SlotUi>().TurnGoalOn(goal.Value);
        }

        _timer = time;
        
        timerText.text = $"{Math.Round(_timer, 0)}";
        
        loseContinueButton.onClick.AddListener(ExitLevel);
        winContinueButton.onClick.AddListener(ExitLevel);
    }

    public void CheckGoals()
    {
        foreach (var goal in LogicGoals)
        {
            if (goal.Wire.Value != goal.Value)
            {
                return;
            }
        }

        //Win Scenario
        Debug.Log("<color=#00FF00>WIN!!!</color>");
        Win();

        _stopTimer = true;
    }

    private void Update()
    {
        CountTimer();
    }

    private void CountTimer()
    {
        if (_stopTimer) return;
        
        if (_timer <= 0)
        {
            //Lose Scenario
            Lose();

            _stopTimer = true;
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
