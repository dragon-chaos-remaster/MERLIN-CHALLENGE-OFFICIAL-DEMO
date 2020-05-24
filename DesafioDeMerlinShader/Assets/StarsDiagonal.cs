using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsDiagonal : MonoBehaviour
{

    [SerializeField] float vel;
    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3( -vel * Time.deltaTime, -vel * Time.deltaTime);
    }
}
