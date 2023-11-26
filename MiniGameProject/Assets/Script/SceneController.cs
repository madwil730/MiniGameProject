using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.AddressableAssets;

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

	private int addressIndex;
	private int obstacleIndex = 0;

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
		yield return new WaitForSeconds(0.2f);	// 수정 나중에  until 같은 코드로 고치기

		Instantiate(addressObject[addressIndex].Asset);
	}


	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
			ObstacleMove();
		}
		
	}


	private void ObstacleMove()
	{
			if (obstacleIndex == obstacle.Length)
				obstacleIndex = 0;

			obstacle[obstacleIndex].SetActive(true);
			obstacleIndex++;
		}
	}


