using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public Transform cameraPos;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(cameraPos.position.x,transform.position.y, cameraPos.position.z);
        transform.LookAt(targetPos);
    }
}
