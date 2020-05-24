using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUp : MonoBehaviour
{
    [SerializeField] float velUp;
    public void Upwards()
    {
        StartCoroutine(GoingUp(velUp));
    }

    IEnumerator GoingUp(float vel)
    {
        while (true)
        {
            transform.Translate(transform.up * vel * Time.deltaTime);
            yield return null;
        }
    }
}
