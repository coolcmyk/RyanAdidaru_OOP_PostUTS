// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EnemyTargeting : Enemy
// {
//     [Header("Movement Settings")]
//     [SerializeField] private float moveSpeed = 5f;
//     [Header("Player Target")]
//     [SerializeField] private Transform player;
    
//     private bool movingDown = true;
//     private float screenBoundaryUp;
//     private float screenBoundaryDown;
//     private Camera mainCamera;

//     private void Start()
//     {
//         base.Start();
//         mainCamera = Camera.main;
//         screenBoundaryUp = mainCamera.orthographicSize;
//         screenBoundaryDown = -mainCamera.orthographicSize + 1f;
//         Boundaries();
//     }
    
//     private void Update()
//     {
//         Kamikaze();
//     }

//     private void Kamikaze()
//     {
//         if (player != null)
//         {
//             Vector3 directionToPlayer = (player.position - transform.position).normalized;
//             transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
//         }
//         else
//         {
//             Debug.LogWarning("Player reference is not set!");
//         }
//     }

//     private void Boundaries()
//     {
//         float randomX = Random.Range(
//             -mainCamera.orthographicSize * mainCamera.aspect + 1f,
//             mainCamera.orthographicSize * mainCamera.aspect - 1f
//         );
        
//         transform.position = new Vector3(
//             randomX,
//             screenBoundaryUp,
//             0f
//         );
//     }
// }
