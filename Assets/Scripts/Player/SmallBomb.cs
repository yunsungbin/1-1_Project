using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBomb : MonoBehaviour
{
    ParticleSystem bombEffect;

    void Start()
    {
        bombEffect = GetComponent<ParticleSystem>();

        bombEffect.Play();
        StartCoroutine(bombMovement(1f));
    }

    IEnumerator bombMovement(float duration)
    {
        float timer = 0f;

        while (timer <= duration)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
