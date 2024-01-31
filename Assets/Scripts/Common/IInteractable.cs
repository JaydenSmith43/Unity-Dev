using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
	void OnEnter(); //defaults to public
	void OnExit();
}
