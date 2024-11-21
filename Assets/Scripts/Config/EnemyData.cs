using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    public float health;
    public float maxHealth = 100f;
    public float speed;
    public float damage;
}
