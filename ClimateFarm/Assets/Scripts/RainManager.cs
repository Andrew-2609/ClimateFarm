using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RainManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private TileBase rainTile;

    [SerializeField]
    private MapManager mapManager;

    [SerializeField]
    private Rain rainObj;

    [SerializeField] private float _duration = 4f;
    private float _timer = 0f;

    private List<Vector3Int> activeRain = new List<Vector3Int>();

    public void FinishedWetting(Vector3Int position)
    {

        if (mapManager.getRain())
        {
            map.SetTile(position, rainTile);
            activeRain.Remove(position);
        }
    }

    public void TryToSpread(Vector3Int position, float spreadChance)
    {
        for (int x = position.x - 1; x < position.x + 2; x++)
        {
            for (int y = position.y - 1; y < position.y + 2; y++)
            {
                TryToWetTile(new Vector3Int(x, y, 0));
            }
        }

        void TryToWetTile(Vector3Int tilePosition)
        {
            if (activeRain.Contains(tilePosition)) return;

            TileData data = mapManager.GetTileData(tilePosition);

            if (data != null && data.canWet)
            {
                if (UnityEngine.Random.Range(0f, 100f) < data.spreadChanceRain)
                {
                    SetTileWet(tilePosition, data);
                }
            }
        }
    }

    private void SetTileWet(Vector3Int tilePosition, TileData data)
    {
        Rain newRain = Instantiate(rainObj);
        newRain.transform.position = map.GetCellCenterWorld(tilePosition);
        newRain.StartWetting(tilePosition, data, this);
        activeRain.Add(tilePosition);
    }

    private void Update()
    {
        if (mapManager.getRain())
        {
            _timer += Time.deltaTime;
            if (_timer >= _duration)
            {
                Vector3Int gridPosition = new Vector3Int(UnityEngine.Random.Range(0, 20), UnityEngine.Random.Range(0, 15), 0);
                TileData data = mapManager.GetTileData(gridPosition);
                SetTileWet(gridPosition, data);
            }
        }
    }

    public int getAtiveRainCount()
    {
        return this.activeRain.Count;
    }
}
