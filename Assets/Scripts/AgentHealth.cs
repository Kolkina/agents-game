using UnityEngine;
using System.Collections;

public class AgentHealth : MonoBehaviour {

	private Vector2 spawn;

	// Use this for initialization
	void Start () {
		spawn = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.name == "Water")
			transform.position = spawn;
	}
}
