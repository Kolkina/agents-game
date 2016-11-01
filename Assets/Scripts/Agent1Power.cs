using UnityEngine;
using System.Collections;

public class Agent1Power : MonoBehaviour {

	private bool disabled = false;
	private Vector3 vel = Vector3.zero;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			GetComponent<AgentMovement>().enabled = disabled;
			GetComponent<SpriteRenderer>().enabled = disabled;
			transform.GetChild(0).gameObject.SetActive(disabled);
			transform.GetChild(1).gameObject.SetActive(!disabled);
			if(!disabled)
			{
				Destroy(GetComponent<BoxCollider2D>());
				GetComponent<Rigidbody2D>().gravityScale = 0;
				vel = GetComponent<Rigidbody2D>().velocity;
				GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			}
			else {
				gameObject.AddComponent<BoxCollider2D>();
				GetComponent<Rigidbody2D>().gravityScale = 1;
				GetComponent<Rigidbody2D>().velocity = vel;
			}
			disabled = !disabled;
		}
	}
}
