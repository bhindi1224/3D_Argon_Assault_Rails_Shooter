using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In m/s")] [SerializeField] float xSpeed = 4f;
    [Tooltip("In m/s")] [SerializeField] float ySpeed = 4f;
    [Tooltip("In m/s")] [SerializeField] float xLimit = 5f;
    [Tooltip("In m/s")] [SerializeField] float yUpperLimit = 5f;
    [Tooltip("In m/s")] [SerializeField] float yLowerLimit = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateXPosition();
        UpdateYPosition();
    }

    private void UpdateYPosition()
    {
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float NewYPos = Mathf.Clamp(rawNewYPos, yLowerLimit, yUpperLimit);
        transform.localPosition = new Vector3(transform.localPosition.x, NewYPos, transform.localPosition.z);
    }

    private void UpdateXPosition()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float NewXPos = Mathf.Clamp(rawNewXPos, -xLimit, xLimit);
        transform.localPosition = new Vector3(NewXPos, transform.localPosition.y, transform.localPosition.z);
    }
}
