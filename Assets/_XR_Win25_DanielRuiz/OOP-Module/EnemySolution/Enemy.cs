using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private Transform m_playerTarget;
    [SerializeField] private float m_attackRate = 3f;
    [SerializeField] private float m_attackRange = 10f;
    [SerializeField] private int m_attackDamage = 1;

    [SerializeField] private Transform m_torret;
    [SerializeField] private Projectile m_projectilePrefab;

    [field: SerializeField] public string Name { get; protected set; }

    private Coroutine attackCoroutine;

    private bool IsWithinAttackRange => Vector3.Distance(transform.position, m_playerTarget.position) < m_attackRange;

}
