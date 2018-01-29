using UnityEngine;
using System.Collections;

public class DoorAction : Action {

	public bool inverted = false;

	public override void Activate()
	{
		gameObject.SetActive(inverted);
		inverted = !inverted;
	}
	
}
