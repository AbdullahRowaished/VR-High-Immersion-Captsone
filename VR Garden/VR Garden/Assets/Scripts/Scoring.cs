using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {
    private int totalScore, tomatoes, corn, eggplants, pumpkins;
    Text text;

    private void Start()
    {
        totalScore = tomatoes = corn = eggplants = pumpkins = 0;
        text = GameObject.Find("ScoreMenu").GetComponent<Text>();
    }

    public int Score(int score)
    {
        switch (score)
        {
            case 36:
                eggplants += score;
                break;
            case 50:
                corn += score;
                break;
            case 16:
                tomatoes += score;
                break;
            case 80:
                pumpkins += score;
                break;
        }
        totalScore += score;
        UpdateScores();

        return totalScore;
    }

    private void UpdateScores()
    {
        text.text = "Tomatoes :            " + tomatoes + "$\nEggplants:           " + eggplants + "$\nCorn:                     " + corn + "$\nPumpkins:             " + pumpkins + "$\n\n              ----\nTotal:        " + totalScore + "$";

    }

    public void ResetScore()
    {
        totalScore = 0;
    }
}
