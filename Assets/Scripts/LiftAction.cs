using UnityEngine;
using System.Collections;

public class LiftAction : Action {

	public float height;
	[Range(0.1f,10.0f)]
	public float velocity;
	private float startHeight;
	public bool activated = false;
	private bool goingAway;
	// Use this for initialization
	void Start () {
		startHeight = transform.position.y;
		goingAway = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(activated)
		{
			if(goingAway)
			{
				transform.position = transform.position + new Vector3(0,velocity*Time.deltaTime,0);
				if(transform.position.y - startHeight >= height)
					goingAway = false;
			}
			if(!goingAway)
			{
				transform.position = transform.position - new Vector3(0,velocity*Time.deltaTime,0);
				if(transform.position.y <= startHeight)
					goingAway = true;
			}
		}
	}
	
	override public void Activate()
	{
		activated = !activated;
	}
	

	
}
