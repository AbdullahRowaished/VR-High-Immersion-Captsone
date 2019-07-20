using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {
    public Scoring scoreboard;

    private List<GameObject> produceCollected;
    private int fertilizerCount;

    private void Start()
    {
        produceCollected = new List<GameObject>(24);
        fertilizerCount = 30;
    }


}
