using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Obstacle : MonoBehaviour  // ���߿� rect transform ���� �ð��Ǹ� �ٲٱ� 
{

	[SerializeField]
	private float endPoint;
	[SerializeField]
	private float duration;
	[SerializeField]
	private Vector3 spawnPosition;
	[SerializeField]
	private GameObject scoreBox;


	public void Move(GameObject item)
	{
		transform.localScale = new Vector3(1, UnityEngine.Random.Range(4,7), 1);
	
		transform.DOMoveX(endPoint, duration).OnComplete(() =>
		{
			transform.localPosition = spawnPosition;

			if (item != null)
				item.transform.localPosition = new Vector3(100, 100, 0);
		});
	}
}
