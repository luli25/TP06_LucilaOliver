using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryCollectible : MonoBehaviour
{
    public static event Action<int> OnCherryCollect;

    private int healAmount = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Collect();
        }
    }

    private void Collect()
    {
        OnCherryCollect.Invoke(healAmount);
        Destroy(gameObject);
    }
}
