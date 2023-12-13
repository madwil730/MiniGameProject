using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterTouchEvent : MonoBehaviour, IPointerDownHandler
{
	private GameObject character;
	public bool Death;
	public void Initialization(GameObject ob)
	{
		character = ob;	

	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if(Death)
		{
			character.transform.DOMoveY(character.transform.position.y + 3, 1);
			character.GetComponent<Rigidbody2D>().gravityScale = 0;
		}
	}

	
}