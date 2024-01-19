using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    [SerializeField] int min;
    [SerializeField] float seg;
    [SerializeField] TextMeshProUGUI tiempo;
    [SerializeField] Canvas lose;
    [SerializeField] Canvas win;

    private bool encendido = true;

    private bool gameOver;

    private void Awake()
    {

    }

    private void Start()
    {
        lose.enabled = false;
        win.enabled = false;
    }

    private void Update()
    {
        if (encendido) 
        {
            seg -= Time.deltaTime;
            if (seg <= 0)
            {
                min--;
                seg = 59;
            }
            int segs = (int)seg;
            tiempo.text = string.Format(min.ToString() + ":" + segs.ToString());
            if (min <= 0 && seg <= 0)
            {
                lose.enabled = true;
                Destroy(win);
            }
        }
    }

    public bool GetGameOver()
    {
        return gameOver;
    }
}
