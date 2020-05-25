using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    static Transform cameraPos = null;
    // Start is called before the first frame update
    
    private void Awake()
    {
        if(cameraPos == null)
            cameraPos = Camera.main.transform;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(cameraPos.position.x,transform.position.y, cameraPos.position.z);
        transform.LookAt(targetPos);
    }
}
