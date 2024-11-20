using UnityEngine;
using UnityEngine.UI;

public class HealthBarConfig : MonoBehaviour
{
    [SerializeField]
    private Slider healthBarSlider;

    public void SetMaxHealth(float maxHealth)
    {
        healthBarSlider.value = maxHealth;
    }

    public void SetHealth(float health)
    {
        healthBarSlider.value = health;
    }
}
