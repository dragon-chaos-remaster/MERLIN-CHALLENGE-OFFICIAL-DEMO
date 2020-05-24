using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public List<GameObject> listaDeSpawns = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform crianca in transform)
        {
            listaDeSpawns.Add(crianca.gameObject);
        }
    }

    
}
