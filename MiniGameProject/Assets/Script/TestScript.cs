using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
	private Rigidbody rigid;

	public int jumpPower;
	public float MoveSpeed;

	private void Start()
	{
		
		rigid = GetComponent<Rigidbody>();
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
			rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);
		}
	}

		
}
