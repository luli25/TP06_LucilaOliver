using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    public List<LootTable> loot = new List<LootTable>();

    private void Start()
    {
        enemyData.health = enemyData.maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("HeadCheck"))
        {
            enemyData.health -= playerData.damage;
            enemyHealth.value = enemyData.health;

            healthBarConfig.SetHealth(enemyData.health);

            if (enemyData.health <= 0)
            {
                foreach (LootTable table in loot)
                {
                    if (Random.Range(0f, 100f) > table.dropChance)
                    {
                        DropLoot(table.itemPrefab);
                    }
                }

                Destroy(transform.parent.gameObject);
                Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);
            }

        }
    }

    private void DropLoot(GameObject loot)
    {
        if (loot)
        {
            GameObject droppedLoot = Instantiate(loot, transform.position, Quaternion.identity);
        }
    }
}
