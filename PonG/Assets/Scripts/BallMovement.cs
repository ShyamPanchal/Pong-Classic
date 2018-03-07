using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour {

    Rigidbody2D rb;
	public int maxScore=3;
    public float speed;
    bool flag;
    float t;
	public Text player1Score;
	public Text player2Score;
	// Use this for initialization
	void Start () {
		player1Score.text = "0";
		player2Score.text = "0";
        rb = this.gameObject.GetComponent<Rigidbody2D>();
		float side = Random.value > 0.5f ? 1f : -1f;
		float rotation = Random.value;
		if (rotation < 0.5f && rotation > -0.5f) {
			rotation = (rotation/-rotation) *0.5f;
		}
		rb.velocity = new Vector2(side,rotation)* speed;
        flag = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (flag)
        {
            t = 0.0f;
        }
        else
        {
            t += Time.deltaTime;
        }
        if (t > 3.0f)
        {
            flag = true;
			float side = Random.value > 0.5f ? 1f : -1f;
			float rotation = Random.value;
			if (rotation < 0.3f && rotation > -0.3f) {
				rotation = (rotation/-rotation) *0.35f;
			}
			rb.velocity = new Vector2(side,rotation)* speed;
			//throws the ball
        }
    }

    private void FixedUpdate()
    {
        
        if(rb.transform.position.x > 9f || rb.transform.position.x < -9f)
        {
			if (rb.transform.position.x > 8.5f) {
				player1Score.text = (int.Parse(player1Score.text) + 1).ToString();
			} else {
				player2Score.text = (int.Parse(player2Score.text) + 1).ToString();
			}
            rb.position = new Vector2(0.0f,0.0f);
            flag = false;
            rb.velocity = new Vector2(0f,0f) * speed;
			//holds the ball back at the center.
        }
		if (int.Parse(player1Score.text) == maxScore || int.Parse(player2Score.text) == maxScore) {
			if (int.Parse (player1Score.text) == maxScore) {
				player1Score.text = "Win";
			}
			if (int.Parse (player2Score.text) == maxScore) {
				player2Score.text = "Win";
			}
			Destroy (this.gameObject);	
			//game end situation
		}
			
    }
}
