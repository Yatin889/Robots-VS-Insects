using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bigEdestroyer : MonoBehaviour
{ 
    //Reference objects
    public GameObject HealthBar;
    public GameObject EneryBall;
    //public GameObject Boss_end;
    public Transform Boss_end;// correction gameonject didnot work
   
    //variable of components
    Rigidbody ergB;
    Rigidbody egB;
    Slider HB;
    Animator B_ani;
   
    private void Start()
    {
        B_ani = GetComponent<Animator>();
        HB = HealthBar.GetComponent<Slider>();
        ergB = EneryBall.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        // Invoke("shootenergy", Random.Range(5,15));  not good here multiple balls created looks shabby      
    }
    
    private void shootenergy()
    {
        egB = Instantiate(ergB, Boss_end.position, Boss_end.rotation);
        egB.AddForce(-400f, 0, 0);
        //Destroy(egB, 2f);//just stopped the ball after 2 sec i think because they loose their rigidbody    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {        
            HB.value--;
            B_ani.Play("BossHitAni");
            Invoke("shootenergy", Random.Range(2, 10));
            Destroy(other.gameObject);     
        }
        if (HB.value<= 0)//HB KE THROUGH CONTROL HAI USKI MAX MIN VALUE SET HAI
        {
            B_ani.Play("boss death ani");
            GetComponent<bigEdestroyer>().enabled = false;
            Destroy(gameObject,4f);
        }
    }
}
