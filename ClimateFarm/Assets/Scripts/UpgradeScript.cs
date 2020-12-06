using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour
{
    [SerializeField]
    private Image rainBlockActual;
    [SerializeField]
    private Image cloudsBlockActual;
    [SerializeField]
    private Image sunBlockActual;

    [SerializeField]
    private Text textQtdChuvas;
    [SerializeField]
    private Text textQtdNuvens;
    [SerializeField]
    private Text textTimeSun;

    [SerializeField]
    private Button buttonUpgradeRain;
    [SerializeField]
    private Button buttonUpgradeClouds;
    [SerializeField]
    private Button buttonUpgradeSun;

    public static bool upgradeEnd = false;

    private void Update()
    {
        rainBlockActual.rectTransform.sizeDelta = new Vector2(273, 30);
        textQtdChuvas.text = GameCore.tempoDaChuvaNormal * GameCore.multiplicadorTempoChuva + "s";

        cloudsBlockActual.rectTransform.sizeDelta = new Vector2(39 * GameCore.qtdChuvasRapidas, 30);
        textQtdNuvens.text = GameCore.qtdChuvasRapidas + "";

        sunBlockActual.rectTransform.sizeDelta = new Vector2(273, 30);
        textTimeSun.text = GameCore.tempoDoSol * GameCore.multiplicadorTempoSol + "s";

        if(GameCore.multiplicadorTempoChuva <= 0.5f)
        {
            buttonUpgradeRain.GetComponent<Image>().color = Color.gray;
            buttonUpgradeRain.enabled = false;
        }

        if(GameCore.qtdChuvasRapidas >= 7)
        {
            buttonUpgradeClouds.GetComponent<Image>().color = Color.gray;
            buttonUpgradeClouds.enabled = false;
        }

        if(GameCore.multiplicadorTempoSol <= 0.5f)
        {
            buttonUpgradeSun.GetComponent<Image>().color = Color.gray;
            buttonUpgradeSun.enabled = false;
        }
    }

    public void UpgradeRain()
    {
        if(GameCore.multiplicadorTempoChuva > 0.5f)
        {
            GameCore.multiplicadorTempoChuva -= 0.25f;
        }
    }

    public void UpgradeClouds()
    {
        if(GameCore.qtdChuvasRapidas < 7)
        {
            GameCore.qtdChuvasRapidas += 1;
        }
    }

    public void UpgradeSun()
    {
        if(GameCore.multiplicadorTempoSol > 0.5f)
        {
            GameCore.multiplicadorTempoSol -= 0.25f;
        }
    }

    public void NextLevel()
    {
        upgradeEnd = true;
        GameCore.currentLevelIndex += 1;
    }
}
