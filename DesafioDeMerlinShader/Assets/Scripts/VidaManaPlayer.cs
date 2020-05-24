using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VidaManaPlayer : MonoBehaviour
{
    public float vida = 100;

    public Image barraVida;
    public Text quantidadeVida;

    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        barraVida.fillAmount = vida / 100;
        quantidadeVida.text = (int)vida + " HP ";
        if (vida <= 0)
        {
            //Destroy(gameObject);
            //  gameObject.SetActive(false);
            animator.SetBool("Morreu", true);

        }
        if (vida > 100)
        {
            vida = 100;
        }
        if (vida < 0)
        {
            vida = 0;
        }

    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == ("coletavelVida") && (CompareTag("player")))
        {
            vida += 20;
        }
        if (other.tag == ("pedregulho") && (CompareTag("player")))
        {
            vida -= 10;

        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.collider.tag == ("inimigoFraco"))
        //{
        //    vida -= 10;

        //}
        //if (collision.collider.tag == ("inimigoTerra"))
        //{
        //    vida -= 15;

        //}
        switch (collision.collider.tag)
        {
            case "inimigoFraco":
                vida -= 10;
                break;
            case "inimigoMadeira":
                vida -= 10;
                break;
            case "inimigoTerra":
                vida -= 15;
                break;
            case "inimigoPedra":
                vida -= 5 * Mathf.Clamp(collision.gameObject.transform.localScale.magnitude, 1f, 4f);
                break;
            case "NaoSei":
                vida -= 5;

                break;

        }

    }
}
