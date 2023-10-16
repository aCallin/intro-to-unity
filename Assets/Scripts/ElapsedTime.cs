using TMPro;
using UnityEngine;

public class ElapsedTime : MonoBehaviour
{
    public GameObject textGameObject;
    TextMeshProUGUI text;
    public static float elapsedTime = 0;

    void Start()
    {
        text = textGameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = (int)(elapsedTime / 60);
        int seconds = (int)(elapsedTime - (minutes * 60));
        float miliseconds = (elapsedTime - (minutes * 60) - seconds) * 100;
        text.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, miliseconds);
    }
}
