using UnityEngine;
using System.Collections;

public class SequenceAction : Action {

	public Action[] actionList;
	private int currentI;

	public override void Activate()
	{
		actionList[currentI++].Activate();
		if(currentI >= actionList.Length)
			currentI = 0;
	}
}
