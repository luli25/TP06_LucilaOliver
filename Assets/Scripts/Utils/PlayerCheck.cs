using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCheck : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;

    [SerializeField]
    private EnemyData enemyData;

    [SerializeField]
    private Slider enemyHealth;

    [SerializeField]
    private HealthBarConfig healthBarConfig;

    [SerializeField]
    private GameObject enemyDeathEffect;

    private void Start()
    {
        enemyData.health = enemyData.maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("HeadCheck"))
        {
            enemyData.health -= playerData.damage;
            enemyHealth.value = enemyData.health;

            healthBarConfig.SetHealth(enemyData.health);

            if (enemyData.health <= 0)
            {
                Destroy(transform.parent.gameObject);
                Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);
            }

        }
    }


}
