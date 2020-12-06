using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreenScript : MonoBehaviour
{
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button devsButton;
    [SerializeField]
    private Button exitButton;

    [SerializeField]
    private GameObject devsPanel;

    public void StartGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void SeeDevelopers()
    {
        devsPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToStart()
    {
        devsPanel.SetActive(false);
    }
}
