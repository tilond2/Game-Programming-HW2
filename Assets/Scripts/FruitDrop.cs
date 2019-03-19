using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitDrop : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject FruitPrefab;
    public float BPM, delay = 0;
    private float seconds;
    // AppleTree Speed
    public float speed = 1f;
    bool gameStarted = false;
    // Distance where AppleTree turns around
    public float leftAndRightEdge = 7.5f;

    // Chance that the apple tree will change direction
    public float chanceToChangeDirections = 0.1f;
    void Start()
    {
        seconds = (60 / BPM);
        Debug.Log("Seconds =: " + seconds);
        

    }
    void DropFruit()
    {
        GameObject fruit = Instantiate<GameObject>(FruitPrefab);
        fruit.transform.position = transform.position;
        Invoke("DropFruit", seconds);
    }
    // Update is called once per frame
    void Update()
    {
        
        if (!gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameStarted = true;
                Invoke("DropFruit", delay);
                
                GameObject audio = GameObject.Find("BGAudio");
                AudioSource song = audio.GetComponent<AudioSource>();
                song.Play();
                Debug.Log("Game started");
            }
        }
        
        
        if (gameStarted)
        {
            
            Vector3 pos = transform.position; // get position
            pos.x += speed * Time.deltaTime; // calculate new position
            transform.position = pos;       // move the tree

            //Changing Direction
            if (pos.x < -leftAndRightEdge)
            { // if we moved all the way to the left
                speed = Mathf.Abs(speed);   // change direction
            }
            else if (pos.x > leftAndRightEdge)
            { // if we moved all the way to the right
                speed = -Mathf.Abs(speed);     // change direction
            }
        }  
    }
    void FixedUpdate()
    {
        //changing direction randomly is now time-based because of FixedUpdate()
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;    // change direction randomly
        }
    }
}

