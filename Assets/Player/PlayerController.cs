using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Input_Manager inputManager;

    [SerializeField] private float acceleration = 5;
    [SerializeField] private float angularAcceleration = 10;
    private float velocity = 0;

    private enum directions { NONE, UP, DOWN, RIGHT, LEFT };
    private directions dir = directions.NONE;

    private CharacterController characterController;

    SpriteRenderer sr;
    Animator anim;

    private void Start()
    {
        inputManager = Input_Manager._INPUT_MANAGER;

        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

        dir = directions.NONE;
    }

    private void FixedUpdate()
    {
        float horizontal = inputManager.GetLeftAxisValue().x;
        float vertical = inputManager.GetLeftAxisValue().y;

        Debug.Log("Horizontal: " + horizontal + ", Vertical: " + vertical);


        // Determinar la direcci�n
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

        // Actualizar la posici�n del jugador
        UpdatePlayerPosition(horizontal, vertical);

        // Actualizar la animaci�n del jugador
      //  UpdatePlayerAnimation(horizontal, vertical);
    }

    private void UpdatePlayerPosition(float horizontal, float vertical)
    {
        if(horizontal != 0 && (velocity < -1 || velocity > 1))
        {
            transform.Rotate(new Vector3(0, 0, angularAcceleration * -horizontal));
            if (velocity > 0)
            {
                velocity -= acceleration * Time.deltaTime;
            }
            else if (velocity < 0)
            {
                velocity += acceleration * Time.deltaTime;
            }
        }
        else if (horizontal != 0)
        {
            transform.Rotate(new Vector3(0, 0, angularAcceleration * velocity * velocity * -horizontal));
        }
        // Calcular la nueva posici�n del jugador basada en la velocidad y la direcci�n
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
            if (velocity < 0.01f && velocity > -0.01f)
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

        if (velocity > 12)
        {
            velocity = 12;
        }

        if (velocity < -4) 
        {
            velocity = -4;
        }

        Vector3 movement = transform.up * velocity * Time.deltaTime;
        characterController.Move(movement);
        Debug.Log(velocity);
    }

    /* Dani negro esto es una animacon pero es de persona no de coche asi q diria q nada ma�ana lo revisamos uwu
    private void UpdatePlayerAnimation(float horizontal, float vertical)
    {
        // Actualizar la animaci�n del jugador seg�n la direcci�n
        //anim.SetFloat("Horizontal", horizontal);
       // anim.SetFloat("Vertical", vertical);
       // anim.SetFloat("Speed", Mathf.Abs(horizontal) + Mathf.Abs(vertical));
    }
    */
}