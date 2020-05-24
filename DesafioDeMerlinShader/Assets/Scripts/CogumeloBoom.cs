using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogumeloBoom : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
        //colocar particulas de explosão
    }
}
