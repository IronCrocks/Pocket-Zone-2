using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public Slider healthBar;

    private void Awake()
    {
        if (healthBar == null)
        {
            return;
        }

        healthBar.maxValue = maxHealth;
        healthBar.value = health;
    }

    public void DealDamage(int damageValue)
    {
        health -= damageValue;

        if (healthBar != null)
        {
            healthBar.value = health;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
