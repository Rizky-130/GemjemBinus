using UnityEngine;

public class CollisionReset : MonoBehaviour
{
    public GameManager gameManager;
    public Transform spawnPoint;
    public CursorController cursor;
    public HealthPoint healthpoint;
    public AudioSource alarm;

    public float damageCooldown = 1f;
    float lastDamageTime = -999f;
    void OnCollisionEnter2D(Collision2D collision)
        {
            if (!gameManager.gameStarted)
                return;

            if (healthpoint != null && healthpoint.currentHealth <= 0)
                return;

            if (collision.gameObject.CompareTag("Wall"))
            {
                if (Time.time - lastDamageTime >= damageCooldown)
                {
                    Debug.Log("KENA!");

                    healthpoint.TakeDamage(1);
                    alarm.Play();

                    lastDamageTime = Time.time;

                    cursor.ResetToSpawn(spawnPoint.position);
                }
            }
        }
}