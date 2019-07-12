using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePools : MonoBehaviour {
    public static List<GameObject> dirtpiles, pumpkins, eggplants, tomatoes, corn;
    private static bool pooled;

    private void Start()
    {
        dirtpiles = new List<GameObject>(GameObject.FindGameObjectsWithTag("Dirt"));
        pumpkins = new List<GameObject>(GameObject.FindGameObjectsWithTag("Pumpkin"));
        eggplants = new List<GameObject>(GameObject.FindGameObjectsWithTag("Eggplant"));
        tomatoes = new List<GameObject>(GameObject.FindGameObjectsWithTag("Tomato"));
        corn = new List<GameObject>(GameObject.FindGameObjectsWithTag("Corn"));

        foreach (GameObject dirt in dirtpiles)
        {
            dirt.SetActive(false);
        }

        foreach (GameObject pumpkin in pumpkins)
        {

            pumpkin.SetActive(false);
        }

        foreach (GameObject eggplant in eggplants)
        {

            eggplant.SetActive(false);
        }

        foreach (GameObject tomato in tomatoes)
        {

            tomato.SetActive(false);
        }

        foreach (GameObject cob in corn)
        {
            cob.SetActive(false);
        }
    }

    public static GameObject PoolObject(Vector3 coordinates, string tag)
    {
        List<GameObject> pool;
        pool = dirtpiles;
        switch (tag)
        {
            case "Dirt":
                pool = dirtpiles;
                break;
            case "Pumpkin":
                pool = pumpkins;
                break;
            case "Eggplant":
                pool = eggplants;
                break;
            case "Tomato":
                pool = tomatoes;
                break;
            case "Corn":
                pool = corn;
                break;
        }
        pool = dirtpiles;
        pooled = false;

        foreach (GameObject item in dirtpiles)
        {
            if (!item.activeSelf)
            {
                item.transform.SetPositionAndRotation(coordinates, item.transform.rotation);
                item.SetActive(true);
                pooled = true;
                return item;
            }
        }

        if (!pooled)
        {
            pool.Add(Instantiate(pool[0]));
            GameObject item = pool[pool.Count - 1];
            item.transform.SetPositionAndRotation(coordinates, item.transform.rotation);
            item.SetActive(true);
            return item;
        }

        return null;
    }
}
