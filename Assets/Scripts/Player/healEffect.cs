using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healEffect : MonoBehaviour
{
    ParticleSystem Effect;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = InGameManager.Instance.curPlayer.transform;
        Effect = GetComponent<ParticleSystem>();
        Effect.Play();
        StartCoroutine(healDestory(1f));

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (target.position - transform.position);
        transform.position += dir;
    }

    IEnumerator healDestory(float duration)
    {
        float timer = 0f;

        while (timer <= duration)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
        StopCoroutine(healDestory(0));
    }
}
