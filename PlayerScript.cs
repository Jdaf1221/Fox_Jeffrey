using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;
    
    public float speed;
    private int Score;
    private int Lives;

    public Text ScoreText;
    public Text winText;
    public Text LivesText;

    public AudioClip musicClipOne;

    public AudioSource musicSource;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
       
        Score = 0;
        winText.text = "";
        SetscoreText();
        Lives = 3;
        SetLivesText() ;
        
        anim = GetComponent<Animator>();

       
    }

    //Lives to string
    
    void SetLivesText()
    {
        if (Lives == 0)
        {
            winText.text = "You Lose!";
            Destroy(this);


        }
        LivesText.text = "Lives: " + Lives.ToString();
        
    }

   

    // movement

    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));

        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetInteger("State", 1);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
           
            anim.SetInteger("State", 0);

        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetInteger("State", 2);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {

            anim.SetInteger("State", 0);

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetInteger("State", 1);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {

            anim.SetInteger("State", 0);

        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            Vector3 theScale = transform.localScale;
            theScale.x = (float)-.4;
            transform.localScale = theScale;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 theScale = transform.localScale;
            theScale.x = (float)+.4;
            transform.localScale = theScale;
        }

    }

    //collision

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            Destroy(collision.collider.gameObject);
            Score = Score + 1;
            SetscoreText();
            ScoreText.text ="Score: " + Score.ToString();

            


        }
        if (collision.collider.tag == "enemy")
        {
            Destroy(collision.collider.gameObject);
            Lives = Lives - 1;
            SetLivesText();
        }
        if (Score == 4)
        {
            Lives = 3;
            SetLivesText();
        }

    }

    // jump vector

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);
            }
        }
    }

    //score to string

    void SetscoreText()
    {

        if (Score == 4)
        {

            transform.position = new Vector2(50.0f, 50.0f);
        }


        ScoreText.text = "Score: " + Score.ToString();
            if (Score >= 8)
            {
            winText.text = "You Win, created By: Jeff Fox!";
            
                    musicSource.clip = musicClipOne;
                    musicSource.Play();
                    
                
            }

    }


    //quit

        private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}