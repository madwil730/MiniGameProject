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

	public void StageOn(int index)
	{
		selectCharacterUI.SetActive(false);
		stageUI.SetActive(true);
		sceneController.Initialization(index);
	}

	public void MainOn()
	{
		selectCharacterUI.SetActive(false);
		stageUI.SetActive(false);
		mainUI.SetActive(true);
		sceneController.Clear();
	}
}
