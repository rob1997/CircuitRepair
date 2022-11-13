using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public GridLayoutGroup levelLayout;

    public int sceneOffset;
    
    private void Start()
    {
        foreach (var button in levelLayout.GetComponentsInChildren<Button>())
        {
            if (button.gameObject != gameObject)
            {
                button.onClick.AddListener(delegate { LoadLevel(button.transform.GetSiblingIndex()); });
            }
        }
    }

    public void LoadLevel(int index)
    {
        AudioSource.PlayClipAtPoint(AudioManager.Instance.clickSound2, Vector3.zero);
        
        SceneManager.LoadScene(sceneOffset + index);
    }
}
