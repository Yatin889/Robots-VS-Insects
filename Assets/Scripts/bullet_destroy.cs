using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_destroy : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2.0f);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("smlEnemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
