using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour {

	public Action triggerEffect;
	public KeyCode triggerAgent = KeyCode.Alpha0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		KeyCode num = col.gameObject.GetComponent<AgentMovement>().agentNumber;
		if(triggerAgent == KeyCode.Alpha0 || num == triggerAgent)
		{
			triggerEffect.Activate();
		}
	}
	
}
