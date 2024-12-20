using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Player/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public float currentHealth = 0f;
    public float maxHealth = 100F;
    public int lives = 3;
    public int currentLives = 0;
    public float damage = 20f;
    public float climbSpeed = 5f;
}
