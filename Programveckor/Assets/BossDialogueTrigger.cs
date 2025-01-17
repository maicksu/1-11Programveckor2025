using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossDialogueTrigger : MonoBehaviour
{
    public float interactionDistance = 3.0f; // Distance at which the player can interact
    public GameObject dialoguePanel; // The Panel that contains the dialogue UI
    public TMP_Text dialogueText; // The TextMeshPro Text element that will display the dialogue
    public Transform boss; // Reference to the boss's transform

    private bool isDialogueActive = false; // Track if the dialogue is active
    private bool canSkipDialogue = false; // Track if skipping is allowed

    void Update()
    {
        // Check the distance between the player and the boss
        float distance = Vector3.Distance(transform.position, boss.position);

        // If player is close to the boss and dialogue is not active, start the dialogue
        if (distance <= interactionDistance && !isDialogueActive)
        {
            StartDialogue();
        }
    }

    // Start the dialogue automatically when the player is close enough
    void StartDialogue()
    {
        isDialogueActive = true; // Mark the dialogue as active
        dialoguePanel.SetActive(true); // Show the dialogue panel
        canSkipDialogue = true; // Allow skipping once the dialogue is active
        Debug.Log("Dialogue started with the boss.");
    }


    // Call this method when you want to close the dialogue
    void CloseDialogue()
    {
        dialoguePanel.SetActive(false); // Hide the dialogue panel
        isDialogueActive = false; // Mark the dialogue as inactive
        canSkipDialogue = false; // Disable skipping until next dialogue starts
        Debug.Log("Dialogue closed.");
    }
}