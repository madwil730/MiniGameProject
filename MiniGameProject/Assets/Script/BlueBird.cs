using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBird : GameChater
{
	public override void Special(Action action = null)
	{
		if (!OnSpeical)
			StartCoroutine(CoSpeical());
	}

	IEnumerator CoSpeical()
	{
		OnSpeical = true;
		transform.localScale = Vector3.one;
		yield return new WaitForSeconds(5);
		transform.localScale = new Vector3(1.5f, 1.5f, 1);
	}
}
