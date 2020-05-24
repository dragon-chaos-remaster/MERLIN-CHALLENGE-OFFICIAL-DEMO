using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    // public float forcaGiro;
    //Rigidbody fisica;
    // Start is called before the first frame update
    void Start()
    {
        //  fisica = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("player"))
        {
            Destroy(gameObject);

        }
    }
}
