//using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private MeshRenderer meshRenderer;
    [SerializeField]
    private Color originColor;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        meshRenderer = GetComponent<MeshRenderer>();
        originColor = meshRenderer.material.color;
    }
    // Start is called before the first frame update

    public void TakeDamage(GameObject target) // 데미지 받은 경우
    {
        Weapon weapon = target.GetComponentInParent<Weapon>();
        int Hp = this.GetComponent<enemy2>().curHealth -= weapon.damage;
        Debug.Log("Damage : "+ weapon.damage +" Current Hp : "+ Hp);
        //target.GetComponent<Collider>().enabled = false; //데미지 2번터져서 넣어둔 임시 코드
        //Vector3 reactVec = transform.position - target.transform.position; //허수아비용에서는 필요없어서 뺏음
        StartCoroutine(OnHitColor(Hp));
    }

    private IEnumerator OnHitColor(int Hp)
    {
        meshRenderer.material.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        if(Hp <= 0)
        {
            meshRenderer.material.color = Color.gray;
        }
        else
        {
            meshRenderer.material.color = originColor;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
