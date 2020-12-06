using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainGenerator : MonoBehaviour
{
    [SerializeField]
    private MapManager mapManager;

    [SerializeField]
    private TileData td;

    public ParticleSystem rainParticles;

    private void Start()
    {
        rainParticles = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (!mapManager.getRain())
        {
            td.setSpreadChanceRain(0f);
        } else
        {
            td.setSpreadChanceRain(50f);
        }

        if (mapManager.getRain())
        {
            if (!rainParticles.isPlaying)
            {
                rainParticles.Play();
            }
        }
        else
        {
            rainParticles.Stop();
        }
    }
}
