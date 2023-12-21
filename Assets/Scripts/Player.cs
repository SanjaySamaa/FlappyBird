using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    float speed = 2;
    float jump = 7;
    float gravity = 2;
    public GameObject player;
    Rigidbody2D rb;
    public int score;
    public bool canPlay = true;
     GameManager gameManager;

    public Pipes pipe;
    GameObject gameOverUI;
    public TMP_Text scoreText;
    private int highScore;
    public AudioSource overSound;
    public AudioSource scoreAudio;
    public AudioSource jumpAudio; 

    // Start is called before the first frame update
    void Start()
    {
        
        gameManager = GameObject.FindObjectOfType<GameManager>();
        gameOverUI = GameObject.Find("GameOverImage");
        gameOverUI.SetActive(false);    
       
        rb = player.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

    }

    // Update is called once per frame
    void Update()
    {

        if (canPlay)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector2(speed, jump);
                rb.gravityScale = gravity;
                jumpAudio.Play();

            }
            if (transform.position.y > 5.19f || transform.position.y < -5.19f)
            {
                Debug.Log("mathi tala sound");
                overSound.Play();
                gameManager.GameOver();
                gameOverUI.SetActive(true);

            }
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Score")
        {
            pipe.GeneratePipe();
            score++;
            scoreText.text = score.ToString();
            scoreAudio.Play();
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Pipe")
        {

            gameManager.GameOver();
            canPlay = false;
            gameOverUI.SetActive(true);
            Debug.Log("working");
            overSound.Play();   
        }
    }
}
