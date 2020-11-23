using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject playerObject = null;

    private Vector3 camera_offset;

    void Start()
    {
        camera_offset = gameObject.transform.position - playerObject.transform.position;
    }

    void Update()
    {
        gameObject.transform.position = playerObject.transform.position + camera_offset;
    }
}
