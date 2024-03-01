using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform target;
    Vector3 cameraOffset;

    void Start()
    {
        cameraOffset = transform.position - target.position;
    }

    private void Update() 
    {
        transform.position = target.position + cameraOffset;
    }
  
}
