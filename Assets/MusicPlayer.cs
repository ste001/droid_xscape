using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("loadFirstScene", 2f);
	}
	
	void loadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
