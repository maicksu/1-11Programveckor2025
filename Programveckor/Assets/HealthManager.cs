using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider healthBar; // Reference to the Slider UI component
    public Image playerFace; // Reference to the player's face Image component
    public Sprite normalFace; // Sprite for normal expression
    public Sprite injuredFace; // Sprite for injured expression
    public Sprite deadFace; // Sprite for dead expression
    public GameObject deathScreen;

    public float maxHealth = 100f; // Maximum health
    private float currentHealth; // Current health
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        UpdateFace(); // Set the initial face

        if (deathScreen != null)
        {
            deathScreen.SetActive(false); // Ensure the death screen is hidden at the start
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.value = currentHealth;

        UpdateFace(); // Update the face based on health

        if (currentHealth <= 0 && !isDead)
        {
            TriggerDeath();
        }

    }

    private void TriggerDeath()
    {
        isDead = true;

        Time.timeScale = 0f;

        // Activate and fade in the death screen
        if (deathScreen != null)
        {
            deathScreen.SetActive(true);
        }

        Debug.Log("Player has died!");
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.value = currentHealth;

        UpdateFace(); // Update the face based on health
    }

    private void UpdateFace()
    {
        if (currentHealth <= 0)
        {
            playerFace.sprite = deadFace; // Player is dead
        }
        else if (currentHealth <= maxHealth / 2)
        {
            playerFace.sprite = injuredFace; // Health is <= 50%
        }
        else
        {
            playerFace.sprite = normalFace; // Health is > 50%
        }
    }

    void UpdateHealthBar()
    {
        healthBar.value = Mathf.Lerp(healthBar.value, currentHealth, Time.deltaTime * 10f);
    }

    private void Update()
    {
        UpdateHealthBar();

        if (Input.GetKeyDown(KeyCode.Space)) // Press Space to simulate damage
        {
            TakeDamage(10f);
        }
    }
}
