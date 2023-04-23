using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemydestroyer : MonoBehaviour
{
    int ecount=0;
    Animator E_ani;
    private void Start()
    {
        E_ani = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("robo"))
        {
            E_ani.Play("flyharm");
        }
        if(other.gameObject.CompareTag("bullet"))
        {
            ecount++;
        }
        if(ecount>=2)
        {
            Destroy(gameObject);
        }
    }
}
