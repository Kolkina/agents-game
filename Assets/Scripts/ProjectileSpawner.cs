using UnityEngine;
using System.Collections;

public class ProjectileSpawner : MonoBehaviour {

	public GameObject projectile;

	private float timeSinceFire = 0f;
	private float frequency = 0.5f;
	
	// Update is called once per frame
	void Update () {
	
		if(timeSinceFire > frequency)
		{
			Instantiate (projectile, transform.position, Quaternion.identity);
			timeSinceFire = 0;
		}
		else
			timeSinceFire += Time.deltaTime;
	
	}
}
