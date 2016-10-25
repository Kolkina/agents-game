using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

	private float velocity = 4f;
	private Vector3 dir = Vector3.up;
	
	public void SetDirection(Vector3 newDir)
	{
		dir = newDir;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(dir * velocity * Time.deltaTime);
		if(transform.position.y > 10)
			Destroy(this);
	}
}
