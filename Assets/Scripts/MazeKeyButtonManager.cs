using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MazeKeyButtonManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button resumeButton;
    public Button restartButton;
    public Button mainMenuButton;
    public Button quitButton;

    void Start()
    {
        ElapsedTime.elapsedTime = 0;
        resumeButton.onClick.AddListener(OnResumeButtonClicked);
        restartButton.onClick.AddListener(OnRestartButtonClicked);
        mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.activeSelf)
                Pause();
            else
                Unpause();
        }
    }

    void OnResumeButtonClicked()
    {
        Unpause();
    }

    void OnRestartButtonClicked()
    {
        Unpause();
        SceneManager.LoadScene("Maze");
    }

    void OnMainMenuButtonClicked()
    {
        Unpause();
        SceneManager.LoadScene("Start");
    }

    void OnQuitButtonClicked()
    {
        Application.Quit();
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    void Unpause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
