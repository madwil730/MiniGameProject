using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{

	[SerializeField]
	private float endPoint;
	[SerializeField]
	private float duration;

	private void OnEnable()
	{
		Move();
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("Player Death!");
	}

	public void Move()
	{
		this.transform.DOMoveX(endPoint, duration);
	}
}
