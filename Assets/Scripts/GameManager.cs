using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] grounds;

    public float groundNumbers;
    void Start()
    {
        grounds = GameObject.FindGameObjectsWithTag("Ground");
       
    }

    void Update()
    {
        groundNumbers = grounds.Length;
    }
    
}
