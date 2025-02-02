using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject snow;
    public float spawnRate = 10;
    private float timer = 1;
    private static bool loadedPrefab = false;

    // Start is called before the first frame update
    void Start()
    {
        //if (!loadedPrefab)
        //{
        //    loadedPrefab = true;
        //    spawnSnow();
        //    return;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnSnow();
            timer = 0;
        }
    }

    void spawnSnow()
    {
        Instantiate(snow, new Vector3(0, -10, 110), transform.rotation);
    }
}
