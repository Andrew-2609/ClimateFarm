using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    private Vector3Int position;
    private TileData data;
    private RainManager rainManager;

    [SerializeField]
    private MapManager mapManager;


    private float wetTimeCounter, spreadIntervallCounter;

    public void StartWetting(Vector3Int position, TileData data, RainManager rm)
    {
        this.position = position;
        this.data = data;
        this.rainManager = rm;

        wetTimeCounter = data.wetTime;
        spreadIntervallCounter = data.spreadIntervall;
    }

    private void Update()
    {
        wetTimeCounter -= Time.deltaTime;
        if (wetTimeCounter <= 0)
        {
            rainManager.FinishedWetting(position);
            if(mapManager.getWinter())
            {
                Destroy(gameObject);
            }
        }

        spreadIntervallCounter -= Time.deltaTime;
        if (spreadIntervallCounter <= 0)
        {
            spreadIntervallCounter = data.spreadIntervall;
            rainManager.TryToSpread(position, data.spreadChanceRain);
        }
    }
}
