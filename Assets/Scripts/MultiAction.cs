using UnityEngine;
using System.Collections;

public class MultiAction : Action {

	public Action[] actionList;

	public override void Activate()
	{
		for(int i = 0; i < actionList.Length; i++)
		{
			actionList[i].Activate();
		}
	}

}
