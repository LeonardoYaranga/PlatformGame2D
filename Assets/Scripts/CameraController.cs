using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform character;

    private float cameraSize;
    private float screenHeight;

    // Start is called before the first frame update
    void Start()
    {
        cameraSize = Camera.main.orthographicSize;
        screenHeight = cameraSize * 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateCameraPosition();
    }

    void CalculateCameraPosition()
    {
        int characterScreen =(int)(character.position.y/ screenHeight);
        float cameraHeight = (characterScreen * screenHeight) + cameraSize;

        transform.position = new Vector3(transform.position.x, cameraHeight, transform.position.z);
    }
}
