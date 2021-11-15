using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorCameraRotation : MonoBehaviour
{
    #if UNITY_EDITOR
    void Update()
    {
        transform.eulerAngles = transform.eulerAngles - new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X") * -1, 0);
    }
    #endif
}
