using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Canvas canvas;
    float score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void ChangeScore(float amount) {
        score += amount;
    }

    public void ResetScore() {
        score = 0;
    }

    public float GetScore() {
        return score;
    }
}
