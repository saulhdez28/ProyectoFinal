using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyAttackController : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform firePoint;

    [SerializeField, Tooltip("Average attack time")]
    private float attackRate = 1.5f;

    [SerializeField, Tooltip("Attack range")]
    private float attackRange = 2f;

    [SerializeField]
    private float lifeTime = 3f;

    [SerializeField]
    private int attackDamage = 15;

    private float _attackTime;

    private bool _canAttack;

    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void AttackBullet()
    {
        _attackTime -= Time.deltaTime;
        if (_attackTime < 0.0F)
        {
            _attackTime = 0.0F;
        }

        if (_attackTime > 0.0F)
        {
            return;
        }

        if (!_canAttack)
        {
            return;
        }
        GameObject bullet =
            Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        Destroy(bullet, lifeTime);

        _attackTime = attackRate / attackRange;
    }

    public void SetCanAttack(bool canAttack)
    {
        _canAttack = canAttack;
    }
}
