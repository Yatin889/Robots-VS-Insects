using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class moveNew : MonoBehaviour
{
    [SerializeField] InputAction movement;

    //refrence Objects
    public GameObject robo;
    public GameObject gun;
    public GameObject bullet_obj;
    public Transform gun_end;
    public GameObject RoboHealthBar;

    //Variable components of objects
    Rigidbody bul_rgd;
    Rigidbody bull;  
    Slider HealthBar;
    Animator R_ani;

    //input floats
    float xvari, yvari;
    float xadd, yadd;
    float flip;
    bool HaveGun = false;

    private void OnEnable()   //when screen is on or off aur minimized or not
    {
        movement.Enable();
    }
    private void OnDisable()
    {
        movement.Disable();// disable if above conditions are not there
    }

    void Start()
    {
        bul_rgd = bullet_obj.GetComponent<Rigidbody>(); //rigid body of bullet attached 
        HealthBar = RoboHealthBar.GetComponent<Slider>();
        R_ani = robo.GetComponent<Animator>();
    }
    void Update()
    {
        Pmovement();//movement related stuff

        AnimationControl();//fire bullets

        shoot();//Kill Enemy
    }

    private void Pmovement()
    {
        //xvari = movement.ReadValue<Vector2>();            Note: cannot convert vector2 into float

        xvari = movement.ReadValue<Vector2>().x;//+1,0,-1 are the values that comes out from pressing the keys
        yvari = movement.ReadValue<Vector2>().y;

        yadd = yvari * Time.deltaTime * 10 + transform.position.y;
        Vector3 ttposx = new Vector3(transform.position.x, yadd, transform.position.z);
        transform.position = ttposx;

        xadd = xvari * Time.deltaTime * 5 + transform.position.x;
        Vector3 ttposy = new Vector3(xadd, transform.position.y, transform.position.z);
        transform.position = ttposy;

        //if conditions for movement related animations or scales
        if (Input.GetKeyDown(KeyCode.RightArrow))
            scaleflip(1);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            scaleflip(-1);
    }

    private void shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && HaveGun)
        {
            gun.GetComponent<MeshRenderer>().enabled = true;//when first click switch on gun

            bull = Instantiate(bul_rgd, gun_end.position, gun_end.rotation); //need to understand from sir
            Debug.Log(gun_end.rotation.z);
            //had two values 1 and -1 when player flips so used it
            //bull.AddForce(400f, 0, 0); will only add force to bullet in +ve x we need to change when player flips scale so 
            //found out the sol

            bull.AddForce(-500f * gun_end.rotation.z, 0, 0);
        }
        if(Input.GetKey(KeyCode.Z))
        {
            HaveGun = true;
        }
    }

    private void AnimationControl()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.RightArrow)))
        {
            R_ani.Play("walk");
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            R_ani.Play("jump");
        }
        if (HealthBar.value == 0)
        {
            R_ani.Play("roboDeath");
            GetComponent<moveNew>().enabled = false;// switch off movement and animations of robo
            SceneManager.LoadScene(3);
        }
    }

    private void scaleflip(int sign)
    {
        flip = robo.transform.localScale.x;
        Vector3 flipx = new Vector3(sign * Mathf.Abs(flip), robo.transform.localScale.y, robo.transform.localScale.z);
        robo.transform.localScale = flipx;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("energyball"))
        {
            Destroy(other.gameObject);
            Debug.Log(HealthBar.value);
            HealthBar.value-=4;
            
        }
        if(other.gameObject.CompareTag("gun"))
        {
            Destroy(other.gameObject);//only destroy(other) does not work
                                      //gun.SetActive(true); didnot work
            HaveGun = true;
        }
        if(other.gameObject.CompareTag("razor"))
        {
            HealthBar.value = HealthBar.value-10f;
        }
        if(other.gameObject.CompareTag("enemy"))
        {
            HealthBar.value = HealthBar.value - 5f;
        }
        if (other.gameObject.CompareTag("smlEnemy"))
        {
            HealthBar.value = HealthBar.value - 1f;
        }
        if(other.gameObject.CompareTag("finish"))
        {
            SceneManager.LoadScene(2);
        }
        if(other.gameObject.CompareTag("fire"))
        {
            R_ani.Play("roboDeath");
            GetComponent<moveNew>().enabled = false;
        
        }
    }
    
}
