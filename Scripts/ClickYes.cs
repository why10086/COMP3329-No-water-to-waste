using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ClickYes : MonoBehaviour
{
    public GameObject confirmPanel; // 确认窗口面板
    public Text confirmText;
    public SimpleSampleCharacterControl player;
    public GameObject gameObject;
    private void Start()
    {
        
    }
    private void Update()
    { 

    }
    public void OnConfirmYes()
    {
        player = GameObject.Find("Character").GetComponent<SimpleSampleCharacterControl>();
        Debug.Log(player.item.ConfirmMessage);
        player.item.Interact(gameObject);

        confirmPanel.SetActive(false);
    }

    public void OnConfirmNo()
    {
        confirmPanel.SetActive(false);
    }

    public void gameOver()
    {
        confirmText.text = "GameOver!";
        confirmPanel.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
