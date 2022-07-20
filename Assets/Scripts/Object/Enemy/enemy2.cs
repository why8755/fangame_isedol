using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy2 : MonoBehaviour
{

    public int maxHealth;
    public int curHealth;

    public int defense;
    public int damage;
    public Transform target;
    
    public bool isHit = true;
    float hitRate = 0.1f;
    float hitDelay = 0f;

    Rigidbody rigid;
    BoxCollider boxCollider;
    NavMeshAgent nav;
    Material mat;


    void Update()
    {
        if(!isHit) //한번 맞고나서 0.1초 무적 킹아
        {
            hitDelay += Time.deltaTime * 0.92f;
            isHit = hitRate < hitDelay;
        }
        //nav.SetDestination(target.position);
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponentInChildren<BoxCollider>();
        //nav = GetComponent<NavMeshAgent>();
        //mat = GetComponent<MeshRenderer>().material;
       
    }
    private void OnTriggerEnter(Collider other)
    {
        /*
        if (other.tag == "Melee") { 
            Weapon weapon = other.GetComponentInParent<Weapon>();
            curHealth -= weapon.damage;
            other.enabled = false;
            Vector3 reactVec = transform.position - other.transform.position;
        }*/
    }


}