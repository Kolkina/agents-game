using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinFlag : MonoBehaviour {

	public string levelToLoad;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnTriggerEnter2D(Collider2D col)
	{
		SceneManager.LoadScene(levelToLoad);
	}
	
}
