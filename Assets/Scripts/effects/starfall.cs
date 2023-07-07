using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starfall : MonoBehaviour
{
    public ParticleSystem bomb;
    ParticleSystem star;
    public Transform target;

    void Start()
    {
        star = GetComponent<ParticleSystem>();
        target = InGameManager.Instance.curPlayer.transform;

        star.Play();
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
        Instantiate(bomb, target.position, Quaternion.identity);
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            var enemy = collision.GetComponent<EnemyBase>();
            enemy.OnDamage(100000000);
        }
    }
}
