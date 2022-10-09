using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameStateBehaviour : MonoBehaviour
{
    [SerializeField]
    private int initialLives = 3;
    private int lives;
    [SerializeField]
    private int initialScore = 0;
    private int score;
    [SerializeField]
    private Text scoreField;
    [SerializeField]
    private GameObject ballPrefab;
    private GameObject ball;

    // Start is called before the first frame update
    public void AddScore(int change)
    {
        score += change;
        Debug.Log("Score: " + score);
        scoreField.text = score.ToString();
    }
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        lives = initialLives;
        score = initialScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (ball == null) RespawnBall();
        
    }
    public void RespawnBall()
    {
        ball=Instantiate(ballPrefab, transform.position, Quaternion.identity);
    }
}
