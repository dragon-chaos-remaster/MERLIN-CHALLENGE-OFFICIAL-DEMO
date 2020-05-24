using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [SerializeField] Animator camerasAnimator;

    //[SerializeField] bool trocarIlha = true;

    [SerializeField] int nIlha;

    //[SerializeField] string nomeDaIlha;

   // [SerializeField] WaveSpawner pontosDeSpawn;

   // [SerializeField] List<GameObject> ilhas = new List<GameObject>();
    
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            camerasAnimator.SetInteger("nIlha", nIlha);
            /*for (int i = 0; i < pontosDeSpawn.spawnPoints.Length; i++)
            {
                pontosDeSpawn.spawnPoints[i].position = ilhas[nIlha].transform.position + (Vector3.forward * 10);
            }*/
            
            //camerasAnimator.SetBool("trocarDeIlha", trocarIlha);
            //StartCoroutine(TempoPraTrocar());
        }

    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "player")
    //    {
    //        camerasAnimator.SetInteger("nIlha", 0);
    //    }
    //}

    //IEnumerator TempoPraTrocar()
    //{
    //    yield return new WaitForSeconds(1f);
    //    trocarIlha = false;

    //}

}
