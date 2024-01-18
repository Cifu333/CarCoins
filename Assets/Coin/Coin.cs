using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool pickeable;
    private bool picked;

    private float pickCounter = 1.5f;


    private void Update()
    {
        pickCounter += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && pickCounter == 1.5)
        {
            for(int i = 0;  i < collision.gameObject.transform.childCount;  i++)
            {
                if (collision.gameObject.transform.GetChild(i).tag == "Trailer")
                {
                    transform.position = collision.gameObject.transform.GetChild(i).transform.position;
                    transform.parent = collision.gameObject.transform.GetChild(i);
                }
            }
        }
    }

    public void SetCounter()
    {
        pickCounter = 0;
    }
}
