using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to handle smooth camera following which tracks player
public class CameraController : MonoBehaviour
{
    //refrence to the target it should follow
    public Transform target;

    //SPeed of the camera between current and desired position
    public float smoothSpeed = 8f;
    //Camera offset to maintain distance
    public Vector3 offset;

    //update function
    void Update()
    {
        //if no target it set return early to avoid error
        if (target == null) return;

        //Calculate the desired camera positiion based on the players postion and the offset
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, target.position.z + offset.z);
        //smoothly move between desired and current possition
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        //update the cameras position to desired position
        transform.position = SmoothedPosition;
    }
}
