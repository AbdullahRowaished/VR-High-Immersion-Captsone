using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour {
    private int totalScore;

    private void Start()
    {
        totalScore = 0;
    }

    public int Score(Quality quality)
    {
        switch (quality)
        {
            case Quality.LOW:
                totalScore += 10;
                break;
            case Quality.HIGH:
                totalScore += 50;
                break;
        }

        return totalScore;
    }

    public void ResetScore()
    {
        totalScore = 0;
    }
}
