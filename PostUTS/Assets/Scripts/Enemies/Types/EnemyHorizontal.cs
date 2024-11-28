// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// using UnityEngine;

// public class EnemyHorizontal : Enemy
// {
//     [Header("Movement Settings")]
//     [SerializeField] private float moveSpeed = 5f;
    
//     private bool movingRight;
//     private float screenBoundaryLeft;
//     private float screenBoundaryRight;
//     private Camera mainCamera;

//     private void Start()
//     {
//         base.Start(); // Call Enemy's Start method
        
//         // Get camera and calculate screen boundaries
//         mainCamera = Camera.main;
//         CalculateScreenBoundaries();
        
//         // Random spawn position (left or right side)
//         SpawnAtRandomSide();
//     }

//     private void Update()
//     {
//         // Move the enemy
//         Move();
        
//         // Check for screen boundaries and change direction
//         CheckBoundaries();
//     }

//     private void CalculateScreenBoundaries()
//     {
//         if (mainCamera != null)
//         {
//             float verticalOffset = 1f; // Distance from screen edge
//             Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            
//             screenBoundaryLeft = -screenBounds.x + verticalOffset;
//             screenBoundaryRight = screenBounds.x - verticalOffset;
//         }
//     }

//     private void SpawnAtRandomSide()
//     {
//         // Randomly choose left (0) or right (1) side
//         bool spawnOnRight = Random.Range(0, 2) == 1;
        
//         Vector3 position = transform.position;
        
//         if (spawnOnRight)
//         {
//             position.x = screenBoundaryRight;
//             movingRight = false; // Will move left
//         }
//         else
//         {
//             position.x = screenBoundaryLeft;
//             movingRight = true; // Will move right
//         }
        
//         transform.position = position;
//     }

//     private void Move()
//     {
//         float direction = movingRight ? 1 : -1;
//         transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);
//     }

//     private void CheckBoundaries()
//     {
//         if (transform.position.x >= screenBoundaryRight)
//         {
//             movingRight = false;
//         }
//         else if (transform.position.x <= screenBoundaryLeft)
//         {
//             movingRight = true;
//         }
//     }
// }