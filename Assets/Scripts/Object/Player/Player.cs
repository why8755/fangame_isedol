using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class Player : MonoBehaviour
{
    public GameObject weapon;

    public GameObject attackCollision;
    private Animator anima;

    private StarterAssetsInputs _input;

    public GameObject CameraRoot;
    public GameObject player;

    //stat
    public int maxHealth;
    public int curHealth;

    public int defense;
    public int damage;

    public bool CanMove = true;
    public bool CanInput;
    bool fDown;
    bool isFireReady = true;
    public bool isHit = true; //맞을 수 있는가

    float rotation;
    float fireDelay;

    public GameObject target;
    private Vector3 targetPosition;

    Vector3 moveVec;

    private void Awake()
    {
        anima = GetComponent<Animator>();
        CanInput = true;
        CanMove = true;
    }

    void Update()
    {
        GetInput();
        Attack();

        if (CanMove == false)
        {    
            targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            transform.LookAt(targetPosition);
        }


    }

   public void OnattacCollision()
    {
        attackCollision.SetActive(true);
    }

    void GetInput()
    {
        fDown = Input.GetMouseButtonDown(0);   
    }

    void Attack()
    {       

        fireDelay += Time.deltaTime * 0.92f;
        isFireReady = weapon.GetComponent<Weapon>().rate < fireDelay;
        
        if (player.GetComponent<ThirdPersonController>().Grounded == true)
        {
            if (fDown && isFireReady)
            {
                CanMove = false;
                weapon.GetComponent<Weapon>().Use();

                Invoke("molu", 0.15f);
                player.GetComponent<ThirdPersonController>().MoveSpeed = 1.22f;
                player.GetComponent<ThirdPersonController>().SprintSpeed = 2.55f;
                anima.SetTrigger("doSwing");
                fireDelay = 0;
                CanInput = true;
                player.transform.rotation = Quaternion.Euler(0.0f, player.GetComponent<ThirdPersonController>().rotation, 0.0f);
            }
        }
        else
        {
            if (fDown && isFireReady)
            {
                
                weapon.GetComponent<Weapon>().Use();
                anima.SetTrigger("doSwing");
                Invoke("checkspeed", 0.95f);
                player.GetComponent<ThirdPersonController>().MoveSpeed = 1.5f;
                player.GetComponent<ThirdPersonController>().SprintSpeed = 4.355f;
                fireDelay = 0;
                player.GetComponent<ThirdPersonController>().Grounded = false;
            }
        }

    }

    void molu()
    {
        CanInput = true;
        Invoke("checkspeed", 0.95f);
    }
    void checkspeed()
    {
        CanMove = true;
        CanInput = true;
        player.GetComponent<ThirdPersonController>().MoveSpeed = 2.0f;
        player.GetComponent<ThirdPersonController>().SprintSpeed = 5.335f;
    }

}