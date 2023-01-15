using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GameUI : MonoBehaviour
{
    private bool m_GameStarted = false;
    public int scoreToWin = 10;

    public GameObject m_Ball;
    public TextMeshProUGUI m_PressStart;
    public TextMeshProUGUI m_ScorePlayer;
    public TextMeshProUGUI m_ScoreAdversary;
    public TextMeshProUGUI m_GameOverText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnScore() {
        // Set game over if either player reaches 10 points
        if (int.Parse(m_ScoreAdversary.text) == scoreToWin || int.Parse(m_ScorePlayer.text) == scoreToWin) {
            m_GameOverText.gameObject.SetActive(true);
            m_PressStart.gameObject.SetActive(true);
            m_Ball.GetComponent<BallController>().ResetBall(false);
            return;
        }
        m_Ball.GetComponent<BallController>().ResetBall(true);
    }

    void OnStart() {
        Debug.Log("Start");
        if (m_GameStarted) { return; }
        m_GameStarted = true;
        m_PressStart.gameObject.SetActive(false);
        m_GameOverText.gameObject.SetActive(false);
        m_Ball.GetComponent<BallController>().ResetBall(true);
    }
}
