using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	private Transform going;
	public float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public GameObject[] characters;
    private GameCtrl gc;

    private void Start()
    {
        gc = GameObject.Find("GameCtrl").GetComponent<GameCtrl>();
        startTimeBtwSpawns = gc.timeBtwSpawn[gc.BotsLvl -1];
        timeBtwSpawns = startTimeBtwSpawns;
        
    }

    private void Update()
    {
        
        
        if (timeBtwSpawns <= 0)
        {
            float dif = Random.Range(0.0f, 1.1f);
            int rand = Random.Range(0, characters.Length);
            Instantiate(characters[rand], transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
            startTimeBtwSpawns = gc.timeBtwSpawn[gc.BotsLvl -1] + dif;
        }
        else {
            timeBtwSpawns -= Time.deltaTime;
        }
    }

}
