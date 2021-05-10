using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    [SerializeField] float controlSpeed=10f;

    // Update is called once per frame
    void Update()
    {
        float xThrow=Input.GetAxis("Horizontal");
        float yThrow=Input.GetAxis("Vertical");
   
        float xOffset=xThrow*Time.deltaTime*controlSpeed;
        float yOffset=yThrow*Time.deltaTime*controlSpeed;

        float newXPos=transform.localPosition.x + xOffset;
        float newYPos=transform.localPosition.y + yOffset;

        transform.localPosition =   new Vector3(newXPos, newYPos, transform.localPosition.z);
   
    }
}
