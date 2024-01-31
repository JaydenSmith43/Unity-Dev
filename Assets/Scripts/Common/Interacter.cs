using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacter : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable))
		{
			interactable.OnEnter(); //sd
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable))
		{
			interactable.OnExit();
		}
	}
}
