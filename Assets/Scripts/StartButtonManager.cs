using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonManager : MonoBehaviour
{
    public Button startButton;
    public Button leaderboardButton;
    public Button quitButton;

    void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClicked);
        leaderboardButton.onClick.AddListener(OnLeaderboardButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);
    }

    void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Maze");
    }

    void OnLeaderboardButtonClicked()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
