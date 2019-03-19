using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;
    GameObject music;
    private AudioSource song;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("Score");
        GameObject livesGO = GameObject.Find("Lives");
        scoreText = scoreGO.GetComponent<Text>();
        scoreText.text = "0";
        livesText = livesGO.GetComponent<Text>();
        livesText.text = "3";
        music = GameObject.Find("BGAUDIO");
    }

    // Update is called once per frame
    public void StartAudio()
    {
        song = music.GetComponent<AudioSource>();
        song.PlayOneShot(song.clip);
    }
    public void ScoreUpdate(int score)
    {
        int newScore = int.Parse(scoreText.text); // get current score
        newScore += score; // add 100 points to the score
        scoreText.text = newScore.ToString();
    }
    public void LifeUpdate()
    {
        int newLives = int.Parse(livesText.text); // get current lives
        newLives -= 1; // subtract from the lives
        livesText.text = newLives.ToString();
        if (newLives < 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
