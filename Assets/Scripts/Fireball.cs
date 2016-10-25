using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.up * 4 * Time.deltaTime);
		if(transform.position.y > 10)
			Destroy(this);
	}
}
