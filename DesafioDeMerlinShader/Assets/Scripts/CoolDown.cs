using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{
    public float tempoAtaqueFogo;
    public float tempoAtaqueRaio;
    public float tempoAtaqueSnare;
    public float waitFireRateFogo = 1;
    public float waitFireRateRaio = 1;
    public float waitFireRateSnare = 1;
    public bool podeAtacarFogo = true;
    public bool podeAtacarRaio = true;
    public bool podeAtacarSnare = true;

    public GameObject[] habilidadesShow;
    
    // Update is called once per frame
    void Update()
    {
        TempoSkill();
    }

    public void TempoSkill()
    {
        if (!podeAtacarFogo)
        {
            habilidadesShow[0].transform.GetChild(0).gameObject.SetActive(true);
            waitFireRateFogo += waitFireRateFogo * Time.deltaTime;
        }
        if (!podeAtacarRaio)
        {
            habilidadesShow[1].transform.GetChild(0).gameObject.SetActive(true);
            waitFireRateRaio += waitFireRateRaio * Time.deltaTime;
        }
        if (!podeAtacarSnare)
        {
            habilidadesShow[2].transform.GetChild(0).gameObject.SetActive(true);
            waitFireRateSnare += waitFireRateSnare * Time.deltaTime;
        }


        if (waitFireRateFogo >= tempoAtaqueFogo)
        {
            podeAtacarFogo = true;
            habilidadesShow[0].transform.GetChild(0).gameObject.SetActive(false);
        }
        if (waitFireRateRaio >= tempoAtaqueRaio)
        {
            podeAtacarRaio = true;
            habilidadesShow[1].transform.GetChild(0).gameObject.SetActive(false);
        }
        if (waitFireRateSnare >= tempoAtaqueSnare)
        {
            podeAtacarSnare = true;
            habilidadesShow[2].transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
