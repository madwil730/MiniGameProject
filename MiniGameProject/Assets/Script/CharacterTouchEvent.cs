using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterTouchEvent : MonoBehaviour, IPointerDownHandler
{
	private GameObject character;
	public void Initialization(GameObject ob)
	{
		character = ob;	

	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (!SceneController.PlayerDeath)
		{
			character.transform.DOMoveY(character.transform.position.y + 3, 1);
			character.GetComponent<Rigidbody2D>().gravityScale = 0;
			//character.GetComponent<Rigidbody2D>().AddForce(transform.up * 5,ForceMode2D.Impulse);
		}
	}

	
}
