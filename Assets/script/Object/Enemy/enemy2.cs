using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy2 : MonoBehaviour
{
    public int maxHealth;
    public int curHealth;
    public Transform target;
    



    Rigidbody rigid;
    BoxCollider boxCollider;
    NavMeshAgent nav;
    Material mat;


    void Update()
    {
        nav.SetDestination(target.position);
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        nav = GetComponent<NavMeshAgent>();
        mat = GetComponent<MeshRenderer>().material;
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Melee") { 
            Weapon weapon = other.GetComponent<Weapon>();
            curHealth -= weapon.damage;
            Vector3 reactVec = transform.position - other.transform.position;

            
        
        }
    }


}