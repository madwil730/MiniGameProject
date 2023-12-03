using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour  // 나중에 rect transform 으로 시간되면 바꾸기 
{

	[SerializeField]
	private float endPoint;
	[SerializeField]
	private float duration;
	[SerializeField]
	private Vector3 spawnPosition;
	[SerializeField]
	private GameObject scoreBox;


	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("Player Death!");
	}

	public void Move()
	{
		transform.localScale = new Vector3(1, Random.Range(4,7), 1);
	
		transform.DOMoveX(endPoint, duration).OnComplete(() =>
		{
			transform.localPosition = spawnPosition;
		});
	}
}
