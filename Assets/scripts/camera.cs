using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform PlayerCamera;
    public Vector2 sensitivity = new Vector2(2, 2);
    public Vector2 xyRotation = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseLook = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        xyRotation.x -= mouseLook.y * sensitivity.y;
        xyRotation.y += mouseLook.x * sensitivity.x;
        xyRotation.x = Mathf.Clamp(xyRotation.x, -90f, 90f);
        
        transform.eulerAngles = new Vector3(0f, xyRotation.y, 0f);
        
        PlayerCamera.localEulerAngles = new Vector3(xyRotation.x, 0f, 0f);

    }
}
