using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePools : MonoBehaviour {
    public List<GameObject> dirtpiles, pumpkins, eggplants, tomatoes, corn;
    private bool pooled;

    private void Start()
    {
        dirtpiles = new List<GameObject>(GameObject.FindGameObjectsWithTag("Dirt"));
        pumpkins = new List<GameObject>(GameObject.FindGameObjectsWithTag("Pumpkin"));
        eggplants = new List<GameObject>(GameObject.FindGameObjectsWithTag("Eggplant"));
        tomatoes = new List<GameObject>(GameObject.FindGameObjectsWithTag("Tomato"));
        corn = new List<GameObject>(GameObject.FindGameObjectsWithTag("Corn"));

        for (int i = 0; i < 16; i++)
        {
            dirtpiles[i].SetActive(false);
            pumpkins[i].SetActive(false);
            corn[i].SetActive(false);
            tomatoes[i].SetActive(false);
            eggplants[i].SetActive(false);

            int c = i + 1;
            dirtpiles[i].name = "Dirt " + c;
            pumpkins[i].name = "Pumpkin " + c;
            corn[i].name = "Corn " + c;
            tomatoes[i].name = "Tomato " + c;
            eggplants[i].name = "Eggplant " + c;
        }
    }

    public GameObject PoolObject(Vector3 coordinates, string tag)
    {
        List<GameObject> pool;
        GameObject pooledObject = null;
        pool = null;
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

        pooled = false;

        foreach (GameObject item in pool)
        {
            if (!item.activeSelf)
            {
                item.transform.SetPositionAndRotation(coordinates, item.transform.rotation);
                item.SetActive(true);
                pooled = true;
                pooledObject = item;
                break;
            }
        }

        if (!pooled)
        {
            pool.Add(Instantiate(pool[pool.Count - 1]));
            GameObject item = pool[pool.Count - 1];
            item.name = tag + " " + pool.Count;
            item.transform.SetPositionAndRotation(coordinates, item.transform.rotation);
            item.transform.SetParent(GameObject.Find(tag).transform);
            item.SetActive(true);
            return item;
        }

        return pooledObject;
    }
}
