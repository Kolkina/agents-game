using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour {

	public Action triggerEffect;
	public KeyCode triggerAgent = KeyCode.Alpha0;
	public bool hold = false;
	
	private int onButton = 0;
	private float displace = 0f;
	private BoxCollider2D _collider;

	// Use this for initialization
	void Start () {
		_collider = GetComponent<BoxCollider2D>();
		displace = _collider.bounds.size.y * 0.75f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(onButton > 0) return;
		
		KeyCode num = col.gameObject.GetComponent<AgentMovement>().agentNumber;
		if(triggerAgent == KeyCode.Alpha0 || num == triggerAgent)
		{
			triggerEffect.Activate();
			
			transform.Translate(-Vector3.up * displace);
			_collider.offset = Vector3.up * displace;
			onButton++;	
		}
	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		if(hold) {
			onButton--;
			if(onButton == 0)
			{
				triggerEffect.Deactivate();
				transform.Translate(Vector3.up * displace);
				_collider.offset = Vector2.zero;
			}
		}
	}
	
}
