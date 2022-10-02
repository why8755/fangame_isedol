using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectManager : MonoBehaviour
{
    public IEnumerator HitTesterParticle(ParticleSystem particleObject)
    {
        particleObject.Play();       
        yield return new WaitForSeconds(0.2f);            
        particleObject.Stop();  
    }
}