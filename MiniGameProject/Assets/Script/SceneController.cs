using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.TextCore.Text;
using Unity.VisualScripting.Dependencies.NCalc;

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
	private IEnumerator coroutine;

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


	public void Speical()
	{
		var speical = character.GetComponent<GameChater>();

		if(speical is Duck)
			speical.Special();
		else if (speical is Eagle)
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


	IEnumerator CoCharaterInit()
	{
		yield return addressObject[addressIndex].LoadAssetAsync(); // 수정 나중에  until 같은 코드로 고치기

		character = Instantiate(addressObject[addressIndex].Asset) as GameObject;
		character.GetComponent<GameChater>().OnDeathUIAction = OnDeathUI;
		characterTouchEvent.Initialization(character);
		coroutine = CoOnObstacle();
		StartCoroutine(coroutine);
	}



	IEnumerator CoOnObstacle()
	{

		while (true)
		{
			yield return new WaitForSeconds(obstacleTime);

			if (obstacleIndex == obstacles.Length)
				obstacleIndex = 0;

			var randomItem = Random.Range(0, 9);


			obstacles[obstacleIndex].GetComponent<Obstacle>().Move();


			if (randomItem == 1)
			{
				ItemList[0].GetComponent<ItemController>().ItemAction = () => IncreaseScore(5);
				ItemList[0].GetComponent<ItemController>().Move(new Vector3(3.2f, UnityEngine.Random.Range(-1.0f, 1.0f), 0));
			}
			else if (randomItem == 2)
			{
				ItemList[1].GetComponent<ItemController>().ItemAction = () => character.GetComponent<GameChater>().SuperArmor();
				ItemList[1].GetComponent<ItemController>().Move(new Vector3(3.2f, UnityEngine.Random.Range(-1.0f, 1.0f), 0));
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
	}

	public void ReStart()
	{
		Clear();
		DeathUI.SetActive(false);
		StartCoroutine(CoCharaterInit());
	}

	public void Clear()
	{
		StopCoroutine(coroutine);
		coroutine = null;
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
		//if(Input.GetKeyDown(KeyCode.A))
		//{
		//	Debug.Log(corutine == null);
		//	StopCoroutine(corutine);
		//	Debug.Log(corutine == null);
		//	corutine = null;
		//	Debug.Log(corutine == null);
		//}

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





