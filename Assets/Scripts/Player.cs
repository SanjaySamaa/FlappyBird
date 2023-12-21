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
    public int highScores = 0;
    public TMP_Text highScore;

    public AudioSource overSound;
    public AudioSource scoreAudio;
    public AudioSource jumpAudio;
    Animator anim;
    float rotation;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("idle", false);
        gameManager = GameObject.FindObjectOfType<GameManager>();
        gameOverUI = GameObject.Find("GameOverImage");
        gameOverUI.SetActive(false);    
        highScore.gameObject.SetActive(false);
        rb = player.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        highScores = PlayerPrefs.GetInt("HighScore");
        highScore.transform.GetChild(0).GetComponent<TMP_Text>().text = highScores.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if (canPlay)
        {
            if(rb.velocity.y > 0 && rotation < 30)
            {
                rotation += 4;
                transform.eulerAngles = new Vector3(0, 0, rotation);
            }
            if (rb.velocity.y < 0 && rotation > -30)
            {
                rotation -= 4;
                transform.eulerAngles = new Vector3(0, 0, rotation);
            }
            highScore.gameObject.SetActive(true);
            anim.SetBool("idle", true);
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
            if(score > highScores)
            {
                highScores = score;
                highScore.transform.GetChild(0).GetComponent<TMP_Text>().text = highScores.ToString();
                //highScore.GetComponentInChildren<TMP_Text>().text = $"HighScore: {highScores}";
                PlayerPrefs.SetInt("HighScore", highScores);
                //int a = PlayerPrefs.GetInt("HighScore");
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Pipe")
        {
            if (canPlay)
            {
                overSound.Play();
            }
            gameManager.GameOver();
            
            canPlay = false;
            gameOverUI.SetActive(true);
          
            
        }
    }
}
