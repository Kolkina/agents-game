using UnityEngine;
using System.Collections;

public class ProjectileSpawner : MonoBehaviour {

	public GameObject projectile;
	public Direction dir;
	public enum Direction {Left,Right,Up,Down};

	private float timeSinceFire = 0f;
	private float frequency = 0.5f;
	private Vector3 fireballDir = Vector3.up;
	
	void Start () {
		switch (dir)
		{
			case Direction.Left:
				fireballDir = -Vector3.right;
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		if(timeSinceFire > frequency)
		{
			GameObject fb = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
			fb.GetComponent<Fireball>().SetDirection(fireballDir);
			timeSinceFire = 0;
		}
		else
			timeSinceFire += Time.deltaTime;
	
	}
}
