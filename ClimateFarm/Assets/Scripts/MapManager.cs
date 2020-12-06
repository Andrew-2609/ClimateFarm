using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private List<TileData> tileDatas;

    private Dictionary<TileBase, TileData> dataFromTiles;

    private bool isWinter = false;
    private bool isRaining = false;

    [SerializeField]
    private float timeToWinter = 500f;
    [SerializeField]
    private float timeToWin = 500f;

    [SerializeField]
    private Text textCurrentYear;

    [SerializeField]
    private Text textWinterCountdown;

    [SerializeField]
    private Animator sunAnim;

    [SerializeField]
    private Button sunButton;

    [SerializeField]
    private Button rainButton;

    [SerializeField]
    private Image sunBarFill;

    [SerializeField]
    private Image rainBarFill;

    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach(var tileData in tileDatas)
        {
            foreach(var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
    }

    public TileData GetTileData(Vector3Int tilePosition)
    {
        TileBase tile = map.GetTile(tilePosition);

        if(tile == null)
        {
            return null;
        } else
        {
            return dataFromTiles[tile];
        }
    }

    private void Update()
    {
        textCurrentYear.text = "Ano: " + (GameCore.currentLevelIndex - 1);

        timeToWinter -= Time.deltaTime;
        textWinterCountdown.text = "Tempo para o inverno: " + String.Format("{0:00}", timeToWinter) + "s";
        if(timeToWinter <= 0)
        {
            setRaining(false);
            setWinter(true);
            timeToWinter = 0;
        }

        if(timeToWinter == 0)
        {
            timeToWin -= Time.deltaTime;
            textWinterCountdown.color = Color.yellow;
            textWinterCountdown.text = "Fim do ano em: " + String.Format("{0:00}", timeToWin) + "s";
            if (timeToWin <= 0)
            {
                setWinter(false);
                timeToWin = 0;
            }
        }

        rainBarFill.rectTransform.sizeDelta = new Vector2(GameCore.tempoDaChuvaNormal * 4.28f, 5);
        sunBarFill.rectTransform.sizeDelta = new Vector2(GameCore.tempoDoSol * 4.28f, 5);

        if(isRaining)
        {
            if(GameCore.tempoDaChuvaNormal > 0)
            {
                GameCore.tempoDaChuvaNormal -= Time.deltaTime;
                rainButton.GetComponent<Image>().color = Color.green;
            } else
            {
                isRaining = false;
            }
        } else
        {
            if(GameCore.tempoDaChuvaNormal < 7f)
            {
                GameCore.tempoDaChuvaNormal += (Time.deltaTime / GameCore.multiplicadorTempoChuva);
            }
            rainButton.GetComponent<Image>().color = Color.blue;
        }

        if(isWinter)
        {
            rainButton.GetComponent<Image>().color = Color.gray;
        }

        if(sunAnim.GetBool("isSunny"))
        {
            if(GameCore.tempoDoSol > 0)
            {
                GameCore.tempoDoSol -= Time.deltaTime;
                sunButton.GetComponent<Image>().color = Color.black;
            } else
            {
                sunAnim.SetBool("isSunny", false);
            }
        } else
        {
            if(GameCore.tempoDoSol < 7f)
            {
                GameCore.tempoDoSol += (Time.deltaTime / GameCore.multiplicadorTempoSol);
            }
            sunButton.GetComponent<Image>().color = Color.white;
        }
    }

    public void MakeSunny()
    {
        if (!sunAnim.GetBool("isSunny"))
        {
            sunAnim.SetBool("isSunny", true);
        }
    }

    public void MakeRainy()
    {
        if (!isRaining && !isWinter)
        {
            isRaining = true;
        }
    }

    public void setWinter(bool isWinter)
    {
        this.isWinter = isWinter;
    }

    public bool getWinter()
    {
        return this.isWinter;
    }

    public void setRaining(bool isRaining)
    {
        this.isRaining = isRaining;
    }

    public bool getRain()
    {
        return this.isRaining;
    }

    public float getTimeToWin()
    {
        return this.timeToWin;
    }
}
