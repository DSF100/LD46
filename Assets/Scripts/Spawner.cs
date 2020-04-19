using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Obstacles;
    public GameObject spawnVFX;

    float time;
    float timeBetweenSpawns;

    Camera myMainCamera;

    float angle;
    Vector3 pos;
    GameObject toBeSpawned;

    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        timeBetweenSpawns = Random.Range(1f, 5f);
        myMainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - time >= timeBetweenSpawns)
        {
            time = Time.time;
            timeBetweenSpawns = Random.Range(2f, 10f);

            angle = Random.Range(0f, 360f);
            toBeSpawned = Obstacles[Random.Range(0, Obstacles.Length - 1)];
            pos = new Vector3(Random.Range(-myMainCamera.orthographicSize * myMainCamera.aspect + .5f, myMainCamera.orthographicSize * myMainCamera.aspect - .5f), Random.Range(-myMainCamera.orthographicSize + .5f, myMainCamera.orthographicSize - .5f), 0);

            GameObject curr = Instantiate(spawnVFX, pos, Quaternion.identity);
            curr.GetComponent<SpawnVFX>().scaleSize = toBeSpawned.transform.localScale;
            Invoke("Spawn", 1);
        }
    }

    void Spawn()
    {
        Instantiate(toBeSpawned, pos, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }
}
