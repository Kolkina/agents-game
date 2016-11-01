using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

	private float velocity = 4f;
	
	public void SetDirection(Vector3 newDir)
	{
		if (newDir == Vector3.right) transform.eulerAngles = new Vector3(0,0,270);
		if (newDir == -Vector3.right) transform.eulerAngles = new Vector3(0,0,90);
		if (newDir == -Vector3.up) transform.eulerAngles = new Vector3(0,0,180);
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.up * velocity * Time.deltaTime);
		if(transform.position.y > 10)
			Destroy(this);
	}
	
	public void OnCollisionEnter2D(Collision2D col)
	{
		Destroy(this.gameObject);
	}
}
