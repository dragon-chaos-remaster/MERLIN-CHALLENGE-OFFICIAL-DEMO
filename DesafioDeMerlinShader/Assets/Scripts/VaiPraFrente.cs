using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaiPraFrente : MonoBehaviour
{
    Rigidbody fisica;
    public float velocidade;
    public Transform projetil;
    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        fisica.AddForce(projetil.forward * velocidade * Time.deltaTime);
    }
}
