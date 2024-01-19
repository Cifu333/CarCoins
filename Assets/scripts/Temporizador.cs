using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    [SerializeField] int min;
    [SerializeField] float seg;
    [SerializeField] Text tiempo;

    private bool encendido;

    private bool gameOver;

    private void Awake()
    {

    }

    private void Update()
    {
        if (encendido) 
        {
            seg -= Time.deltaTime;
            if (seg <= 0)
            {
                min--;
            }
            int segs = (int)seg;
            tiempo.text = string.Format(min.ToString() + ":" + segs.ToString());
            if (min <= 0 && seg <= 0)
            {
                gameOver = true;
            }
        }
    }

    public bool GetGameOver()
    {
        return gameOver;
    }
}
