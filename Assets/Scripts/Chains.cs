using UnityEngine;
using System.Collections;

public class Chains : MonoBehaviour {

	public KeyCode agent = KeyCode.Alpha0;

	void OnTriggerEnter2D(Collider2D col)
	{
		AgentMovement colAgent = col.gameObject.GetComponent<AgentMovement>();
		if(colAgent == null) return;
		
		if(agent == KeyCode.Alpha0 || agent == colAgent.agentNumber)
			colAgent.SetClimbing(true);
	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		AgentMovement colAgent = col.gameObject.GetComponent<AgentMovement>();
		if(colAgent == null) return;
		
		if(colAgent.GetClimbing() && (agent == KeyCode.Alpha0 || agent == colAgent.agentNumber))
			colAgent.SetClimbing(false);
	}

}
