using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    [SerializeField]
    private GameObject tutorialImage;

    [SerializeField]
    private Sprite[] tutorialImages;

    private int indexTutorialImages = 0;

    [SerializeField]
    private GameObject barsPanel;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        if(!tutorialImage.activeSelf)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            gameIsPaused = false;
            barsPanel.SetActive(true);
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        barsPanel.SetActive(false);
    }

    public void MostrarTutorial()
    {
        indexTutorialImages = 0;
        tutorialImage.GetComponent<Image>().sprite = tutorialImages[0];
        tutorialImage.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void FecharTutorial()
    {
        tutorialImage.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void ProximaPagina()
    {
        if(indexTutorialImages < tutorialImages.Length - 1)
        {
            indexTutorialImages++;
            tutorialImage.GetComponent<Image>().sprite = tutorialImages[indexTutorialImages];
        }
    }

    public void PaginaAnterior()
    {
        if(indexTutorialImages > 0)
        {
            indexTutorialImages--;
            tutorialImage.GetComponent<Image>().sprite = tutorialImages[indexTutorialImages];
        }
    }

    public void QuitGame()
    {
        //Debug.Log("Jogo fechando");
        Application.Quit();
    }
}
