using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;

public class GameChater : MonoBehaviour
{

	public Action OnDeathUIAction;
	public Action OnSpecialAction;
	private bool IsSuperArmor;
	protected bool OnSpeical;


	public virtual void Special(Action action = null)
	{
		Debug.Log("this is Special");
	}

	public void SuperArmor()
	{
		StartCoroutine(CoSuperArmor());
	}

	IEnumerator CoSuperArmor()
	{
		IsSuperArmor = true;
		GetComponent<SpriteRenderer>().color = Color.yellow;
		yield return new WaitForSeconds(5);

		IsSuperArmor = false;
		GetComponent<SpriteRenderer>().color = Color.white;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{

		if(!IsSuperArmor)
		{
			if (collision.gameObject.tag == "Obstacle")
			{
				OnDeathUIAction.Invoke();
				GetComponent<Rigidbody2D>().gravityScale = 100;

			}
		}
	
	}

	public void Jump()
	{
		throw new System.NotImplementedException();
	}
}
