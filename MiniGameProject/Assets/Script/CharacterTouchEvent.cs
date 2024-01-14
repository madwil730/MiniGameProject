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
			if(character.transform.localPosition.y <3.7f)
			{
				character.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				character.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 4, ForceMode2D.Impulse);
			}
		}
	}
}
