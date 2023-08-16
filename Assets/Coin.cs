using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : MonoBehaviour
{

    public ParticleSystem collisionPartickeSystem;
    public MeshRenderer sr;
    public bool once = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collect") && once)
        {
            var em = collisionPartickeSystem.emission;
            var dur = collisionPartickeSystem.duration;

            em.enabled = true;
            collisionPartickeSystem.Play();

            once = false;
            Destroy(sr);
            Invoke(nameof(DestroyObj), dur);
          

        }
    }

    void DestroyObj()
    {
        Destroy(gameObject);
    }

}
