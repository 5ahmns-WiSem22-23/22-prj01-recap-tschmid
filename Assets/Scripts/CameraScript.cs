using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float damping;

    public float maxX;
    public float maxY;


    private Vector3 velocity = Vector3.zero;

    Camera cam;
    private void Start()
    {
        //läd Kamera
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        //Kamera folgt dem auto mit smoother bewegung 
        Vector3 movePosition = target.position + offset;

        //Kamera limits
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(Mathf.Clamp(movePosition.x, -maxX, maxX), Mathf.Clamp(movePosition.y, -maxY, maxY), movePosition.z), ref velocity, damping);

        //Kamera zoomt je weiter es an den Rand des spielfeldes kommt. 
        cam.orthographicSize = Mathf.Lerp(8, 10, Mathf.InverseLerp(maxY, -maxY, Mathf.Abs(transform.position.y)));
        cam.orthographicSize = Mathf.Lerp(8, 10, Mathf.InverseLerp(maxX, -maxX, Mathf.Abs(transform.position.x)));

    }
}
