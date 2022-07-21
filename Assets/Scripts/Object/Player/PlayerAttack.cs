using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine("AutoDisable");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && other.gameObject.GetComponentInParent<enemy2>().isHit) // 공격했을때 적이고 무적이 아닐시 
        {
            other.GetComponent<EnemyControl>().TakeDamage(this.gameObject);
            other.gameObject.GetComponentInParent<enemy2>().isHit = false;
        }
    }
    private IEnumerable AutoDisable()
    {
        yield return new WaitForSeconds(0.1f);

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
