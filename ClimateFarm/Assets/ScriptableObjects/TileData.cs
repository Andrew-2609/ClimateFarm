using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class TileData : ScriptableObject
{
    public TileBase[] tiles;

    public bool canFreeze;
    public bool canWet;

    public float spreadChanceSnow, spreadChanceRain, spreadIntervall, freezeTime, wetTime;

    public void setSpreadChanceSnow(float spreadChanceSnow)
    {
        this.spreadChanceSnow = spreadChanceSnow;
    }

    public void setSpreadChanceRain(float spreadChanceRain)
    {
        this.spreadChanceRain = spreadChanceRain;
    }

    public float getSpreadChanceSnow()
    {
        return this.spreadChanceSnow;
    }

    public float getSpreadChanceRain()
    {
        return this.spreadChanceRain;
    }
}
