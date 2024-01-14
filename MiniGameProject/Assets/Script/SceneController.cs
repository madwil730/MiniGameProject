using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
	[SerializeField]
	private GameObject[] obstacles;
	[SerializeField]
	private GameObject[] ItemList;
	[SerializeField]
	private GameObject DeathUI;
	[SerializeField]
	private GameObject PauseUI;
	[SerializeField]
	private GameObject BlockImage;
	[SerializeField]
	private Button specialButton;

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
	private GameObject character;
	public static bool PlayerDeath;
	private IEnumerator obstacleCoroutine;

	public TextMeshProUGUI Score;
	[HideInInspector]
	public int ScoreIndex = 0;

	private void OnDestroy()
	{
		addressObject[addressIndex].ReleaseAsset();
	}

	public void Initialization(int num)
	{
		specialButton.interactable = true;
		obstacleIndex = 0;
		addressIndex = num;

		StartCoroutine(CoCharaterInit());
	}

	IEnumerator CoCharaterInit()
	{
		yield return addressObject[addressIndex].LoadAssetAsync(); 

		character = Instantiate(addressObject[addressIndex].Asset) as GameObject;
		character.transform.localPosition = new Vector3(-1, 0, 0);
		character.GetComponent<GameChater>().OnDeathUIAction = OnDeathUI;
		characterTouchEvent.Initialization(character);
		obstacleCoroutine = CoOnObstacle();
		StartCoroutine(obstacleCoroutine);
	}



	IEnumerator CoOnObstacle()
	{

		while (true)
		{
			if (ScoreIndex > 10)
				obstacleTime = 2;

			if (ScoreIndex > 25)
				obstacleTime = Random.Range(1.0f,2.0f);

			yield return new WaitForSeconds(obstacleTime);

			if (obstacleIndex == obstacles.Length)
				obstacleIndex = 0;

			var randomItem = Random.Range(0, 7);
			randomItem = 1;

			obstacles[obstacleIndex].GetComponentInChildren<Obstacle>().Move();


			if (randomItem == 1)
			{
				ItemList[0].GetComponent<ItemController>().ItemAction = () => IncreaseScore(2);
				ItemList[0].GetComponent<ItemController>().Move(new Vector3(3.2f, UnityEngine.Random.Range(-4.7f, 1.3f), 0));
			}
			else if (randomItem == 2)
			{
				ItemList[1].GetComponent<ItemController>().ItemAction = () => character.GetComponent<GameChater>().SuperArmor();
				ItemList[1].GetComponent<ItemController>().Move(new Vector3(3.2f, UnityEngine.Random.Range(-4.7f, 1.3f), 0));
			}

			obstacleIndex++;

		}
	}

	public void IncreaseScore(int num)
	{
		ScoreIndex += num;
		Score.text = $"Score  : {ScoreIndex} ";
	}


	public void Pause()
	{
		if (!BlockImage.activeSelf)
		{
			BlockImage.SetActive(true);
			PauseUI.SetActive(true);
			Time.timeScale = 0;
		}
		else
		{
			BlockImage.SetActive(false);
			PauseUI.SetActive(false);
			Time.timeScale = 1;
		}
	}

	public void OnDeathUI()
	{
		DeathUI.SetActive(true);
		BlockImage.SetActive(true);
		specialButton.interactable = true;
	}

	public void ReStart()
	{
		Clear();
		DeathUI.SetActive(false);
		StartCoroutine(CoCharaterInit());
	}

	public void Clear()
	{
		StopCoroutine(obstacleCoroutine);
		obstacleCoroutine = null;
		ScoreIndex = 0;
		Score.text = $"Score  :  0 ";
		addressObject[addressIndex].ReleaseAsset();
		Destroy(character);
		Pause();

		foreach (var obstacle in obstacles)
		{
			obstacle.GetComponent<Obstacle>().OnStartPosition();
		}

		foreach (var item in ItemList)
		{
			item.GetComponent<ItemController>().OnStartPosition();
		}
	}

	private void Update()
	{


		if (backGround_1.transform.localPosition.x > -5.6f && !backGroundChange)
		{

			backGround_1.transform.Translate(Vector3.left * Time.deltaTime);
			backGround_2.transform.localPosition = new Vector3(backGround_1.transform.localPosition.x + 5.85f, -2, 0);
		}
		else if (backGround_1.transform.localPosition.x <= -5.6f)
			backGroundChange = true;

		if (backGround_2.transform.localPosition.x > -5.6f && backGroundChange)
		{
			backGround_2.transform.Translate(Vector3.left * Time.deltaTime);
			backGround_1.transform.localPosition = new Vector3(backGround_2.transform.localPosition.x + 5.85f, -2, 0);
		}
		else if (backGround_2.transform.localPosition.x <= -5.6f)
			backGroundChange = false;
	}


	public void Speical()
	{
		var speical = character.GetComponent<GameChater>();

		if (speical is BlueBird)
			speical.Special();
		else if (speical is RedBird)
		{
			speical.Special(() =>
			{
				foreach (var obstacle in obstacles)
				{
					obstacle.GetComponent<Obstacle>().OnStartPosition();
				}
			});
		}

		specialButton.interactable = false;

	}


}





