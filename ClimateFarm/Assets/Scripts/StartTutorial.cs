using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTutorial : MonoBehaviour
{
    [SerializeField]
    private GameObject tutorialImage;

    [SerializeField]
    private Sprite[] tutorialImages;

    private int indexTutorialImages = 0;

    public static bool tutorialEnd = false;

    public void StartGame()
    {
        tutorialEnd = true;
    }

    public void ProximaPagina()
    {
        if (indexTutorialImages < tutorialImages.Length - 1)
        {
            indexTutorialImages++;
            tutorialImage.GetComponent<Image>().sprite = tutorialImages[indexTutorialImages];
        }
    }

    public void PaginaAnterior()
    {
        if (indexTutorialImages > 0)
        {
            indexTutorialImages--;
            tutorialImage.GetComponent<Image>().sprite = tutorialImages[indexTutorialImages];
        }
    }
}
