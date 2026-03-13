using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

// Manages the pause menu system including UI display,
// time scaling, and cursor state control.

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu; // Reference to the pause menu UI
    public static bool isPaused = false; // Global pause state

    public void Update()
    {
        // Prevent pausing while interacting with the artefact
        if (ArtefactPuzzleScript.artefactActive)
        {
            return;
        }

        // Toggle pause on Escape key
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (isPaused)
            {
                Resume();
                
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        if (pauseMenu == null) return;

        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Resume()
    {
        if (pauseMenu == null) return;

        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void OpenMainMenu()
    {
        SceneManager.LoadSceneAsync(0); // Load main menu scene
    }
}
