using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    PlayerMovement playerMovement;
    Animator animator;


    public bool weaponState = false;

    void Awake()
    {
        if (Instance == null)
          
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = transform.Find("Engine").Find("EngineEffect").GetComponent<Animator>();
        weaponState = false;
    }

    void FixedUpdate()
    {
        playerMovement.Move();
        playerMovement.MoveBound();
    }

    void LateUpdate()
    {
        animator.SetBool("isMoving", playerMovement.isMoving());
    }
}

