using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitMaze : MonoBehaviour
{
    public GameObject winMenu;
    public Button mainMenuButton;
    public TextMeshProUGUI textboxText;

    void Start()
    {
        mainMenuButton.onClick.AddListener(ReturnToStart);
    }

    void OnTriggerEnter(Collider other)
    {
        winMenu.SetActive(true);
        Time.timeScale = 0;
    }

    void ReturnToStart()
    {
        if (textboxText.text.Length == 4)
        {
            winMenu.SetActive(false);
            Time.timeScale = 1;
            SetHighscores();
            SceneManager.LoadScene("Start");
        }
    }

    void SetHighscores()
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

        int replaceIndex;
        for (replaceIndex = 0; replaceIndex < highscores.Length; replaceIndex++)
        {
            if (ElapsedTime.elapsedTime < highscores[replaceIndex] || highscores[replaceIndex] == 0)
                break; 
        }
        if (replaceIndex < highscores.Length)
        {
            for (int j = highscores.Length - 1; j > replaceIndex; j--)
            {
                highscores[j] = highscores[j - 1];
                PlayerPrefs.SetFloat("Highscore " + (j + 1), highscores[j]);
                names[j] = names[j - 1];
                PlayerPrefs.SetString("Name " + (j + 1), names[j]);
            }
            PlayerPrefs.SetFloat("Highscore " + (replaceIndex + 1), ElapsedTime.elapsedTime);
            PlayerPrefs.SetString("Name " + (replaceIndex + 1), textboxText.text);
            PlayerPrefs.Save();
        }
    }
}
