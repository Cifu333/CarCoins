using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool picked;

    private float pickCounter = 1.5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


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
                    transform.parent = collision.gameObject.transform;
                    picked = true;
                    rb.isKinematic = true;
                }
            }
        }
    }

    public void Yeeet()
    {
        picked = false;
        pickCounter = 0;
        transform.parent = null;
        rb.isKinematic = false;
        rb.AddForce(new Vector2(Random.Range(-3000f, 3000f), Random.Range(-3000f, 3000f)));
    }
}
