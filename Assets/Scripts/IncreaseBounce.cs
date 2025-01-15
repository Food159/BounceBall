using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IncreaseBounce : MonoBehaviour
{
    public Button increaseBttn;
    public Ball ball;

    private void Start()
    {
        increaseBttn.onClick.AddListener(OnButtonClick);
        ball = FindObjectOfType<Ball>();
    }

    private void Update()
    {
        if (ball == null)
        {
            ball = FindObjectOfType<Ball>();
        }
    }
    void OnButtonClick()
    {
            if (ball != null)
            {
            //ball.IncreaseBounciness(0.1f);

            Rigidbody2D rb2d = ball.GetComponent<Rigidbody2D>();
            if (rb2d != null )
            {
                //rb2d.velocity = new Vector2(0f, 8f);
                rb2d.velocity = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
            }
            //Debug.Log("Bounciness increased to: " + ball.bounciness);
            }
    }
}
