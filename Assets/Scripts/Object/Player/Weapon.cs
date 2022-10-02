using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   public enum Type { Melee, Range };
    public Type type;
    public int damage;//무기 공격력
    public float rate;
    public BoxCollider meleeArea;
    public ParticleSystem hitparticle;
    public TrailRenderer trailEffect;


    public void Use()
    {
        if(type == Type.Melee)
        {
            StopCoroutine("swing");
            StartCoroutine("swing");
        }
    }

    IEnumerator swing()
    {
        yield return new WaitForSeconds(0.1f); //0.1�� ���
        meleeArea.enabled = true;
        trailEffect.enabled = true;
 
        yield return new WaitForSeconds(0.9f); //1������ ���
        meleeArea.enabled = false;
        
        yield return new WaitForSeconds(0.1f); //1������ ���
        trailEffect.enabled = false;
    }


 




}
