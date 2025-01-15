using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private PhysicsMaterial2D ph2d;
    private Collider2D col2d;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;
    PrefabsSpawn SpawnPrebs;
    public float bounciness;

    void Start()
    {
        col2d = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        if (col2d != null)
        {
            ph2d = new PhysicsMaterial2D();
            ph2d.bounciness = 1f;
            bounciness = ph2d.bounciness;
            col2d.sharedMaterial = ph2d;
        }
        else
        {
            Debug.LogWarning("Collider2D not found on the GameObject.");
        }
        if (rb2d != null)
        {
            rb2d.velocity = new Vector2(5f, 5f);
        }
        SpawnPrebs = FindObjectOfType<PrefabsSpawn>();
    }
    private void Update()
    {
        if (transform.localScale == new Vector3(1f, 1f, 0.3f))
        {
            Vector2 currentPosition = transform.position;
            Destroy(gameObject);
            SpawnPrebs.OnSpawnPrefab(currentPosition);
            SpawnPrebs.OnSpawnPrefab(currentPosition);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (ph2d != null)
            {
                //ph2d.bounciness += 0.1f;
                transform.localScale += new Vector3(0.1f, 0.1f, 0);
                Debug.Log("Bounciness increased to: " + ph2d.bounciness);
            }
            if (spriteRenderer != null)
            {
                spriteRenderer.color = new Color(
                    Random.Range(0f, 1f),
                    Random.Range(0f, 1f),
                    Random.Range(0f, 1f),
                    1f
                );
            }
            else
            {
                Debug.LogWarning("PhysicsMaterial2D is not assigned.");
            }
            SoundManager.soundManager.PlaySound();
        }
    }
    public void IncreaseBounciness(float value)
    {
        bounciness += value;
        ph2d.bounciness = bounciness;
    }
    private void OnDestroy()
    {
        PrefabsSpawn spawnManager = FindObjectOfType<PrefabsSpawn>();
        if (spawnManager != null)
        {
            spawnManager.DecreaseBall();
        }
    }
}
