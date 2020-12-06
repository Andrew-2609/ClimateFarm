using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    private Vector3Int position;
    private TileData data;
    private SnowManager snowManager;

    private float freezeTimeCounter, spreadIntervallCounter;

    public void StartFreezing(Vector3Int position, TileData data, SnowManager sm)
    {
        this.position = position;
        this.data = data;
        this.snowManager = sm;

        freezeTimeCounter = data.freezeTime;
        spreadIntervallCounter = data.spreadIntervall;
    }

    private void Update()
    {
        freezeTimeCounter -= Time.deltaTime;
        if(freezeTimeCounter <= 0)
        {
            snowManager.FinishedFreezing(position);
            Destroy(gameObject);
        }

        spreadIntervallCounter -= Time.deltaTime;
        if(spreadIntervallCounter <= 0)
        {
            spreadIntervallCounter = data.spreadIntervall;
            snowManager.TryToSpread(position, data.spreadChanceSnow);
        }
    }
}
