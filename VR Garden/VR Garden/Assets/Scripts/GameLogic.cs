using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {
    private Scoring scoreboard;
    private GamePools gamePools;
    private List<GameObject> produceCollected;
    private int dirtPileCount;

    private void Start()
    {
        produceCollected = new List<GameObject>(24);
        dirtPileCount = 30;
        scoreboard = GetComponent<Scoring>();
        gamePools = GameObject.Find("GamePools").GetComponent<GamePools>();
    }

    public void AddDirt(Vector3 pos)
    {
        gamePools.PoolObject(pos, "Dirt");
    }

    public GameObject GrowCrops(Vector3 coordinates, string tag)
    {
        int score = 0;
        switch (tag)
        {
            case "Corn":
                score = 50;
                break;
            case "Tomato":
                score = 16;
                break;
            case "Eggplant":
                score = 36;
                break;
            case "Pumpkin":
                score = 80;
                break;
        }

        scoreboard.Score(score);
        return gamePools.PoolObject(coordinates, tag);
    }
}
