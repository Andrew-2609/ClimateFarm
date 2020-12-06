using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public MapManager mapManager;
    public float transitionTime = 1f;
    private int currentLevel;

    void Update()
    {
        if(mapManager.getTimeToWin() <= 0)
        {
            mapManager.setRaining(false);
            mapManager.setWinter(false);
            GameCore.tempoDoSol = 7f;
            GameCore.tempoDaChuvaNormal = 7f;
            //SceneManager.LoadScene("Tela de Upgrades");
            if(GameCore.currentLevelIndex < 6)
            {
                StartCoroutine(LoadLevel(6));
            }
            //LoadNextLevel();
        }

        if(StartTutorial.tutorialEnd)
        {
            StartTutorial.tutorialEnd = false;
            LoadNextLevel();
        }

        if(UpgradeScript.upgradeEnd == true)
        {
            UpgradeScript.upgradeEnd = false;
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        //StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        StartCoroutine(LoadLevel(GameCore.currentLevelIndex));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
