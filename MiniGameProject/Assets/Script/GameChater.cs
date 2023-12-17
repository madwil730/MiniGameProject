using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;

public class GameChater : MonoBehaviour, ChaterBase
{

	public Action OnDeathUIAction;

	public void Special()
	{
		Debug.Log("this is Special");
	}



	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.gameObject.tag == "Obstacle")
		{
			OnDeathUIAction.Invoke();
			GetComponent<Rigidbody2D>().gravityScale = 100;
		}
	}

	public void Jump()
	{
		throw new System.NotImplementedException();
	}
}
