using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool picked;

    private float pickCounter = 1.5f;


    private void Update()
    {
        pickCounter += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && pickCounter >= 1.5)
        {
            for (int i = 0; i < collision.gameObject.transform.childCount; i++)
            {
                if (collision.gameObject.transform.GetChild(i).tag == "Trailer")
                {
                    transform.position = collision.gameObject.transform.GetChild(i).transform.position;
                    transform.parent = collision.gameObject.transform.GetChild(i);
                    picked = true;
                }
            }
        }
    }

    public void SetCounter()
    {
        pickCounter = 0;
    }

    public void IsNotPicked()
    {
        picked = false;
    }
}
