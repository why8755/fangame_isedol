using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class Player : MonoBehaviour
{
    public bool mouseHoldCheck = true; // true일때는 유저행동불가
    public GameObject crosshair; // 임시 크로스헤어 제거용
    public GameObject weapon;

    public GameObject attackCollision;
    private Animator anima;

    private StarterAssetsInputs _input;
    private ThirdPersonController _third;

    public GameObject CameraRoot;
    public GameObject player;

    //체력
    public int maxHealth;
    public int curHealth;

    public int defense;//방어력
    public int damage;//공격력(유저 기본 공격력)
    public float rate; // 공속
    public float speed;

    public bool CanMove = true;
    public bool CanInput;
    bool fDown;
    bool isFireReady = true;
    public bool isHit = true; //맞을 수 있는가

    float rotation;
    float fireDelay;

    private int _animIDSpeed;
	private int _animIDMotionSpeed;

    public GameObject target;
    private Vector3 targetPosition;

    Vector3 moveVec;

    private void Awake()
    {
        _third = GetComponent<ThirdPersonController>();
        anima = GetComponent<Animator>();
        _animIDSpeed = Animator.StringToHash("Speed");
		_animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
        CanInput = true;
        CanMove = true;
    }

    void Update()
    {
        GetInput();

        if(mouseHoldCheck){ // alt -> cant move 
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Attack();

            if (CanMove == false)
            {    
                targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                transform.LookAt(targetPosition);
            }
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

   public void OnattacCollision()
    {
        attackCollision.SetActive(true);
    }

    void GetInput()
    {
        fDown = Input.GetMouseButtonDown(0);   

        if(Input.GetKeyDown(KeyCode.LeftAlt) && (CanMove && _third.Grounded))
        {
            if(mouseHoldCheck){
                anima.SetFloat(_animIDSpeed, 0.01f);
			    anima.SetFloat(_animIDMotionSpeed, 0.01f);
            }
            CanInput = !CanInput;
            mouseHoldCheck = !mouseHoldCheck;
            crosshair.SetActive(mouseHoldCheck);
        }
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