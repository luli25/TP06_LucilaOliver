using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCounter : MonoBehaviour
{
    [SerializeField]
    private Image[] lifeImages;

    [SerializeField]
    private PlayerData playerData;

    public void LoseLife()
    {
        playerData.currentLives--;
        lifeImages[playerData.currentLives].enabled = false;

        if (playerData.currentLives == 0)
        {
            Debug.Log("Game Over!");
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            LoseLife();
        }
    }
}
