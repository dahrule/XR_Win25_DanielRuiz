using UnityEngine;

public class Slime_OOP : Enemy
{
    protected override void Update()
    {
        base.Update();

        if(!IsWithinAttackRange)
            MoveTowardsPlayer();
    }

    protected override void Attack()
    {
        base.Attack();
    }

    private void MoveTowardsPlayer()
    {
        if (m_playerTarget == null) return;

        transform.position = Vector3.MoveTowards(transform.position, 
            m_playerTarget.position, m_moveSpeed * Time.deltaTime);

    }
}
