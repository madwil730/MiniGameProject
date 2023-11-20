using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using DG.Tweening;
using UnityEngine.ResourceManagement.AsyncOperations;
using Unity.VisualScripting;

public class GameChater : MonoBehaviour
{
    [SerializeField]
    private AssetReferenceGameObject addressObject;
	[SerializeField]
	private GameObject ob;

	private void OnDestroy()
	{
		addressObject.ReleaseAsset();
	}

	private void Awake()
	{
		addressObject.LoadAssetAsync();
	}

	void Start()
    {

        //Instantiate(addressObject.Asset);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
			 Instantiate(addressObject.Asset);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log(222);
			ob.transform.DOMoveY(10, 3);
		}

	}
}
