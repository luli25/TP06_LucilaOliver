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

    private void Start()
    {
        enemyData.health = enemyData.maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("HeadCheck"))
        {
            //Destroy(transform.parent.gameObject);

            enemyData.health -= playerData.damage;
            enemyHealth.value = enemyData.health;

            healthBarConfig.SetHealth(enemyData.health);

            if (enemyData.health <= 0)
            {
                Destroy(gameObject);
            }

        }
    }


}
