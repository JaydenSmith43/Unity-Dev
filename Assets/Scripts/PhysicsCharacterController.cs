using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] //will create component with default values if nonexistent
public class PhysicsCharacterController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField][Range(1,10)] float maxForce = 5;
    [SerializeField][Range(1,10)] float jumpForce = 5;
    [SerializeField] Transform view;
    [Header("Collision")]
    Rigidbody rb;
    [SerializeField][Range(0,5)] float rayLength = 1;
    [SerializeField] LayerMask groundLayerMask;
    Vector3 force = Vector3.zero;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero; // aka (0,0,0)

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        Quaternion yrotation = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up);
        force = yrotation * direction * maxForce * 2.0f;

        Debug.DrawRay(transform.position, Vector3.down * rayLength, Color.red);
        if (Input.GetButtonDown("Jump") && CheckGround())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

	private void FixedUpdate()
	{
		rb.AddForce(force, ForceMode.Force); //understand forcemode values
	}

    private bool CheckGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, rayLength, groundLayerMask);
    }

	public void Reset()
	{
        if(rb)
        {
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}
        else
        {
            print("nuh uh");
        }
	    
	}
}
