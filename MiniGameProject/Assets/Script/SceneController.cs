using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class SceneController : MonoBehaviour
{
	[SerializeField]
	private GameObject[] obstacle;
	[SerializeField]
	private GameObject[] ItemList;
	[SerializeField]
	private GameObject DeathUI;
	[SerializeField]
	private Transform Land;

	[SerializeField]
	private AssetReferenceGameObject[] addressObject;
	[SerializeField]
	private CharacterTouchEvent characterTouchEvent;
	[SerializeField]
	private GameObject backGround_1;
	[SerializeField]
	private GameObject backGround_2;
	[SerializeField]
	private float obstacleTime = 3;

	private int addressIndex;
	private int obstacleIndex = 0;
	private bool backGroundChange;
	public static bool PlayerDeath;
	bool GameStart;

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
		GameStart = true;
		StartCoroutine(CoCharaterInit());

	}

	IEnumerator CoCharaterInit()
	{
		yield return new WaitForSeconds(0.2f);  // 수정 나중에  until 같은 코드로 고치기

		var character = Instantiate(addressObject[addressIndex].Asset) as GameObject;
		character.GetComponent<GameChater>().OnDeathUIAction = OnDeathUI;
		characterTouchEvent.Initialization(character);
		StartCoroutine(CoOnObstacle());
	}

	IEnumerator CoOnObstacle()
	{
		while (true)
		{
			yield return new WaitForSeconds(obstacleTime);


			if (obstacleIndex == obstacle.Length)
				obstacleIndex = 0;

			var randomItem = Random.Range(0, 3);
			//var randomItem = 1;

			if (randomItem == 1)
			{
				ItemList[0].transform.parent = obstacle[obstacleIndex].transform;
				ItemList[0].transform.localPosition = new Vector3(-1.8f, 0.8f, 0);
				ItemList[0].GetComponent<ItemController>().ItemAction = () => IncreaseScore(5);
			}

			obstacle[obstacleIndex].GetComponent<Obstacle>().Move(ItemList[0]);
			obstacleIndex++;
		}
	}

	public void IncreaseScore( int num)
	{
		ScoreIndex += num;
		Score.text = $"Score  : {ScoreIndex} ";
	}

	public void OnDeathUI()
	{
		DeathUI.SetActive(true);
	}

	private void Update()
	{

		if (GameStart)
		{
			if (backGround_1.transform.localPosition.x > -7 && !backGroundChange)
			{

				backGround_1.transform.Translate(Vector3.left * Time.deltaTime);
				backGround_2.transform.localPosition = new Vector3(backGround_1.transform.localPosition.x + 7.67f, -2, 0);
			}
			else if (backGround_1.transform.localPosition.x <= -7)
				backGroundChange = true;

			if (backGround_2.transform.localPosition.x > -7 && backGroundChange)
			{
				backGround_2.transform.Translate(Vector3.left * Time.deltaTime);
				backGround_1.transform.localPosition = new Vector3(backGround_2.transform.localPosition.x + 7.67f, -2, 0);
			}
			else if (backGround_2.transform.localPosition.x <= -7)
				backGroundChange = false;
		}
	}


}





