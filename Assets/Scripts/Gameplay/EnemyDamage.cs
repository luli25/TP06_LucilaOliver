using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private EnemyData enemyData;

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private HealthBarConfig healthBarConfig;

    [SerializeField]
    private Slider health;

    void Start()
    {
        enemyData.health = enemyData.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.TakeDamage(enemyData.damage);
        }
    }

}
