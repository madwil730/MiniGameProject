using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
	private Rigidbody2D rigid;


	private void Start()
	{
		
		rigid = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		jump();
	}

	private void Move()
	{
		//float h = Input.GetAxis("Horizontal")
	}

	void jump()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			rigid.velocity = Vector2.zero;
			rigid.AddForce(Vector3.up * 5, ForceMode2D.Impulse);
		}
	}

		
}
