using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomaDano : MonoBehaviour
{
    public int vida = 100;

    public BarraDeVida barraVida;
    DropItem drop;
    // Start is called before the first frame update

    private void Start()
    {
        if (gameObject.tag != "inimigoFraco" && gameObject.tag != "inimigoPedra" && gameObject.tag != "inimigoMadeira")
        {
            barraVida = GetComponentInChildren<BarraDeVida>();
            barraVida.SetVidaMaxima(vida);
        }
    }
    public void ShakeLife()
    {
        iTween.PunchScale(barraVida.gameObject, iTween.Hash("z", 0.5f,"amount", new Vector3(0.01f, 0.01f, 0.01f), "time",1f));
        iTween.PunchPosition(barraVida.gameObject, new Vector3(0.05f,0.05f,0.05f), 0.5f);
    }
    public void TomarDanos(int quantidade)
    {
        vida -= quantidade;
        //iTween.ShakeScale(barraVida.gameObject, iTween.Hash("z", 0.1f, "y", 0.05f, "amount", barraVida.gameObject.transform.localScale, "time", 0.1f));
        iTween.PunchPosition(gameObject, iTween.Hash("x",0.3f, "z",0.1f));
        //iTween.PunchScale(gameObject, iTween.Hash("y", 0.5f, "amount",Vector3.up));
        if (gameObject.tag != "inimigoFraco" && gameObject.tag != "inimigoPedra" && gameObject.tag != "inimigoMadeira")
            barraVida.SetVida(vida);
        if (vida <= 0)
        {
            FindObjectOfType<AudioManager>().Play("died");
            //drop.gameObject.GetComponent<DropItem>().Dropando();
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }

    }
}
