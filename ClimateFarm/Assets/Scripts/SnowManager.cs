using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SnowManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private TileBase snowTile;

    [SerializeField]
    private MapManager mapManager;

    [SerializeField]
    private Snow snowObj;

    [SerializeField] private float _duration = 4f;
    private float _timer = 0f;

    private List<Vector3Int> activeSnow = new List<Vector3Int>();

    public void FinishedFreezing(Vector3Int position)
    {
        map.SetTile(position, snowTile);
        activeSnow.Remove(position);
    }

    public void TryToSpread(Vector3Int position, float spreadChance)
    {
        for(int x = position.x - 1; x < position.x + 2; x++)
        {
            for(int y = position.y - 1; y < position.y + 2; y++)
            {
                TryToFreezeTile(new Vector3Int(x, y, 0));
            }
        }

        void TryToFreezeTile(Vector3Int tilePosition)
        {
            if (activeSnow.Contains(tilePosition)) return;

            TileData data = mapManager.GetTileData(tilePosition);

            if(data != null && data.canFreeze)
            {
                if(UnityEngine.Random.Range(0f, 100f) < data.spreadChanceSnow)
                {
                    SetTileFreeze(tilePosition, data);
                }
            }
        }
    }

    private void SetTileFreeze(Vector3Int tilePosition, TileData data)
    {
        Snow newSnow = Instantiate(snowObj);
        newSnow.transform.position = map.GetCellCenterWorld(tilePosition);
        newSnow.StartFreezing(tilePosition, data, this);

        activeSnow.Add(tilePosition);
    }

    private void Update()
    {
        if(mapManager.getWinter()) {
            _timer += Time.deltaTime;
            if (_timer >= _duration)
            {
                Vector3Int gridPosition = new Vector3Int(UnityEngine.Random.Range(0, 20),UnityEngine.Random.Range(15,10),0);
                TileData data = mapManager.GetTileData(gridPosition);
                SetTileFreeze(gridPosition, data);
            }
        }
    }

    public int getAtiveSnowCount()
    {
        return this.activeSnow.Count;
    }
}
