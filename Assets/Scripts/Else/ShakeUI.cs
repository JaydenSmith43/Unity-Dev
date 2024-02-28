using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeUI : MonoBehaviour
{
	[SerializeField] public GameObject timeTxt;
	float speed = 100.0f;
	float amount = 2.0f;



	void FixedUpdate()
	{
		var sayDialog = timeTxt.transform.GetComponent<RectTransform>();
		var pos = sayDialog.anchoredPosition;
		sayDialog.anchoredPosition = new Vector3(pos.x += Mathf.Sin(Time.time * speed) * amount, pos.y += Mathf.Sin(Time.time * speed) * amount, 0);
	}
}
