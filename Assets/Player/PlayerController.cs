using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Input_Manager inputManager;

    [SerializeField] private float speed = 5;

    private enum directions { NONE, UP, DOWN, RIGHT, LEFT };
    private directions dir = directions.NONE;

    SpriteRenderer sr;
    Animator anim;

    private void Start()
    {
        inputManager = Input_Manager._INPUT_MANAGER;

        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

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
        UpdatePlayerAnimation(horizontal, vertical);
    }

    private void UpdatePlayerPosition(float horizontal, float vertical)
    {
        // Calcular la nueva posici�n del jugador basada en la velocidad y la direcci�n
        Vector3 movement = new Vector3(horizontal, vertical, 0f);
        transform.position += movement * speed * Time.fixedDeltaTime;
    }

    private void UpdatePlayerAnimation(float horizontal, float vertical)
    {
        // Actualizar la animaci�n del jugador seg�n la direcci�n
        anim.SetFloat("Horizontal", horizontal);
        anim.SetFloat("Vertical", vertical);
        anim.SetFloat("Speed", Mathf.Abs(horizontal) + Mathf.Abs(vertical));
    }
}
