using UnityEngine;
using System.Collections;

public class ProjectileSpawner : MonoBehaviour {

	public GameObject projectile;
	public Direction dir;
	public enum Direction {Left,Right,Up,Down};

	private float timeSinceFire = 0f;
	[Range(0.1f,10.0f)]
	public float frequency = 0.5f;
	private Vector3 fireballDir = Vector3.up;
	
	void Start () {
		switch (dir)
		{
			case Direction.Left:
				fireballDir = -Vector3.right;
				break;
			case Direction.Right:
				fireballDir = Vector3.right;
				break;
			case Direction.Up:
				fireballDir = Vector3.up;
				break;
			case Direction.Down:
				fireballDir = -Vector3.up;
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		if(timeSinceFire > frequency)
		{
			Vector3 spawnPos = new Vector3(transform.position.x + fireballDir.x,transform.position.y + fireballDir.y,transform.position.z);
			GameObject fb = Instantiate (projectile, spawnPos, Quaternion.identity) as GameObject;
			fb.GetComponent<Fireball>().SetDirection(fireballDir);
			timeSinceFire = 0;
		}
		else
			timeSinceFire += Time.deltaTime;
	
	}
}
