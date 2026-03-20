using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDetection : MonoBehaviour
{
    public Tilemap tilemap;
    public AudioSource alarmSound;
    public HealthPoint healthPoint;
    [Header("Damage Settings")]
    public float damageInterval = 1f; // tiap 1 detik kena lagi
    float damageTimer = 0f;

    bool isOut = false;


    void Update()
    {
        Vector3 worldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldpos.z = 0f;

        Vector3Int cellPos = tilemap.WorldToCell(worldpos);

        if (!tilemap.HasTile(cellPos))
        {
            // Keluar jalur
            if (!isOut)
            {
                healthPoint.TakeDamage(1);
                alarmSound.Play();
                isOut = true;
            }

            // Damage berulang
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageInterval)
            {
                healthPoint.TakeDamage(1);
                alarmSound.Play();
                damageTimer = 0f;
            }
        }
        else
        {
            // Balik ke jalur
            if (isOut)
            {
                alarmSound.Stop();
                isOut = false;
            }

            damageTimer = 0f; // reset timer
        }
    }
}