using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Slider slider;
    public Gradient gradiente;
    public Image fill;

    
    public void SetVidaMaxima(int vida)
    {
        slider.maxValue = vida;
        slider.value = vida;

        fill.color = gradiente.Evaluate(1f);
    }

    public void SetVida(int vida)
    {
        slider.value = vida;

        fill.color = gradiente.Evaluate(slider.normalizedValue);
    }
}
