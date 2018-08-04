using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In m/s")] [SerializeField] float speed = 6f;
    [Tooltip("In m")] [SerializeField] float xRange = 3.5f;
    [Tooltip("In m")] [SerializeField] float yRange = 2.5f;
    
    [SerializeField] float positionPitchFactor = 5f;
    [SerializeField] float controlPitchFactor = 5f;

    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlYawFactor = 5f;

    [SerializeField] float positionRollFactor = 5f;

    float xThrow, yThrow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {        
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        // pitch
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        // yaw
        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yawDuetoControlThrow = xThrow * controlYawFactor;
        float yaw = yawDueToPosition + yawDuetoControlThrow;
        // roll
        float rollDueToPosition = transform.localPosition.x * positionRollFactor;
        float roll = rollDueToPosition;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        float xOffset = xThrow * speed * Time.deltaTime;
        float yOffset = yThrow * speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);        

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
