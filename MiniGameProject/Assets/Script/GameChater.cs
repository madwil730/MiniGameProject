using DG.Tweening;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;

public class GameChater : MonoBehaviour, ChaterBase,IPointerDownHandler
{

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}
	}

	public void Jump()
	{
		this.transform.DOMoveY(this.transform.position.y + 3, 1);
		this.GetComponent<Rigidbody2D>().gravityScale = 0;
	}


	public void Special()
	{
		Debug.Log("this is Special");
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		this.transform.DOMoveY(this.transform.position.y + 3, 1);
		this.GetComponent<Rigidbody2D>().gravityScale = 0;
	}
}
