using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {
    public Scoring scoreboard;
    public GamePools gamePools;
    

    private List<GameObject> produceCollected;
    private int dirtPileCount;

    private void Start()
    {
        produceCollected = new List<GameObject>(24);
        dirtPileCount = 30;
    }

    private void GrowCrops(Season season)
    {
        foreach (GameObject pile in gamePools.dirtpiles)
        {
            DirtPile pileScript = pile.GetComponent<DirtPile>();
            if (pile.activeSelf && pileScript.used)
            {
                gamePools.PoolObject(pile.transform.position, pileScript.seed.tag);
                pileScript.seed.SetActive(false);
            }
        }
    }
}
