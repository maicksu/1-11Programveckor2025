using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour
{
    public int maxMana = 3; // Maximum mana slots
    private int currentMana; // Current mana
    public float regenRate = 1f; // Time in seconds to regenerate one mana
    public Image[] manaSlots; // Array of mana slot UI images
    public Sprite emptyManaImage; // Empty mana sprite
    public Sprite fullManaImage; // Full mana sprite

    private void Start()
    {
        currentMana = maxMana; // Start with full mana
        UpdateManaUI();
        StartCoroutine(RegenerateMana());
    }

    private void UpdateManaUI()
    {
        for (int i = 0; i < manaSlots.Length; i++)
        {
            if (i < currentMana)
                manaSlots[i].sprite = fullManaImage; // Set to full mana
            else
                manaSlots[i].sprite = emptyManaImage; // Set to empty mana
        }
    }

    private IEnumerator RegenerateMana()
    {
        while (true)
        {
            yield return new WaitForSeconds(regenRate);
            if (currentMana < maxMana)
            {
                currentMana++; // Increment mana
                UpdateManaUI(); // Refresh the UI
            }
        }
    }

    public void UseMana(int amount)
    {
        if (currentMana >= amount)
        {
            currentMana -= amount; // Deduct mana
            UpdateManaUI(); // Refresh the UI
        }
        else
        {
            Debug.Log("Not enough mana!");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) // Press "U" to use mana
        {
            UseMana(1); // Consume 1 mana
        }

        if (Input.GetKeyDown(KeyCode.R)) // Press "R" to regenerate mana instantly
        {
            if (currentMana < maxMana)
            {
                currentMana++;
                UpdateManaUI();
            }
        }
    }
}
