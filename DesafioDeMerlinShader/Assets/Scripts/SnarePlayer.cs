using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnarePlayer : MonoBehaviour
{
    [SerializeField] ControleJogador speedOfPlayer;
    [SerializeField] GameObject theBullet;
    [SerializeField] float tempoDoSnare = 2;
    float tempoAux;
    // Start is called before the first frame update
    void Start()
    {
        tempoAux = tempoDoSnare;
    }
    void Update()
    {
        tempoDoSnare -= Time.deltaTime;
        //if(tempoDoSnare )
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "player":
                speedOfPlayer.speed *= 0;
                break;
            
        }
    }
}
