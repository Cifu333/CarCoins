using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour
{
    [SerializeField]
    private Canvas win;
    [SerializeField]
    private Canvas lose;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < collision.gameObject.transform.childCount; i++)
            {
                if (collision.gameObject.transform.GetChild(i).tag == "Coin")
                {
                    win.enabled = true;
                    Destroy(lose);
                }
            }
        }
    }
}
