using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject bullet = null;
    private float attackSpeed = 1f;
    private float attackRange = 0.5f;

    private float bulletSpeed = 3f;

    private void Start()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                var obj = Instantiate(bullet);
                float angle = 30f;
                float standard = 90f;
                float theta = (i - 1) * angle + standard;
                float posX = Mathf.Cos(theta * Mathf.Deg2Rad) * attackRange;
                float posY = Mathf.Sin(theta * Mathf.Deg2Rad) * attackRange;
                Vector2 dir = new Vector2(posX, posY).normalized;
                float degree = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                obj.transform.rotation = Quaternion.Euler(0, 0, degree);
                obj.transform.position = new Vector2(obj.transform.position.x, transform.position.y);
                obj.gameObject.GetComponent<Rigidbody2D>().linearVelocity = dir * bulletSpeed;
            }

            yield return new WaitForSecondsRealtime(attackSpeed);

        }

    }
}
