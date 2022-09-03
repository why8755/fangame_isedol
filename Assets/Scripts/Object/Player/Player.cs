using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class Player : MonoBehaviour
{
    public bool mouseHoldCheck = true; // false일때는 유저행동불가
    public GameObject crosshair; // 임시 크로스헤어 제거용
    public GameObject weapon;

    public GameObject attackCollision;
    private Animator anima;

    private StarterAssetsInputs _input;
    private ThirdPersonController _third;

    public GameObject CameraRoot;
    public GameObject player;

    public float targetRotation;
    //체력
    public int maxHealth;
    public int curHealth;

    public int defense;//방어력
    public int damage;//공격력(유저 기본 공격력)
    public float rate; // 공속
    public float speed;

    public bool CanMove = true;
    public bool CanInput;
    public bool Local_input = true;
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
        Debug.Log(mouseHoldCheck);
        if(mouseHoldCheck){ // alt -> cant move 
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Attack();
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        //공격애니메이션동안 애니메이션으로 이동
        if(anima.GetCurrentAnimatorStateInfo(0).IsName("Slash") && anima.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.98f) 
        {
            anima.applyRootMotion = false;
            player.GetComponent<ThirdPersonController>().MoveSpeed = 2.0f;
            player.GetComponent<ThirdPersonController>().SprintSpeed = 5.335f;
            Local_input = true;
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
            if(!mouseHoldCheck){
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
                CanInput = false;
                Local_input = false;
                // when start animation, change move direction in StarterAssetsInputs & rotation in ThirdPersonController
                player.GetComponent<StarterAssetsInputs>().move = new Vector2(0.0f, 0.0f);
                
                targetRotation = player.GetComponent<ThirdPersonController>()._mainCamera.transform.eulerAngles.y;
				transform.rotation = Quaternion.Euler(0.0f, targetRotation, 0.0f);
                player.GetComponent<ThirdPersonController>()._targetRotation = player.GetComponent<ThirdPersonController>().rotation = targetRotation;
                
                weapon.GetComponent<Weapon>().Use();

                Invoke("molu", 0.01f);
                player.GetComponent<ThirdPersonController>().MoveSpeed = 0f;
                player.GetComponent<ThirdPersonController>().SprintSpeed = 0f;
                anima.SetTrigger("doSwing");
                anima.applyRootMotion = true;
                fireDelay = 0;
            }
        }
    }

    void molu()
    {
        CanInput = true;
        CanMove = true;
    }
}