using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;

   public Text scoreText;
   public Text WinText;
    public Text timeText;

    

    private float seconds;



    private int score;


    private Rigidbody rb;
    private GameObject MoveComponent;

    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
       
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHor, 0, moveVer);

        rb.AddForce(movement * speed);

    }


    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        
        timeText.text = ("TIME " + Mathf.Round(seconds).ToString());

    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUpV1"))
        {
            score = score + 1;
            Destroy(other.gameObject);
            SetScore();

        }

        if (other.gameObject.CompareTag("PickUpV2"))
        {
            score = score + 2;
            Destroy(other.gameObject);
            SetScore();
            
        }



    }

    public void SetScore()
    {
        scoreText.text = ("SCORE: " + score.ToString());

        if (score >= 10)
        {
            WinText.text = ("YOU WIN!");
            GetComponent<PlayerMove>().enabled = false;
        }
    }
}

