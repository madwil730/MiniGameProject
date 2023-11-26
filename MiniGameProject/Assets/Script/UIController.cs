using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject mainUI;
	[SerializeField]
	private GameObject selectCharacterUI;
	[SerializeField]
	private GameObject stageUI;

	[SerializeField]
	private SceneController sceneController;

	public void SelectCharacterOn()
	{
		selectCharacterUI.SetActive(true);	
		mainUI.SetActive(false);
	}

	public void StageOn()
	{
		selectCharacterUI.SetActive(false);
		stageUI.SetActive(true);
		sceneController.Initialization(0);
	}
}
