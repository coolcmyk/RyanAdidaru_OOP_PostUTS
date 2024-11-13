using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    
    private bool movingRight;
    private float screenBoundaryLeft;
    private float screenBoundaryRight;
    private Camera mainCamera;

    private void Start()
    {
        base.Start(); 
        
        mainCamera = Camera.main;
        CalculateScreenBoundaries();
        SpawnAtRandomSide();
    }

    private void Update()
    {
        Move();
        CheckBoundaries();
    }

    private void CalculateScreenBoundaries()
    {
        if (mainCamera != null)
        {
            float verticalOffset = 1f;
            Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            
            screenBoundaryLeft = -screenBounds.x + verticalOffset;
            screenBoundaryRight = screenBounds.x - verticalOffset;
        }
    }

    private void SpawnAtRandomSide()
    {
        bool spawnOnRight = Random.Range(0, 2) == 1;
        
        Vector3 position = transform.position;
        
        if (spawnOnRight)
        {
            position.x = screenBoundaryRight;
            movingRight = false;
        }
        else
        {
            position.x = screenBoundaryLeft;
            movingRight = true;
        }
        
        transform.position = position;
    }

    private void Move()
    {
        float direction = movingRight ? 1 : -1;
        transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);
    }

    private void CheckBoundaries()
    {
        if (transform.position.x >= screenBoundaryRight)
        {
            movingRight = false;
        }
        else if (transform.position.x <= screenBoundaryLeft)
        {
            movingRight = true;
        }
    }
}