using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoDano : MonoBehaviour
{



    TomaDano dano;
    public int dFogo;
    public int dRaio;
    public int dNaoSei;
    public int dAtaqueBasico;
    public int dFogoArea;

    public float duracaoSnare;
    Snared snare;
    // Start is called before the first frame update
    void Start()
    {
        snare = GetComponent<Snared>();
        dano = GetComponent<TomaDano>();
    }

    // Update is called once per frame
    void Update()
    {
        snare.Desnare(duracaoSnare);
    }

    private void OnDisable()
    {
        dano.vida = 50;
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "bolaFogo":
                dano.gameObject.GetComponent<TomaDano>().TomarDanos(dFogo);
                break;
            case "Raio":

                dano.gameObject.GetComponent<TomaDano>().TomarDanos(dRaio);
                break;
            case "NaoSei":
                if (snare.gameObject.CompareTag("inimigoMadeira"))
                {
                    dano.gameObject.GetComponent<TomaDano>().TomarDanos(dNaoSei);
                }
                else
                {
                    snare.gameObject.GetComponent<Snared>().Snare();
                    dano.gameObject.GetComponent<TomaDano>().TomarDanos(dNaoSei);
                }
                
                break;
            case "RaizDoPlayer":
                snare.gameObject.GetComponent<Snared>().Snare();
                dano.gameObject.GetComponent<TomaDano>().TomarDanos(dNaoSei);
                break;
            case "ataqueBasico":

                dano.gameObject.GetComponent<TomaDano>().TomarDanos(dAtaqueBasico);
                break;
            case "pegaFogo":

                dano.gameObject.GetComponent<TomaDano>().TomarDanos(dFogoArea);
                break;



        }
    }




}
