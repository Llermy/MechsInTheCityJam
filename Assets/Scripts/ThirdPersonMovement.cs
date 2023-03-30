using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController cController;
    public Transform cam;

    [Header("Movement")]
    public float speed = 1.0f;
    public float rotateSmoothTime = 0.1f;
    private float rotateSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        if(cController == null)
        {
            cController = GetComponent<CharacterController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            // Character rotatio
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotateSmoothVelocity, rotateSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Plane movement
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; 
            cController.Move(moveDir.normalized * Time.deltaTime * speed);
        }
        
    }
}
