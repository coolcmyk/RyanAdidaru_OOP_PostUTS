using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    [SerializeField] Vector2 maxSpeed;
    [SerializeField] Vector2 timeToFullSpeed;
    [SerializeField] Vector2 timeToStop;
    [SerializeField] Vector2 stopClamp;

    Vector2 moveDirection;  
    Vector2 moveVelocity;
    Vector2 moveFriction;
    Vector2 stopFriction;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveVelocity = (2 * maxSpeed / (timeToFullSpeed));
        moveFriction = (-2 * maxSpeed) / (timeToFullSpeed * timeToFullSpeed);
        stopFriction = (-2 * maxSpeed) / (timeToStop * timeToStop);
 
    }

    public void Move()
    {
        //mencakup WASD dan arrow key
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        Vector2 friction = GetFriction(); 
        float SpeedX = moveDirection.x * moveVelocity.x + friction.x;
        float SpeedY = moveDirection.y * moveVelocity.y + friction.y;

        rb.velocity = new Vector2(
            Mathf.Clamp(SpeedX, -maxSpeed.x, maxSpeed.x),
            Mathf.Clamp(SpeedY, -maxSpeed.y, maxSpeed.y)
        );
    }

    Vector2 GetFriction()
    {
        //Idle State
        if (moveDirection == Vector2.zero)
        {
            Vector2 friction = new Vector2(
                -Mathf.Sign(rb.velocity.x) * Mathf.Min(Mathf.Abs(rb.velocity.x), stopFriction.x * 2f * Time.deltaTime),
                -Mathf.Sign(rb.velocity.y) * Mathf.Min(Mathf.Abs(rb.velocity.y), stopFriction.y * 2f * Time.deltaTime)
            );

            // threshold kalau velocity mendekati 0
            if (Mathf.Abs(rb.velocity.x) < 0.1f) friction.x = -rb.velocity.x;
            if (Mathf.Abs(rb.velocity.y) < 0.1f) friction.y = -rb.velocity.y;

            return friction;
        }
        //Move State
        return -moveDirection * moveFriction * Time.deltaTime;
    }
 
    public void MoveBound()
    {
        // Clamp position agar tidak keluar dari layar
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, -10f, 10f),
            Mathf.Clamp(transform.position.y, -10f, 10f)
        );
    }

    public bool isMoving()
    {
        //cek magnitude dari moveDircetion dan velocity dari rigidbody gerak atau ngga
        return moveDirection.magnitude > 0.1f || rb.velocity.magnitude > 0.1f;
    }
}