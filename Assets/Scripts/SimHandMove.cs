using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SimHandMove : MonoBehaviour
{
    public Transform location;
    public Vector3 position;
    public float moveSpeed;
    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // keep the mouse cursor in the confines of the screen for purposes of moving
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
        #region Rotation using Keyboard
        // turn left
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed, Space.World);
        }
        // turn right
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed, Space.World);
        }
        // looking up
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(Vector3.left * Time.deltaTime * turnSpeed, Space.Self);
        }
        // looking down
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.C))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed, Space.Self);
        }
        #endregion

        #region Rotation using Mouse
        // turn right using mouse
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * turnSpeed, Space.Self);
        #endregion

        // how to make the A problem go away?

        // sprint?

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DoSprint(2);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            DoSprint(0.5f);
        }
    }


    public void DoSprint(float sprintFactor)
    {
        moveSpeed = moveSpeed * sprintFactor;
        Debug.Log($"{transform.position}");
    }
}