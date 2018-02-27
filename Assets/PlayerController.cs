using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 20f;
    [Tooltip("In m")] [SerializeField]float xRange = 18f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float xRawPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(xRawPos, -xRange, xRange);

        transform.localPosition = new Vector3
            (clampedXPos, transform.localPosition.y, transform.localPosition.z);
	}
}
