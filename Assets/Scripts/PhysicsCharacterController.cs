using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] //will create component with default values if nonexistent
public class PhysicsCharacterController : MonoBehaviour
{
    [SerializeField][Range(1,10)] float maxForce;
    [SerializeField][Range(1,10)] float jumpForce;
    [SerializeField] Transform view;

    Rigidbody rb;
    Vector3 force = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero; // aka (0,0,0)

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        force = view.rotation * direction * maxForce;

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

	private void FixedUpdate()
	{
		rb.AddForce(force, ForceMode.Force); //understand forcemode values
	}
}
