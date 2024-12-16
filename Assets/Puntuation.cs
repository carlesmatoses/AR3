using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntuation : MonoBehaviour
{
    float _puntuation=0;

    public TMP_Text puntuationText;
    public TMP_Text timerText;

    private float _timeRemaining = 60;
    private bool _timerIsRunning = false;

    void Start()
    {
        // _timerIsRunning = true;
    }

    public void StartGame()
    {
        _timerIsRunning = true;
    }
    public void StopGame()
    {
        _timerIsRunning = false;
    }
    public void ResetGame()
    {
        _timerIsRunning = false;
        _timeRemaining = 60;
        _puntuation = 0;
        puntuationText.text = (_puntuation * 100).ToString("F0");
		timerText.text = "Time remaining: 0";

        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ball in balls)
        {
            Destroy(ball);
        }
    }
    void EndGame()
    {
        // Code to end the game, e.g., show game over screen
        Debug.Log("Game Over!");
        _timerIsRunning = false;
        
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ball in balls)
        {
            Destroy(ball);
        }


    }
    

    void Update()
    {
        if (_timerIsRunning)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
                timerText.text = "Time remaining: "+ _timeRemaining.ToString("F0");
            }
            else
            {
                _timeRemaining = 0;
                _timerIsRunning = false;
                EndGame();
            }
        }
    }



    public void IncreasePuntuation(float x)
    {
        if(!_timerIsRunning) return;
        _puntuation += x;
        puntuationText.text = (_puntuation * 100).ToString("F0");

    }


}
