using UnityEngine;
using System.Collections;

public class Agent2Power : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<AgentMovement>().facing = -Vector3.right;
	}
	
	public GameObject projectile;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(GetComponent<AgentMovement>().active == true)
			{
				GameObject ball = Instantiate(projectile,transform.position + GetComponent<AgentMovement>().facing * 1.5f,Quaternion.identity) as GameObject;
				ball.transform.SetParent(transform);
				ball.GetComponent<BlueBall>().direction = GetComponent<AgentMovement>().facing;
			}
		}
	}
}
