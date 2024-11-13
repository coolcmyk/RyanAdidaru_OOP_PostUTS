using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour 
{
    [SerializeField] private float speed; // Berapa cepat Portal bergerak
    [SerializeField] private float rotateSpeed; // Berapa cepat Portal berputar
    private Vector2 newPosition; // Posisi yang dapat di-travel
    LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        ChangePosition();
    }

    void Update()
    {
        // Cek jarak antara posisi portal dan newPosition
        float distance = Vector2.Distance(transform.position, newPosition);
        if (distance < 0.5f)
        {
            ChangePosition();
        }

        // Cek status weapon
        if (Player.Instance.weaponState == true) 
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
        else 
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
        }

        // Rotate dan move portal
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
    }

    private void ChangePosition()
    {
        newPosition = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Gunakan PlayerPrefs untuk menyimpan posisi spawn
            // PlayerPrefs.SetFloat("SpawnX", playerSpawnPoint.x);
            // PlayerPrefs.SetFloat("SpawnY", playerSpawnPoint.y);
            levelManager.LoadScene("Main");
        }
    }
}
