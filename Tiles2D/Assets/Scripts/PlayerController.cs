using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private int count;

    public float speed;
    public float jumpForce;
    public Text countText;
    public Text winText;
    public Text livesText;
    public AudioSource audio;
    public AudioSource audio2;


    void Start ()
    {

        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        SetCountText();
        winText.text = " ";
        livesText.text = " Lives x3";
    }


    void ExitGame()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
            Debug.Log("Hit Quit Button");
        }
    }


    void Update()
    {
        ExitGame();
    }

   
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {

            other.gameObject.SetActive(false);
            count += 1;

            SetCountText();
        }
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Platforms")
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }


    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

       
        if (count == 4)
        {
            winText.text = "You Win!";
            audio.Stop();
            audio2.Play();

        }
    }

}
