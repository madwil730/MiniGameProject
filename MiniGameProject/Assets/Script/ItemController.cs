using DG.Tweening;
using System;
using UnityEngine;

public class ItemController : MonoBehaviour
{
	public enum ItemEnum
	{
		PlusScore,
		NoDamage
	}

	private GameObject item;

	public Action ItemAction;
	[SerializeField]
	private float endPoint;
	[SerializeField]
	private float duration;

	private Sequence tweenSequence;
	private bool IsMove;


	private void OnTriggerEnter2D(Collider2D collision)
	{
		ItemAction.Invoke();
		this.transform.localPosition = new Vector3(100, 100, 0);

	}

	public void Move(Vector3 spawnPostion)
	{
		if(!IsMove)
		{

			this.transform.localPosition = spawnPostion;
			IsMove = true;

			tweenSequence = DOTween.Sequence();
			tweenSequence.Append(transform.DOMoveX(endPoint, duration).OnComplete(() =>
			{
				IsMove = false;
			}));


		}
	}


	public void OnStartPosition()
	{
		tweenSequence.Kill();
		transform.localPosition = new Vector3(100, 100, 0);
		IsMove = false;
	}


	public void PlusScore()
	{
		Debug.Log("NoDamage");
	}

	public void NoDamage()
	{
		Debug.Log("NoDamage");
	}
}
