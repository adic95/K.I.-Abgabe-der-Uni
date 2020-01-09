using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
	public GameObject[] zombies;
	public Vector3 zombiespawnpos;
	public int Spawnvalues = 4;

	// Use this for initialization
	void Start () 
	{
        for(int i = 0; i < Spawnvalues; i++)
        {

		    EnemySpawner ();
        }
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	void EnemySpawner()
	{
        zombiespawnpos.x = Random.Range(-10, 10);
        zombiespawnpos.z = Random.Range(-10, 10);

        Instantiate(zombies[Random.Range(0,zombies.Length -1)], zombiespawnpos, Quaternion.identity);
        
    }
}
