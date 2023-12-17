using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBox : MonoBehaviour
{
	[SerializeField]
	private SceneController sceneController;
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!SceneController.PlayerDeath)
		sceneController.IncreaseScore(1);
	}

}
