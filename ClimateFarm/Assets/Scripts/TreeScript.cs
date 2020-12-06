using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float _duration = 4f;
    private float _timer = 0f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _duration)
        {
            _timer = 0f;
            if(anim.GetBool("isWinter") == true)
            {
                anim.SetBool("isWinter", false);
            } else
            {
                anim.SetBool("isWinter", true);
            }
        }
    }
}
