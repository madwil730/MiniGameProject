using DG.Tweening;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class GameChater : MonoBehaviour, ChaterBase
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
		throw new System.NotImplementedException();
	}
}
