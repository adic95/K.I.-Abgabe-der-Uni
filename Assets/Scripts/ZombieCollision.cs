using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieCollision : MonoBehaviour
{
    private ZombieAI ZombieController;

    void Start()
    {
        ZombieController = GetComponent<ZombieAI>();
    }

    void OnTriggerEnter(Collider _col)
    {
        if(_col.tag == "Player")
        {

            ZombieController.Zombiestate = ZombieAI.EZombieState.COLLIDE;
            SceneManager.LoadScene(1);
        }
        
    }
    
}