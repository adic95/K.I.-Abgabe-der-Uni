using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour {

    // Use this for initialization

    public AudioClip clip;


    void OnTriggerEnter(Collider _col)

    {
        if(_col.gameObject.tag =="Player")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
