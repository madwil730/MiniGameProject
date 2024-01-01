using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour  // ���߿� rect transform ���� �ð��Ǹ� �ٲٱ� 
{

	[SerializeField]
	private float endPoint;
	[SerializeField]
	private float duration;
	[SerializeField]
	private Vector3 spawnPosition;
	

	private Sequence tweenSequence;

	public void Move()
	{
		transform.localScale = new Vector3(0.8f, UnityEngine.Random.Range(1.0f,2.0f), 1);

		tweenSequence = DOTween.Sequence();
		tweenSequence.Append(transform.DOMoveX(endPoint, duration).OnComplete(() =>
		{
			transform.localPosition = spawnPosition;

		}));


	}

	public void OnStartPosition()
	{
		tweenSequence.Kill();	
		transform.localPosition = spawnPosition;	
	}
}
