using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour  // 나중에 rect transform 으로 시간되면 바꾸기 
{

	[SerializeField]
	private float endPoint;
	[SerializeField]
	private float duration;
	[SerializeField]
	private Transform obstacleUpDirection;
	[SerializeField]
	private Transform obstacleDownDirection;
	[SerializeField]
	private Vector3 spawnPosition;
	

	private Sequence tweenSequence;

	public void Move()
	{
		var num = Random.Range(1, 4);

		if(num == 1) // down
		{
			obstacleUpDirection.gameObject.SetActive(false);
			obstacleDownDirection.gameObject.SetActive(true);
			obstacleDownDirection.localScale = new Vector3(1, UnityEngine.Random.Range(1.0f, 2.0f), 1);

			tweenSequence = DOTween.Sequence();
			tweenSequence.Append(transform.DOMoveX(endPoint, duration).OnComplete(() =>
			{
				transform.localPosition = spawnPosition;

			}));
		}

		else if (num == 2) // up
		{
			obstacleUpDirection.gameObject.SetActive(true);
			obstacleDownDirection.gameObject.SetActive(false);
			obstacleUpDirection.localScale = new Vector3(1, UnityEngine.Random.Range(1.0f, 2.0f), 1);

			tweenSequence = DOTween.Sequence();
			tweenSequence.Append(transform.DOMoveX(endPoint, duration).OnComplete(() =>
			{
				transform.localPosition = spawnPosition;

			}));
		}
		if (num == 3)
		{
			var random = Random.Range(1, 3);
			obstacleUpDirection.gameObject.SetActive(true);
			obstacleDownDirection.gameObject.SetActive(true);

			if (random == 1)
			{
				obstacleUpDirection.localScale = new Vector3(1, UnityEngine.Random.Range(1.0f, 2.0f), 1);
			}
			else if (random == 2)
			{
				obstacleDownDirection.localScale = new Vector3(1, UnityEngine.Random.Range(1.0f, 2.0f), 1);
			}


			tweenSequence = DOTween.Sequence();
			tweenSequence.Append(transform.DOMoveX(endPoint, duration).OnComplete(() =>
			{
				transform.localPosition = spawnPosition;

			}));
		}




	}

	public void OnStartPosition()
	{
		tweenSequence.Kill();	
		transform.localPosition = spawnPosition;	
	}
}
