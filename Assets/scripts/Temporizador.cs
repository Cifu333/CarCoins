using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    [SerializeField] int min, seg;
    [SerializeField] Text tiempo;

    private float restante;
    private bool encendido;

    private void Awake()
    {
        restante = (min * 60) + seg;
    }

    private void Update()
    {
        if (encendido) 
        {
            restante += Time.deltaTime;
            if (restante < 1 )
            {
                //game over
            }
            int tempMin = Mathf.FloorToInt( restante /60);
            int temoSeg = Mathf.FloorToInt( tempMin % 60 );
            tiempo.text = string.Format("")
        }
    }
}
