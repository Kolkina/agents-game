using UnityEngine;
using System.Collections;

public class AgentHealth : MonoBehaviour {

	private Vector2 spawn;
	private bool dead = false;
	private KeyCode num;

	
	public void Respawn()
	{
		transform.position = spawn;
	}
	
	// Use this for initialization
	void Start () {
		spawn = transform.position;
		num = GetComponent<AgentMovement>().agentNumber;
	}
	
	public void Kill()
	{
		GetComponent<AgentMovement>().enabled = false;
		if(num == KeyCode.Alpha1) GetComponent<Agent1Power>().enabled = false;
		transform.GetChild(0).GetComponent<Animator>().SetBool("isDead",true);
		dead = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(num) && dead)
		{
			GetComponent<AgentMovement>().enabled = true;
			if(num == KeyCode.Alpha1) GetComponent<Agent1Power>().enabled = true;
			transform.GetChild(0).GetComponent<Animator>().SetBool("isDead",false);
			dead = false;
			Respawn();
		}	
	}
	
	public void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.name == "Water")
			transform.position = spawn;
		
		if(col.gameObject.tag == "Hazard") {
			Kill();
		}
	}
	
	public void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Hazard")
		{
			Kill();
		}
	}
}
