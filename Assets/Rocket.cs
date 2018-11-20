using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {


    #region variables
    public bool isRotatingRight = false;
    Rigidbody rb;
    public float RcsThrust;
    public float mainThrust;
    public AudioSource thrustSound;
    public MeshRenderer rightFlame;
    public MeshRenderer leftFlame;
    public bool isThrusting = false;
    
    #endregion

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        thrustSound.Stop();
	}
	
	// Update is called once per frame
	void Update () {
        ThrustControl();
        RotationMechanic();
        ThrustEffects();
	}

    private void ThrustEffects()
    {
        if (isThrusting)
        {
            rightFlame.enabled = true;
            leftFlame.enabled = true;
            if (thrustSound.isPlaying == false)
            {
                thrustSound.Play();
            }
        }
        else
        {
            rightFlame.enabled = false;
            leftFlame.enabled = false;
            thrustSound.Stop();

        }
    }

    private void RotationMechanic()
    {
        rb.freezeRotation = true;
        if (Input.GetKey(KeyCode.A) && isRotatingRight == false)
        {
            //print("rotating left");
            transform.Rotate(Vector3.forward * (RcsThrust * Time.deltaTime));

        }
        else if (Input.GetKey(KeyCode.D))
        {
            isRotatingRight = true;
            //print("rotating right");
            transform.Rotate(-Vector3.forward * (RcsThrust * Time.deltaTime));

        }
        else
        {
            isRotatingRight = false;
            transform.Rotate(Vector3.forward * 0);
            rb.freezeRotation = false;
        }
    }

    private void ThrustControl()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //print("thrusting");
            rb.AddRelativeForce(Vector3.up * (mainThrust * Time.deltaTime));
            isThrusting = true;
        }
        else
        {
            isThrusting = false;
        }
    }
}
