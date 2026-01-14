using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
   [Header("Target")]
   public Transform target;

   [Header("offset")]
   public Vector3 offset;

   [Header("smoothness")]
   public float smoothspeed=8f;

    public void LateUpdate()
    {
        if(!target)
        {
            return;
        }
        else
        {
            Vector3 desiredposition = target.position+offset;
            transform.position=Vector3.Lerp(transform.position,desiredposition,smoothspeed*Time.deltaTime);
        }
    }

}
