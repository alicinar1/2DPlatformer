using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectController : MonoSingleton<ParticleEffectController>
{
    [SerializeField] private GameObject jumpParticleSystem;

    public void StartJumpParticle()
    {
            GameObject obj = Instantiate(jumpParticleSystem, transform.position, Quaternion.identity);
            Destroy(obj, 1f);
    }


    private IEnumerator RunParticleDelay()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        
    }

}
