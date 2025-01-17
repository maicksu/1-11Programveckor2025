using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartScreenManager : MonoBehaviour
{
    public string nextSceneName = "MainMenu"; // Name of the main menu scene
    private bool canProceed = true;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        // Check for any key press to transition
        if (canProceed && Input.anyKeyDown)
        {
            ProceedToNextScene();
        }
    }

    void ProceedToNextScene()
    {
        canProceed = false; // Prevent multiple inputs
        SceneManager.LoadScene(nextSceneName);

        // Destroy the Start Screen Manager to ensure it doesn't persist
        Destroy(gameObject);
    }
}
