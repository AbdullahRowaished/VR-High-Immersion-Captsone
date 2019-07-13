using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {
    public GamePools gp;

	private void Start () {
        gp.PoolObject(new Vector3(1, 0, 1), "Dirt");
        gp.PoolObject(new Vector3(1, 0, 1), "Corn");
        gp.PoolObject(new Vector3(6, 0, 5), "Dirt");
        gp.PoolObject(new Vector3(6, 0, 5), "Tomato");
        gp.PoolObject(new Vector3(-8, 0, 1), "Dirt");
        gp.PoolObject(new Vector3(-8, 0, 1), "Pumpkin");
        gp.PoolObject(new Vector3(-6, 0, 5), "Dirt");
        gp.PoolObject(new Vector3(-6, 0, 5), "Eggplant");

        gp.PoolObject(new Vector3(-6, 0, 5), "Dirt");
        gp.PoolObject(new Vector3(-6, 0, 5), "Dirt");
        gp.PoolObject(new Vector3(-6, 0, 5), "Dirt");
        gp.PoolObject(new Vector3(-6, 0, 5), "Dirt");

        gp.PoolObject(new Vector3(-6, 0, 5), "Dirt");
        gp.PoolObject(new Vector3(-6, 0, 5), "Dirt");
        gp.PoolObject(new Vector3(-6, 0, 5), "Dirt");
        gp.PoolObject(new Vector3(-6, 0, 5), "Dirt");

        gp.PoolObject(new Vector3(-6, 0, 5), "Dirt");
        gp.PoolObject(new Vector3(-6, 0, 5), "Dirt");
        gp.PoolObject(new Vector3(-6, 0, 5), "Dirt");
        gp.PoolObject(new Vector3(-6, 0, 5), "Dirt");

        gp.PoolObject(new Vector3(-6, 0, 5), "Dirt");
        gp.PoolObject(new Vector3(-6, 0, 5), "Dirt");
        gp.PoolObject(new Vector3(-6, 0, 5), "Dirt");
        gp.PoolObject(new Vector3(-6, 0, 5), "Dirt");
        gp.PoolObject(new Vector3(-6, 0, 5), "Dirt");
        gp.PoolObject(new Vector3(-6, 0, 5), "Dirt");
    }
}
