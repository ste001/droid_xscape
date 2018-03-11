using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 30f;
    [Tooltip("In m")] [SerializeField]float xRange = 18f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 20f;
    [Tooltip("In m")] [SerializeField] float yMin = -6f;
    [Tooltip("In m")] [SerializeField] float yMax = 6f;

    
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;  // Also used for roll
    [SerializeField] float positionYawFactor = 2f;
    float xThrow, yThrow;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessTransform();
        ProcessRotation();
    }

    private void ProcessTransform()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float xRawPos = transform.localPosition.x + xOffset;
        float yRawPos = transform.localPosition.y + yOffset;
        float clampedXPos = Mathf.Clamp(xRawPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(yRawPos, yMin, yMax);

        transform.localPosition = new Vector3
            (clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlPitchFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
