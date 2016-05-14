using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
    private Vector3 mouseMovement;
    private float mouseSpeed = 8;

    void Start()
    {
        //offset = transform.position - player.transform.position;
        offset = new Vector3(0, (float)0, 0);
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        mouseMovement = new Vector3(0, mouseX * mouseSpeed, 0);
        transform.Rotate(mouseMovement);
    }
}
