using UnityEngine;
using System.Collections;

public class BlueBall : MonoBehaviour {

	public Vector3 startVelocity;
	public Vector3 slowdown;
	[HideInInspector]
	public Vector3 direction;
	private Vector3 velocity;
	private Rigidbody2D _rigidbody;
	private float timeAlive;

	// Use this for initialization
	void Start () {
		velocity = startVelocity;
		timeAlive = 0f;
		_rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		_rigidbody.velocity = velocity * direction.x;
		velocity = velocity - slowdown * Time.deltaTime;
		timeAlive += Time.deltaTime;
		if(timeAlive > 1.5f)
			Destroy(this.gameObject);
	}
	
	public void OnCollisionEnter2D(Collision2D col)
	{
		Destroy(this.gameObject);
	}
}