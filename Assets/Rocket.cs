using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    [SerializeField] Text text;
    [SerializeField] Light rightFlare;
    [SerializeField] Light leftFlare;
    [SerializeField] Text winScreen;

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
        text.text = fuel.ToString();
        
    }

    private void WinTheGame()
    {
        if (isWinning && !isThrusting)
        {
            print("You have won");
            winScreen.enabled = true;
            Invoke("LoadNextScene", 2f);
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
                LoadNextScene();
                break;
        }
    }

    private static void LoadNextScene()
    {
        SceneManager.LoadScene(0);
    }

    private void ThrustEffects()
    {
        if (isThrusting)
        {
            rightFlame.enabled = true;
            leftFlame.enabled = true;
            rightFlare.enabled = true;
            leftFlare.enabled = true;
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
            rightFlare.enabled = false;
            leftFlare.enabled = false;

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
