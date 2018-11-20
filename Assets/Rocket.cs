using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    [SerializeField] int maxFuel = 30000;


    #region variables
    [SerializeField] bool isRotatingRight = false;
    Rigidbody rb;
    [SerializeField] float RcsThrust;
    [SerializeField] float mainThrust;
    public AudioSource thrustSound;
    public MeshRenderer rightFlame;
    public MeshRenderer leftFlame;
    public bool isThrusting = false;
    private bool isFueling;
    public float fuel;
    public float fuelingRate;
    public float fuelUsage;
    private bool isWinning = false;
<<<<<<< HEAD
<<<<<<< HEAD
    [SerializeField] Text text;
    [SerializeField] Light rightFlare;
    [SerializeField] Light leftFlare;
    [SerializeField] Text winScreen;
    [SerializeField] UnityEngine.Object debris;
    private bool isexploding = false;
=======
>>>>>>> parent of 91da4f4... added lighting
=======
>>>>>>> parent of 91da4f4... added lighting

    #endregion

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        thrustSound.Stop();
        fuel = maxFuel;

	}
	
	// Update is called once per frame
	void Update ()
    {
        ThrustControl();
        RotationMechanic();
        ThrustEffects();
        FuelingProcess();
        WinTheGame();
<<<<<<< HEAD
<<<<<<< HEAD
        text.text = fuel.ToString();

    }

    private void Explode()
    {
        
            for (int i = 0; i < 20; i++)
            {
                Instantiate(debris,this.transform);
            }
        
=======
>>>>>>> parent of 91da4f4... added lighting
=======
>>>>>>> parent of 91da4f4... added lighting
    }

    private void WinTheGame()
    {
        if (isWinning && !isThrusting)
        {
            print("You have won");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "fuel":
                isFueling = false;
                break;
            case "win":
                isWinning = false;
                break;
            default:
                break;
        }
    }

    private void FuelingProcess()
    {
        if (isFueling && fuel < maxFuel)
        {
            fuel = fuel + fuelingRate;
        }
        else if (isFueling && fuel > maxFuel)
        {
            fuel = maxFuel;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "friendly":
                print(" i hit a friend");
                break;
            case "fuel":
                print("fueling");
                isFueling = true;
                break;
            case "win":
                print(" just stop now ");
                isWinning = true;
                break;
            default:
                print(" i died ");
<<<<<<< HEAD
<<<<<<< HEAD
                isexploding = true;
                Invoke("LoadNextScene", 2f);

=======
>>>>>>> parent of 91da4f4... added lighting
=======
>>>>>>> parent of 91da4f4... added lighting
                break;
        }
    }
        

        private void ThrustEffects()
    {
        if (isThrusting)
        {
            rightFlame.enabled = true;
            leftFlame.enabled = true;
            fuel = fuel - fuelUsage;
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
        if (Input.GetKey(KeyCode.Space) && fuel > 0f)
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
