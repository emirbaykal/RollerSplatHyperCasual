using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    private GameManager gm;
    private Vector2 firstPos;
    private Vector2 secondPos;
    
    public Vector2 currentPos;
    public float moveSpeed;
    public Image levelBar;
    public float currentGroundNumber;
    public GameObject ui;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        Swipe();
        levelBar.fillAmount = currentGroundNumber / gm.groundNumbers;

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            if (currentGroundNumber == 18)
            {
                SceneManager.LoadScene("Level2");
            }
            
        }
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            if (currentGroundNumber == 19)
            {
                SceneManager.LoadScene("Level3");
            }
            
        }
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            if (currentGroundNumber == 40)
            {
                SceneManager.LoadScene("Level4");
            }
            
        }
        if (SceneManager.GetActiveScene().name == "Level4")
        {
            if (currentGroundNumber == 38)
            {
                ui.SetActive(true);
            }
            
        }
    }

    private void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            secondPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentPos = new Vector2(
                secondPos.x-firstPos.x,
                secondPos.y-firstPos.y
                );
        }
        currentPos.Normalize();

        if (currentPos.y < 0 && currentPos.x > -0.5f && currentPos.x < 0.5f)
        {
            //back
            rb.velocity = Vector3.back * moveSpeed;
        }else if (currentPos.y > 0 && currentPos.x > -0.5f && currentPos.x < 0.5f)
        {
            //forward
            rb.velocity = Vector3.forward * moveSpeed;
        }else if (currentPos.x < 0 && currentPos.y > -0.5f && currentPos.y < 0.5f)
        {
            //left
            rb.velocity = Vector3.left * moveSpeed;
        }else if (currentPos.x > 0 && currentPos.y > -0.5f && currentPos.y < 0.5f)
        {
            //right
            rb.velocity = Vector3.right * moveSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MeshRenderer>().material.color !=Color.red)
        {
            if (collision.gameObject.tag == "Ground")
            {
                collision.gameObject.GetComponent<MeshRenderer>().material.color=Color.red;
                currentGroundNumber++;
            }
        }
    }

    public void startButton()
    {
        ui.SetActive(false);
    }
    public void exitButton()
    {
        Application.Quit();
    }
    public void restartButton()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            SceneManager.LoadScene("Level1");
        }
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            SceneManager.LoadScene("Level2");
        }
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            SceneManager.LoadScene("Level3");
        }
        if (SceneManager.GetActiveScene().name == "Level4")
        {
            SceneManager.LoadScene("Level4");
        }
    }
}
