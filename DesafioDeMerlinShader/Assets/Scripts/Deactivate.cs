using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    float time = 2.3f;
   
    // Update is called once per frame
    void Update()
    {
        time -= Time.unscaledDeltaTime;
        if(time <= 0)
        {
            time = 2.3f;
            gameObject.SetActive(false);
        }
    }
}
