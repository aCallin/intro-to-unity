using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopulateLeaderboard : MonoBehaviour
{
    public TextMeshProUGUI[] highscoreTexts;
    public Button backButton;

    void Start()
    {
        float[] highscores = {
            PlayerPrefs.GetFloat("Highscore 1"),
            PlayerPrefs.GetFloat("Highscore 2"),
            PlayerPrefs.GetFloat("Highscore 3")
        };
        string[] names = {
            PlayerPrefs.GetString("Name 1"),
            PlayerPrefs.GetString("Name 2"),
            PlayerPrefs.GetString("Name 3")
        };

        for (int i = 0; i < highscores.Length; i++)
        {
            float score = highscores[i];
            string text = (i + 1).ToString() + ". ";
            if (score == 0)
                text += "--";
            else
            {
                int minutes = (int)(score / 60);
                int seconds = (int)(score - (minutes * 60));
                float miliseconds = (score - (minutes * 60) - seconds) * 100;
                text += string.Format("{0} - {1:00}:{2:00}:{3:00}", names[i], minutes, seconds, miliseconds);
            }
            highscoreTexts[i].text = text;
        }

        backButton.onClick.AddListener(ReturnToStart);
    }

    void ReturnToStart()
    {
        SceneManager.LoadScene("Start");
    }
}
