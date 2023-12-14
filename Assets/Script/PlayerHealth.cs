using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;
    public float safeTime = 1f;
    float safeTimeCooldown;
    public bool isDead = false;
    private void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        healthBar.UpdateHealth(currentHealth, maxHealth);
    }
    public void TakeDam(int damage)
    {
        if (safeTimeCooldown <= 0)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Destroy(this.gameObject,0.125f);
                isDead = true;
            }
            if(healthBar!= null)
            {
                healthBar.UpdateHealth(currentHealth, maxHealth);
            }
            safeTimeCooldown = safeTime;
        }   
    }
    public void Health(int hp)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += hp;
        }
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (healthBar != null)
        {
            healthBar.UpdateHealth(currentHealth, maxHealth);
        }
    }
    private void Update()
    {
        if (safeTime > 0)
        {
            safeTimeCooldown -= Time.deltaTime;
        }
    }
}
