using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;

    public GameObject PauseMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Ensure proper initialization when the scene starts
    private void Initialize()
    {
        Time.timeScale = 1f;
        Paused = false;
        PauseMenuCanvas.SetActive(false);
        Debug.Log("Game Initialized: Time.timeScale = " + Time.timeScale + ", Paused = " + Paused);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }

    void Stop()
    {
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
        Debug.Log("Game Paused: Time.timeScale = " + Time.timeScale + ", Paused = " + Paused);
    }

    public void Play()
    {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        Debug.Log("Game Resumed: Time.timeScale = " + Time.timeScale + ", Paused = " + Paused);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Debug.Log("Returning to Main Menu");
    }
}