using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectSystem : MonoSingleton<ParticleEffectSystem>
{
    [SerializeField] private GameObject jumpParticleEffect;

    public void StartJumpParticle()
    {
        if (!Player.Instance.IsJumpable)
        {
            GameObject obj = Instantiate(jumpParticleEffect, transform.position, Quaternion.identity);
            Destroy(obj, 1);
        }
    }
}
