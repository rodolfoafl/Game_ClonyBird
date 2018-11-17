using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private static int _score;
    public static int _highScore;
    [SerializeField] Text scoreText;

    static public void AddPoint()
    {
        _score++;
        if(_score > _highScore)
        {
            _highScore = _score;
        }
    }

    void Start()
    {
        _score = 0;
        _highScore = PlayerPrefs.GetInt("highScore", 0);
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("highScore", _highScore);
    }

    void Update()
    {
        scoreText.text = "Score: " + _score + "\nHigh Score: " + _highScore;
    }
}
