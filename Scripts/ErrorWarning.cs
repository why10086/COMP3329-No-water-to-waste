using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ErrorWarning : MonoBehaviour
{
    public GameObject confirmPanel;
    public Text errorText;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showError()
    {
        errorText.text = "No enough water!";
        confirmPanel.SetActive(true);
    }

}
