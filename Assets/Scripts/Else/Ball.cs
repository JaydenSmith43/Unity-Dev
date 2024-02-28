using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour //anything that will be attached to a game object will need monobehaviour
{
    [Header("Movement")]
    [SerializeField][Range(1, 20)][Tooltip("Force to move object")] float force;

    public Rigidbody rb;
    
    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            rb.AddForce(transform.up * force, ForceMode.VelocityChange);
        }
    }
}
