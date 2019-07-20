using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour {
    private int totalScore;

    private void Start()
    {
        totalScore = 0;
    }

    public int Score(int score, Quality quality)
    {
        switch (quality)
        {
            case Quality.LOW:
                totalScore += score;
                break;
            case Quality.HIGH:
                totalScore += 5 * score;
                break;
        }

        return totalScore;
    }

    public void ResetScore()
    {
        totalScore = 0;
    }
}
