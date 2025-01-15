using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public GameObject[] hearts; // Array to hold references to the heart GameObjects
    private int lives;

    void Start()
    {
        lives = hearts.Length; // Initialize lives to the number of hearts
    }

    // Call this function when a life is lost
    public void LoseLife()
    {
        if (lives > 0)
        {
            lives--; // Decrease the life count
            hearts[lives].SetActive(false); // Hide the corresponding heart
        }
    }

    // Example function to reset lives
    public void ResetLives()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(true); // Make all hearts visible again
        }
        lives = hearts.Length; // Reset the life count
    }
}
