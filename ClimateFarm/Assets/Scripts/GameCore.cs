using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCore : MonoBehaviour
{
    public static float tempoDaChuvaNormal = 7f;
    public static float multiplicadorTempoChuva = 2;
    public static int qtdChuvasRapidas = 3;
    public static float tempoDoSol = 7f;
    public static float multiplicadorTempoSol = 2;

    public static int currentLevelIndex = 2;

    private void Update()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
