using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{


    void FixedUpdate()
    {
        SetCameraPosition();
    }

    private void SetCameraPosition()
    {
        Vector3 newPosition = new Vector3();
        newPosition.x = (Player.Instance.transform.position.x * 0.05f + 0.95f * transform.position.x);
        newPosition.y = (Player.Instance.transform.position.y * 0.05f + 0.95f * transform.position.y);
        newPosition.z = -10;
        transform.position = newPosition;
        //transform.position = new Vector3(newPosition.x - 13, newPosition.y +15, -10f);
        
    }

    private void CameraShake()
    {

    }
}
