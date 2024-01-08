using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : GameChater
{
	public override void Special(Action action = null)
	{
		if (!OnSpeical)
			StartCoroutine(CoSpeical());
	}

	IEnumerator CoSpeical()
	{
		OnSpeical = true;
		transform.localScale = new Vector3(0.1f,0.1f,1);
		yield return new WaitForSeconds(5);
		transform.localScale = new Vector3(0.3f, 0.3f, 1);
	}
}
