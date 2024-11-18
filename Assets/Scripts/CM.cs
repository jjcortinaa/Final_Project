using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM : MonoBehaviour
{
    public Rigidbody rb;
    public WheelCollider lfW,rfW,lbW,rbW;
    public float driveSpeed, steerSpeed;
    float hInput, vInput;
    float mult;


    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

    }
    private void FixedUpdate()
    {
        ForwardMovement(vInput);

        lfW.steerAngle = steerSpeed * hInput;
        rfW.steerAngle = steerSpeed * hInput;

    }

    private void ForwardMovement(float vInput)
    {
        float motor = vInput * driveSpeed;

        if (vInput > 0)
        {
            // Aplica motor torque
            lfW.motorTorque = motor * Time.timeScale;
            rfW.motorTorque = motor * Time.timeScale;
            lbW.motorTorque = motor * Time.timeScale;
            rbW.motorTorque = motor * Time.timeScale;
        }
        else
        {
            // Aplica brake torque (frenado)
            float brakeTorque = Mathf.Abs(motor); // Usa la magnitud del motor torque para el frenado
            lfW.brakeTorque = brakeTorque;
            rfW.brakeTorque = brakeTorque;
            lbW.brakeTorque = brakeTorque;
            rbW.brakeTorque = brakeTorque;
        }

        Debug.Log(rbW.motorTorque);
    }
    


}