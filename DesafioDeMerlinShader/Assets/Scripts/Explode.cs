using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Explode : MonoBehaviour
{
    [SerializeField] float explosionRadius = 3f;
    [SerializeField] float explosionForce;
    [SerializeField] float delay = 3f;
    float countdown;
    //bool canExplode;
    bool hasExploded;
    [SerializeField] TimeManager freezeFrame;
     
    [SerializeField] List<GameObject> listaDePedras = new List<GameObject>();
    [SerializeField] LayerMask layerDosInimigos;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    void Explosion()
    {
        Collider[] explosion = Physics.OverlapSphere(transform.position, explosionRadius, layerDosInimigos);
        foreach (Collider objetosAfetados in explosion)
        {
            Rigidbody rb = objetosAfetados.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius,1f,ForceMode.Impulse);   
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0 && !hasExploded)
        {
            for (int i = 0; i < listaDePedras.Count; i++)
            {
                listaDePedras[i].GetComponent<Rigidbody>().isKinematic = false;
                AudioManager.instance.sons[2].pitch += 0.08f;
            }
            Explosion();
            FindObjectOfType<AudioManager>().Play("rockexplode");
            
            freezeFrame.FreezeFrame();
            hasExploded = true;
        }
        if (hasExploded)
        {
            Time.fixedDeltaTime = .02f;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
