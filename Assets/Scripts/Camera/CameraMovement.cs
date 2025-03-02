using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Camera camera;

    float horizontal;
    float vertical;
    float mouse;

    float kaef = 0.4f;
    float kaefZoom = 25f;

    void Start()
    {
        camera = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * kaef;
        vertical = Input.GetAxis("Vertical") * kaef;

        mouse = Input.GetAxis("Mouse ScrollWheel") * kaefZoom;

        camera.transform.position += new Vector3(horizontal,0f, vertical);
        camera.fieldOfView -= mouse;
    }
}
