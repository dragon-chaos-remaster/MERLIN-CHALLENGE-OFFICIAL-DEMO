using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool pausado;
    [SerializeField] GameObject particle;
    public GameObject pauseBox;
    [SerializeField] AudioClip click;

    public void ButtonScalePump(GameObject botao)
    {
        
        iTween.PunchScale(botao.gameObject,iTween.Hash("z",10f,"y",0.5f,"amount",botao.transform.localScale,"time",1f,"ignoretimescale",true));
        particle.transform.position = botao.transform.position;
        particle.transform.rotation = botao.transform.rotation;
        particle.SetActive(true);
        if (botao.gameObject.tag == "Resume")
        {
            Cursor.visible = false;
        }
        iTween.Stab(botao.gameObject,click,0.5f);
    }
    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Escape) && (!pausado))
        {
            // print(pausado);
            iTween.PunchScale(pauseBox.transform.GetChild(0).gameObject,iTween.Hash("z",10f,"y",0.5f,"amount",pauseBox.transform.GetChild(0).localScale,"time", 1f,"ignoretimescale",true));
            Cursor.visible = true;
            pausado = true;
            pauseBox.SetActive(true);
            Time.timeScale = 0;
           
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && (pausado))
        {
            
           // print(pausado);
            pausado = false;
            Cursor.visible = false;
            pauseBox.SetActive(false);
            pauseBox.transform.GetChild(0).localScale = Vector3.one;
            Time.timeScale = 1;
            
        }
    }
}
