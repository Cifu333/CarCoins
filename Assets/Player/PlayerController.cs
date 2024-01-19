using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Input_Manager inputManager;

    [SerializeField] private float acceleration = 5;
    [SerializeField] private float angularAcceleration = 7;
    private float velocity = 0;

    private enum directions { NONE, UP, DOWN, RIGHT, LEFT };
    private directions dir = directions.NONE;

    private Rigidbody2D rb;

    SpriteRenderer sr;
    Animator anim;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        dir = directions.NONE;
    }

    private void Start()
    {
        inputManager = Input_Manager._INPUT_MANAGER;
    }

    private void FixedUpdate()
    {
        float horizontal = inputManager.GetLeftAxisValue().x;
        float vertical = inputManager.GetLeftAxisValue().y;



        // Determinar la dirección
        if (horizontal > 0)
        {
            dir = directions.RIGHT;
        }
        else if (horizontal < 0)
        {
            dir = directions.LEFT;
        }
        else if (vertical > 0)
        {
            dir = directions.UP;
        }
        else if (vertical < 0)
        {
            dir = directions.DOWN;
        }
        else
        {
            dir = directions.NONE;
        }

        // Actualizar la posición del jugador
        UpdatePlayerPosition(horizontal, vertical);

        // Actualizar la animación del jugador
      //  UpdatePlayerAnimation(horizontal, vertical);
    }

    private void UpdatePlayerPosition(float horizontal, float vertical)
    {
        if (vertical != 0)
        {
            rb.AddForce(transform.up * acceleration * vertical);
        }

        if(rb.velocity.magnitude > 12)
        {

        }

        if (horizontal != 0)
        {
            transform.Rotate(new Vector3(0, 0, angularAcceleration * -horizontal));
            rb.velocity = transform.up.normalized * rb.velocity.magnitude;
        }
            /*
            if(horizontal != 0 && (velocity < -1.5 || velocity > 1.5))
            {
                transform.Rotate(new Vector3(0, 0, angularAcceleration * -horizontal));
                if (velocity > 0)
                {
                    velocity -= acceleration / 2 * Time.deltaTime;
                }
                else if (velocity < 0)
                {
                    velocity += acceleration / 2 * Time.deltaTime;
                }
            }
            else if (horizontal != 0)
            {
                transform.Rotate(new Vector3(0, 0, angularAcceleration * velocity / 2 * -horizontal));
            }
            // Calcular la nueva posición del jugador basada en la velocidad y la dirección
            if (vertical != 0) {
                velocity += acceleration * vertical * Time.deltaTime;
                if (vertical < 0 && velocity > 0)
                {
                    velocity -= acceleration * 5 * Time.deltaTime;
                }
                if (vertical > 0 && velocity < 0)
                {
                    velocity += acceleration * 5 * Time.deltaTime;
                }
            }
            else
            {
                if (velocity < 0.1f && velocity > -0.1f)
                {
                    velocity = 0;
                }
                else if (velocity > 0)
                {
                    velocity -= acceleration * Time.deltaTime; 
                }
                else if (velocity < 0)
                {
                    velocity += acceleration * Time.deltaTime;
                }
            }

            if (velocity > 6)
            {
                velocity = 12;
            }

            if (velocity < -4) 
            {
                velocity = -4;
            }

            Vector3 movement = transform.position + transform.up * velocity * Time.deltaTime;
            rb.MovePosition(movement);
            */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Coin")
        {
            for(int i = 0; i < gameObject.transform.childCount; i++)
            {
                if(gameObject.transform.GetChild(i).gameObject.tag == "Coin")
                {
                    gameObject.transform.GetChild(i).gameObject.GetComponent<Coin>().Yeeet();
                }
            }
        }
    }

    /* Dani negro esto es una animacon pero es de persona no de coche asi q diria q nada mañana lo revisamos uwu
    private void UpdatePlayerAnimation(float horizontal, float vertical)
    {
        // Actualizar la animación del jugador según la dirección
        //anim.SetFloat("Horizontal", horizontal);
       // anim.SetFloat("Vertical", vertical);
       // anim.SetFloat("Speed", Mathf.Abs(horizontal) + Mathf.Abs(vertical));
    }
    */
}
