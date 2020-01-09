using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour {

	// Use this for initialization
	public void LoadScene(int _index)
    {
        SceneManager.LoadScene(0);
    }
}
