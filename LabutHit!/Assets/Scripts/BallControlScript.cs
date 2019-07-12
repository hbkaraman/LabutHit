﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControlScript : MonoBehaviour
{
    Rigidbody rb;
    MeshRenderer aimRenderer;
    public GameObject aimPlane;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        aimRenderer = aimPlane.GetComponent<MeshRenderer>();
    }

    RaycastHit hit;
    public LayerMask mask;

    private Vector3 force;
    private Vector3 touchPos;
    public GameObject touchIndicator;
    public float forceMultiplier = 5;

    private Vector3 originPos;

    private bool isMoving = false;
    void Update()
    {
        if (isMoving && rb.velocity.magnitude != 0)
        {
            isMoving = false;
            gameObject.transform.localEulerAngles = Vector3.zero;
        }
        if (!isMoving && rb.velocity.magnitude == 0)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out hit, 1000, mask);
                if (touch.phase == TouchPhase.Began)
                {
                    touchPos = hit.point;
                    touchIndicator.transform.position = hit.point;
                    aimRenderer.enabled = true;
                }
                Vector3 subtraction = hit.point - touchPos;
                float angle = Vector3.SignedAngle(subtraction, touchIndicator.transform.forward, Vector3.up);
                gameObject.transform.eulerAngles = new Vector3(0, 180 - angle, 0);

                float aimScale = Mathf.Clamp(subtraction.magnitude, 2.5f, 7.5f);
                force = aimScale * gameObject.transform.forward;
                aimPlane.transform.localScale = new Vector3(1, aimScale, 1);
            }
            else
            {
                rb.AddForce(force * forceMultiplier, ForceMode.Impulse);
                //aimRenderer.enabled = false;
                force = Vector3.zero;
                isMoving = true;
            }
        }
        if (isMoving && rb.velocity.magnitude < 0.25f)
        {
            rb.velocity = Vector3.zero;
            isMoving = false;
            gameObject.transform.position=new Vector3(0,1.48f,0);
            gameObject.transform.localEulerAngles = Vector3.zero;
        }
    }
}