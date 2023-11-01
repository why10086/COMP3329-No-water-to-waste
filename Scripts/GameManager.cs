using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float gameTime = 180.0f;
    public Text timerText;
    public GameObject gameOver;
    private float elapsedTime = 0.0f;
    public GameObject[] objectsToCheck;
    void Start()
    {
        elapsedTime = 0.0f;
    }

    void Update()
    {
        CheckObjects();
        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60.0f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60.0f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (elapsedTime >= gameTime)
        {
            EndGame(false);
        }
    }

    public void CheckObjects()
    {
        bool allObjectsNotFound = true;

        foreach (GameObject obj in objectsToCheck)
        {
            if (obj != null)
            {
                allObjectsNotFound = false;
                break;
            }
        }

        if (allObjectsNotFound)
        {
            EndGame(true);
        }
    }


    void EndGame(bool success)
    {
        if (success)
        {
            gameOver.SetActive(true);

        }
        else
        {
            gameOver.SetActive(true);
            
        }

        enabled = false;
    }
}