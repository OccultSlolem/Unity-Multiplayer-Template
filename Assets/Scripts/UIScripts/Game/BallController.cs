using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{
    public GameObject m_Canvas; // The canvas that contains the score / press start / game over text
    public TextMeshProUGUI m_PlayerScoreText;
    public TextMeshProUGUI m_AdversaryScoreText;
    public float speed = 30;
    private Rigidbody2D rb2d;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void RandomDirection() {
        // Randomize the direction of the ball
        float x = Random.Range(0, 2) == 0 ? 0.10f : -0.10f;
        float y = Random.Range(0, 2) == 0 ? 0.10f : -0.10f;
        rb2d.velocity = new Vector2(x, y) * speed;
    }

    public void ResetBall(bool invoke) {
        // Reset the ball to the center of the screen
        transform.position = Vector2.zero;
        rb2d.velocity = Vector2.zero;
        if (invoke) { Invoke("RandomDirection", 2); return; }
    }

    void OnCollisionEnter2D(Collision2D col) {
        // North/South wall and Paddle collisions are handled by physics engine (see BallMaterial)

        switch (col.collider.name) {
            case "WallW":
                // Increase the score of the adversary  
                int adversaryScore = int.Parse(m_AdversaryScoreText.text);
                adversaryScore++;
                m_AdversaryScoreText.text = adversaryScore.ToString();
                m_Canvas.GetComponent<GameUI>().OnScore();
                break;
            case "WallE":
                // Increase the score of the player
                int playerScore = int.Parse(m_PlayerScoreText.text);
                playerScore++;
                m_PlayerScoreText.text = playerScore.ToString();
                m_Canvas.GetComponent<GameUI>().OnScore();
                break;
            default:
                break;
        }
    }

    void FixedUpdate() {
        // If the ball goes off the screen, reset it
        if(transform.position.x < -10 || transform.position.x > 10) {
            ResetBall(true);
            Invoke("RandomDirection", 2);
        }
    }
}
