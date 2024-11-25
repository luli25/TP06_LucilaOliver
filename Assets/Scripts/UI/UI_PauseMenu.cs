using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UI_PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Button resume;

    [SerializeField]
    private Button settings;

    [SerializeField]
    private Button exit;

    [SerializeField]
    private GameObject panelPause;

    [SerializeField]
    private GameObject settingsPanel;

    private bool isPaused = false;

    private void Awake()
    {
        resume.onClick.AddListener(OnResumeButtonClicked);
        settings.onClick.AddListener(OnSettingsButtonClicked);
        exit.onClick.AddListener(ExitPlayMode);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();

            if(!panelPause.activeSelf)
            {
                panelPause.SetActive(true);

            } else if(panelPause.activeSelf)
            {
                panelPause.SetActive(false);
            }
        }
    }

    private void OnDestroy()
    {
        resume.onClick.RemoveAllListeners();
        settings.onClick.RemoveAllListeners();
        exit.onClick.RemoveAllListeners();
    }

    private void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;

        }
        else
        {
            Time.timeScale = 0f;
            isPaused = true;
        }
    }

    private void OnResumeButtonClicked()
    {
        if(panelPause.activeSelf)
        {
            TogglePause();
            panelPause.SetActive(false);
            settingsPanel.SetActive(false);
        }
    }

    private void OnSettingsButtonClicked()
    {
        if(!settingsPanel.activeSelf)
        {
            settingsPanel.SetActive(true);
            panelPause.SetActive(false);
        }
    }

    private void ExitPlayMode()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }

}
