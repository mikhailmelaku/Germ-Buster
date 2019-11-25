using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private float xCoordinate;
    private GameObject player;

    private float cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        cameraOffset = transform.position.x - player.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        xCoordinate = player.transform.position.x + cameraOffset;
        transform.position = new Vector3(xCoordinate, 0, -1.0f);
    }
}
