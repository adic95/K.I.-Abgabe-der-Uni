using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winzone : MonoBehaviour
{
    public AudioClip clip;

    // Use this for initialization
    void OnTriggerEnter(Collider _col)
    {

        if(_col.gameObject.tag =="Player")
        {
            GetComponent<AudioSource>().Play();
            SceneManager.LoadScene(2);
        }
    }
}
