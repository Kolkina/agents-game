using UnityEngine;
using System.Collections;

public class DoorAction : Action {

	private bool active = false;

	public override void Activate()
	{
		//active = !active;
		gameObject.SetActive(active);
	}
	
}
