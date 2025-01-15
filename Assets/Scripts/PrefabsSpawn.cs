using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrefabsSpawn : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Vector2 spawnPos;
    [SerializeField] private TextMeshProUGUI ballCounttxt;
    private int currentBall = 0;
    private int maxBall = 30;
    void Start()
    {
        //OnSpawnPrefab();
        UpdateBallCounttxt();
    }
    void Update()
    {
        
    }
    public void OnSpawnPrefab(Vector3 spawnPos)
    {
        if (currentBall < maxBall)
        {
            GameObject newball = Instantiate(prefab, spawnPos, Quaternion.identity);
            Rigidbody2D rb2d = newball.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                rb2d.velocity = new Vector2(5f, 5f);
            }

            FindObjectOfType<IncreaseBounce>().ball = newball.GetComponent<Ball>();
            currentBall++;
            UpdateBallCounttxt();
        }
    }
    public void DecreaseBall()
    {
        if (currentBall > 0)
        {
            currentBall--;
            UpdateBallCounttxt();
        }
    }
    private void UpdateBallCounttxt()
    {
        if (ballCounttxt != null) 
        {
            ballCounttxt.text = $"{currentBall + 1}/{maxBall}";
        }
    }
}
