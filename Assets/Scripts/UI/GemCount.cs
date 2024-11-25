using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemCount : MonoBehaviour
{
    public static GemCount instance;
    public TMP_Text amount;

    public static GemCount Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GemCount>();
            }

            return instance;
        }
    }

    public void UpdateGemCount(int gemAmount)
    {
        amount.text = gemAmount.ToString();
    }
}
