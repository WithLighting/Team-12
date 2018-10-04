using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public int c_speed;
    public Rigidbody c_basic;
    public bool stepingBack;
    public float backDistance;
    public float backSpeed;

    private void Awake()
    {
        c_basic = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update ()
    {
        LockCursor();
        if (!stepingBack)
        {
            Rotate();
            Move();
            StepBack();
        }
	}

    void StepBack()
    {
        if (!Input.GetButtonDown("Jump")) return;

        StartCoroutine(SteppingBack());
    }

    void LockCursor()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Cursor.visible)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    void Move()
    {
        float c_Vertical, c_Horizontal;

        c_Vertical = Input.GetAxis("Vertical"); 
        c_Horizontal = Input.GetAxis("Horizontal"); 
        Vector3 moveDir = new Vector3(c_Horizontal, 0, c_Vertical);
        moveDir = transform.rotation * moveDir;
        c_basic.MovePosition(transform.position + moveDir * c_speed * Time.deltaTime);
    }

    void Rotate()
    {
        var rotation = Input.GetAxis("Mouse X");

        transform.rotation *= Quaternion.Euler(0, rotation, 0);
    }

    IEnumerator SteppingBack()
    {
        stepingBack = true;
        Vector3 targetPoint = -transform.forward * backDistance + transform.position;
        while ((transform.position - targetPoint).sqrMagnitude > 0.1f)
        {
            c_basic.MovePosition(Vector3.Lerp(transform.position, targetPoint, Time.deltaTime * backSpeed));
            yield return null;
        }

        stepingBack = false;
    }
}
