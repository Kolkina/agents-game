using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour {

	public Action triggerEffect;
	public KeyCode triggerAgent = KeyCode.Alpha0;
	public bool hold = false;
	public bool retrigger = false;
	public bool startOff = false;
	
	private int onButton = 0;
	private float displace = 0f;
	private BoxCollider2D _collider;
	private float timeSinceTrigger = 0f;

	// Use this for initialization
	void Start () {
		_collider = GetComponent<BoxCollider2D>();
		displace = _collider.bounds.size.y * 0.75f;
	}
	
	// Update is called once per frame
	void Update () {
		if(onButton > 0 && retrigger)
		{
			timeSinceTrigger += Time.deltaTime;
			if(timeSinceTrigger > 0.5f)
			{
				transform.Translate(Vector3.up * displace);
				_collider.offset = Vector2.zero;
				onButton = 0;
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(onButton > 0) return;
	
		if(triggerAgent == KeyCode.Alpha0 || (col.gameObject.GetComponent<AgentMovement>() != null && triggerAgent == col.gameObject.GetComponent<AgentMovement>().agentNumber))
		{
			if(retrigger && startOff) {
				startOff = false;
				triggerEffect.Activate();
			}
			else {
				startOff = true;
				triggerEffect.Activate();
			}
			
			transform.Translate(-Vector3.up * displace);
			_collider.offset = Vector3.up * displace;
			timeSinceTrigger = 0f;
			onButton++;	
		}
	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		if(hold && onButton > 0) {
			onButton--;
			if(onButton == 0)
			{
				triggerEffect.Activate();
				transform.Translate(Vector3.up * displace);
				_collider.offset = Vector2.zero;
			}
		}
	}
	
}
