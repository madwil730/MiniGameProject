using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : GameChater
{

	public override void Special(Action action = null)
	{
		if(!OnSpeical)
		{

			action.Invoke();
			OnSpeical = true;
		}
	}


}
