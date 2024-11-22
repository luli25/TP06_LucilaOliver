using UnityEngine;
using UnityEngine.UI;

public class HealthBarConfig : MonoBehaviour
{
    
    private Slider healthBarSlider;

    private void Start()
    {
        {
            healthBarSlider = GetComponentInChildren<Slider>();
        }
    }

    public void SetMaxHealth(float maxHealth)
    {
        healthBarSlider.value = maxHealth;
    }

    public void SetHealth(float health)
    {
        healthBarSlider.value = health;
    }
}
