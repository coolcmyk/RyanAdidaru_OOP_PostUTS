// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EnemyForward : Enemy
// {
//     [Header("Movement Settings")]
//     [SerializeField] private float moveSpeed = 5f;
    
//     private bool movingDown = true;
//     private float screenBoundaryUp;
//     private float screenBoundaryDown;
//     private Camera mainCamera;

//     private void Start()
//     {
//         base.Start();
//         mainCamera = Camera.main;
//         screenBoundaryUp = mainCamera.orthographicSize; // batas atas
//         screenBoundaryDown = -mainCamera.orthographicSize + 1f; // batas bawah
//         SpawnAtTop();
//     }
    
//     private void Update()
//     {
//         Move();
//         CheckBoundaries();
//     }

//     private void CheckBoundaries()
//     {
//         if (transform.position.y <= screenBoundaryDown)
//         {
//             movingDown = false;
//         }
//         else if (transform.position.y >= screenBoundaryUp)
//         {
//             movingDown = true;
//         }
//     }
    
//     private void Move()
//     {
//         float direction = movingDown ? -1 : 1;
//         transform.Translate(Vector2.up * direction * moveSpeed * Time.deltaTime);
//     }
    
//     private void SpawnAtTop()
//     {
//         float randomX = Random.Range(
//             -mainCamera.orthographicSize * mainCamera.aspect + 1f,
//             mainCamera.orthographicSize * mainCamera.aspect - 1f
//         );
        
//         transform.position = new Vector3(
//             randomX,
//             0f,
//             0f
//         );
//     }
// }