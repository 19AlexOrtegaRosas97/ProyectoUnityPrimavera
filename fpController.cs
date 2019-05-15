using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class fpController : MonoBehaviour
{
    public float speed = 5f;

    private Transform cam;
    private Rigidbody rb;
    private Vector3 velocity=Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float yMov = Input.GetAxisRaw("Vertical");
        float zMov = Input.GetAxisRaw("Jump");

        Vector3 movHor = transform.right * xMov;
        Vector3 movVer = transform.forward * yMov;
        Vector3 movJump = transform.up * zMov;
        velocity = (movHor + movVer + movJump).normalized * speed;
    }

    private void FixedUpdate()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }
}
