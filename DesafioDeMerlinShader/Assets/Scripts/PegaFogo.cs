using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegaFogo : MonoBehaviour
{

    float tempoViva = 0;
    float tempoAtual = 1;
    public float tempoDestruicao;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tempoViva += tempoAtual * Time.deltaTime;
        if (tempoViva >= tempoDestruicao)
        {
            Destroy(gameObject);

        }
    }
}
