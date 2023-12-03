using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class SceneController : MonoBehaviour
{
	[SerializeField]
	private GameObject[] obstacle;
	[SerializeField]
	private GameObject character;
	[SerializeField]
	private Transform Land;
	[SerializeField]
	private AssetReferenceGameObject[] addressObject;
	[SerializeField]
	private GameObject backGround_1;
	[SerializeField]
	private GameObject backGround_2;
	[SerializeField]
	private float obstacleTime = 3;
	private int addressIndex;
	private int obstacleIndex = 0;


	public TextMeshProUGUI Score;
	[HideInInspector]
	public  int ScoreIndex = 0;

	private void OnDestroy()
	{
		addressObject[addressIndex].ReleaseAsset();
	}

	public void Initialization(int num)
	{
		addressIndex = num;
		addressObject[addressIndex].LoadAssetAsync();
		StartCoroutine(CoCharaterInit());

	}

	IEnumerator CoCharaterInit()
	{
		yield return new WaitForSeconds(0.2f);  // 수정 나중에  until 같은 코드로 고치기

		Instantiate(addressObject[addressIndex].Asset);
		StartCoroutine(CoOnObstacle());
	}

	IEnumerator CoOnObstacle()
	{
		while (true)
		{
			yield return new WaitForSeconds(obstacleTime);
			if (obstacleIndex == obstacle.Length)
				obstacleIndex = 0;

			obstacle[obstacleIndex].GetComponent<Obstacle>().Move();
			obstacleIndex++;
		}
	}


	up

	public void IncreaseScore()
	{
		ScoreIndex++;
		Score.text = $"Score  : {ScoreIndex} ";
	}

	public void BacklGroundRotate()
	{
	}
}





