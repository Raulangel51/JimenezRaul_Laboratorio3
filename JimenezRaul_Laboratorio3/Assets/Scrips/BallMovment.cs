using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovment : MonoBehaviour
{
    //variables
    Rigidbody rb;
    public GameObject player;
    private GameObject player2;
    private float powerUp = 0;
    private bool exist; 
    public float force;
    public float jumpForce;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        rb = GetComponent<Rigidbody>();
        player2 = gameObject;
        exist = true;
        //Instantiate(player);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && Time.timeScale > 0.0f)
        {
            Jump();
        }
        else if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey("enter") || Input.GetKey(KeyCode.KeypadEnter) && !exist && Time.timeScale > 0.0f)
        {
            //gameObject.active = true;
            //Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere));
            player = player2;
            exist = true;
        }
        if(scoreText)
        {
            scoreText.text = "Score: " + powerUp.ToString();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle") && powerUp == 0)
        {
            Destroy(gameObject);
            //gameObject.active = false;
            exist = false;
        }
        else if(collision.gameObject.CompareTag("Power"))
        {
            Destroy(collision.gameObject);
            powerUp++;
        }

    }

    private void FixedUpdate()
    {
        if(rb && Time.timeScale > 0.0f)
        {
            rb.AddForce(Input.GetAxis("Horizontal") * force, 0, Input.GetAxis("Vertical") * force);
        }
    }

    private void Jump()
    {
        if (rb)
        {
            if(Mathf.Abs(rb.velocity.y) < 0.5f)
            {
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            }
        }
    }
}
