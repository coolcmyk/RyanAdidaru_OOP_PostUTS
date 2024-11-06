using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Player instance;
    PlayerMovement playerMovement;
    Animator animator;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
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

