using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour {

    [SerializeField] float rcsThrust = 250f;
    [SerializeField] float mainThrust = 5f;
    Rigidbody rigidBody;
    AudioSource audioSource;


    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }


	
	// Update is called once per frame
	void Update ()
    {
        GetInput();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //print("Collided");
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                {
                    print("Ok");
                }
                break;
            case "Finished":
                {
                    print("level accomplished");
                }
                break;
            default:
                {
                    print("Dead");
                }
                break;
        }
    }


    private void GetInput()
    {
        Thrust();
        Rotate();
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);
 
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

        }
        else
        {
            audioSource.Stop();
        }
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true;

        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.Q))

        {
            
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rigidBody.freezeRotation = false; // resume control of the rotation
    }
}
