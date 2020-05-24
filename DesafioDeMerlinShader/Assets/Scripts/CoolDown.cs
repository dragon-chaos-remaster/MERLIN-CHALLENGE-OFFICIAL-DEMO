using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    
    // Update is called once per frame
    void Update()
    {
        TempoSkill();
    }

    public void TempoSkill()
    {
        if (!podeAtacarFogo)
        {
            waitFireRateFogo += waitFireRateFogo * Time.deltaTime;
        }
        if (!podeAtacarRaio)
        {
            waitFireRateRaio += waitFireRateRaio * Time.deltaTime;
        }
        if (!podeAtacarSnare)
        {
            waitFireRateSnare += waitFireRateSnare * Time.deltaTime;
        }


        if (waitFireRateFogo >= tempoAtaqueFogo)
        {
            podeAtacarFogo = true;
        }
        if (waitFireRateRaio >= tempoAtaqueRaio)
        {
            podeAtacarRaio = true;
        }
        if (waitFireRateSnare >= tempoAtaqueSnare)
        {
            podeAtacarSnare = true;
        }
    }
}
