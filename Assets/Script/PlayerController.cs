using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody rb;

    private int count;

    public Text countText;

    public Text winText;

    private bool gameOver = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    private void FixedUpdate()
    {
        if (!gameOver)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
            rb.AddForce(movement * speed);
        } 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Destroy(other.gameObject);

            count++;

            SetCountText();
        }

        else if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);

            gameOver = true;

            SetGameOverText();
        }
    }

    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 10)
        {
            winText.text = "You win!";
        }
    }

    private void SetGameOverText()
    {
        winText.text = "Game Over!";
    }
}
/*if I want walls to be obstacle:
 * 
 private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        SetInstructionText();
    }
 
 void OnTriggerEnter(Collider other)
        if (other.gameObject.CompareTag("Wall"))
        SetEndText();
        (and EndText=You lose!)*/

