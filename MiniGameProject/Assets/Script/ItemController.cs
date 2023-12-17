using System;
using UnityEngine;

public class ItemController : MonoBehaviour
{
	public enum ItemEnum
	{
		PlusScore,
		NoDamage
	}

	public ItemEnum ItemPower;
	private GameObject item;

	public Action ItemAction;




	private void OnTriggerEnter2D(Collider2D collision)
	{
		ItemAction.Invoke();
		this.transform.localPosition = new Vector3(100, 100, 0);
		//Destroy(this);
		//switch (ItemPower)
		//{
		//	case ItemEnum.PlusScore:
		//	{
		//		PlusScore();
		//	}
		//	break;

		//	case ItemEnum.NoDamage:
		//	{
		//		Debug.Log("Entered fight state");
		//	}
		//		break;
		//}
	}

	public void PlusScore()
	{
		Debug.Log("NoDamage");
	}

	public void NoDamage()
	{
		Debug.Log("NoDamage");
	}
}
