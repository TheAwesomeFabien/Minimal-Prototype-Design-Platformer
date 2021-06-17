using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    public Text winText;
    public Button restartButton;
    public Button exitButton;
    
    // Start is called before the first frame update
    void Start()
    {
        winText.gameObject.SetActive(true);   
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
