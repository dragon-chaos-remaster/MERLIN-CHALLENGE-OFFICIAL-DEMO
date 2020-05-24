using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeDestroi : MonoBehaviour
{
    float tempoViva = 0;
    float tempoAtual = 1;
    public float tempoDestruicao;
    

    // Update is called once per frame
    void Update()
    {
        tempoViva += tempoAtual * Time.deltaTime;
        if (tempoViva >= tempoDestruicao)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            tempoViva = 0;
        }
    }
}
