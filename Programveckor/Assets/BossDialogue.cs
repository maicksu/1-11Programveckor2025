using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossDialogue : MonoBehaviour
{
    [Header("Dialogue Settings")]
    public GameObject chatBoxUI; // The chat box panel
    public TextMeshProUGUI chatText; // Text for the chat box
    public string[] dialogueLines; // Lines of dialogue
    public float dialogueSpeed = 2f; // Time between auto-advance

    private int currentLine = 0;
    private bool isInDialogue = true;

    [Header("Speaker Icon (Optional)")]
    public Image speakerIcon; // Image for the speaker
    public Sprite bossIcon; // Sprite for the boss
    public Sprite playerIcon; // Sprite for the player

    [Header("References")]
    public GameObject boss; // Boss GameObject
    public MonoBehaviour bossAI; // Boss AI script
    public GameObject player; // Player GameObject
    public MonoBehaviour playerController; // Player control script

    void Start()
    {
        chatBoxUI.SetActive(false);
        // Disable boss and player control at the start
        bossAI.enabled = false;
        playerController.enabled = false;

        // Start the dialogue sequence
        StartDialogue();
    }

    void Update()
    {
        // Allow player to press Space to advance dialogue
        if (isInDialogue && chatBoxUI.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            AdvanceDialogue();
        }
    }

    public void StartDialogue()
    {
        chatBoxUI.SetActive(true); // Show the chat box
        chatText.text = dialogueLines[currentLine]; // Display the first line

        // Optional: Set the speaker icon to boss initially
        if (speakerIcon != null && bossIcon != null)
        {
            speakerIcon.sprite = bossIcon;
        }

        isInDialogue = true;
    }

    public void AdvanceDialogue()
    {
        currentLine++;

        if (currentLine < dialogueLines.Length)
        {
            // Update the chat text
            chatText.text = dialogueLines[currentLine];

            // Optional: Switch the speaker icon (if applicable)
            if (speakerIcon != null)
            {
                if (currentLine == 1 && playerIcon != null) // Example: Second line is the player
                {
                    speakerIcon.sprite = playerIcon;
                }
                else if (currentLine == 3 && bossIcon != null) // Example: Fourth line is the boss
                {
                    speakerIcon.sprite = bossIcon;
                }
            }
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        chatBoxUI.SetActive(false); // Hide the chat box
        isInDialogue = false;

        // Enable boss and player controls
        bossAI.enabled = true;
        playerController.enabled = true;
    }
}
