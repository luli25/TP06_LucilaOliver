using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Settings : MonoBehaviour
{
    [SerializeField]
    private Button back;

    [SerializeField]
    private GameObject settingsPanel;

    [SerializeField]
    private GameObject pausePanel;

    private void Awake()
    {
        back.onClick.AddListener(OnBackButtonClicked);
    }

    void Update()
    {
        
    }

    private void OnDestroy()
    {
        back.onClick.RemoveAllListeners();
    }

    private void OnBackButtonClicked()
    {
        if(settingsPanel.activeSelf)
        {
            settingsPanel.SetActive(false);
            pausePanel.SetActive(true);
        }
    }
}
