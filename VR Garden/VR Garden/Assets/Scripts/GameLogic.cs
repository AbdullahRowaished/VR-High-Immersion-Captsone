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

    public void GrowCrops(Season season)
    {
        DirtPile pileScript;
        foreach (GameObject pile in gamePools.dirtpiles)
        {
            if (pile.activeSelf)
            {
                pileScript = pile.GetComponent<DirtPile>();
                if (pileScript.used)
                {
                    gamePools.PoolObject(pile.transform.position, pileScript.seed.tag);
                    pileScript.seed.SetActive(false);
                }
            }
        }
        pileScript = null;
    }
}
