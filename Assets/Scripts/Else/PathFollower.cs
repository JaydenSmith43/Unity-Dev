using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;

public class PathFollower : MonoBehaviour
{
    [SerializeField] SplineContainer splineContainer;
    [Range(0, 20)] public float speed = 1;
	[Range(0, 1)] public float tdistance = 0; // distance along spline (0-1)
    public bool start = false;

    public VoidEvent playerWin;

    public float length { get { return splineContainer.CalculateLength(); } } // length in world coordinates
    public float distance { // sdistance in world coordinates
        get { return tdistance * length; }
        set { tdistance = value / length; }
    }

	void Update()
    {
        if (start == true)
        {
			if (speed > 10)
			{
				speed -= 0.01f;
				speed = Mathf.Min(speed, 50);
			}

			distance += speed * Time.deltaTime;
			UpdateTransform(math.frac(tdistance));
		}

        if (tdistance >= .9f && tag == "Playerer")
        {
            playerWin.RaiseEvent();
        }
    }

    public void onStartGame()
    {
        start = true;
		tdistance = 0;
	}

	public void onGameOver()
	{
		start = false;
	}

	void UpdateTransform(float t)
    {
        Vector3 position =  splineContainer.EvaluatePosition(t);
        Vector3 up = splineContainer.EvaluateUpVector(t);
        Vector3 forward = Vector3.Normalize(splineContainer.EvaluateTangent(t)); //tan is perpendiclar to point
        Vector3 right = Vector3.Cross(up, forward);

        transform.position = position;
        transform.rotation = Quaternion.LookRotation(forward, up);

        transform.position = position;
    }
}