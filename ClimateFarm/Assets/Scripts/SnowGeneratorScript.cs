using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGeneratorScript : MonoBehaviour
{
    [SerializeField]
    private MapManager mapManager;

    public ParticleSystem snowParticles;

    private void Start()
    {
        snowParticles = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Apertou");
            if(!mapManager.getWinter()) { 
                mapManager.setWinter(true);
            } else
            {
                mapManager.setWinter(false);
            }
            Debug.Log(mapManager.getWinter());
        }
        */

        if (mapManager.getWinter())
        {
            if(!snowParticles.isPlaying)
            {
                snowParticles.Play();
            }
        } else
        {
            snowParticles.Stop();
        }
    }
}
