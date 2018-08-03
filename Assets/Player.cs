using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In m/s")][SerializeField] float xSpeed = 4f;
    [SerializeField] float xRestriction = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float NewXPos = Mathf.Clamp(rawNewXPos, -xRestriction, xRestriction);
        transform.localPosition = new Vector3(NewXPos, transform.localPosition.y, transform.localPosition.z);
	}
}
