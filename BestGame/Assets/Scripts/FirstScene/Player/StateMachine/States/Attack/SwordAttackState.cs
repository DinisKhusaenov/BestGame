using System.Collections;
using UnityEngine;

public class SwordAttackState : AttackState
{
    private SwordAttackStateConfig _config;
    private Transform _attackPoint;
    private Player _player;

    public SwordAttackState(IStateSwitcher stateSwitcher, StateMachineData data, Player player) : base(stateSwitcher, data, player)
    {
        _config = player.Config.AttackStateConfig.SwordAttackStateConfig;
        _attackPoint = player.AttackPoint;
        _player = player;
    }

    public override void Enter()
    {
        base.Enter();

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _config.AttackRange, _config.EnemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>()?.TakeDamage(_config.Damage);
        }

        _player.StartCoroutine(DisableAttack());

        View.StartSwordAttack();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopSwordAttack();
    }

    public override void Update()
    {
        base.Update();
    }

    private IEnumerator DisableAttack()
    {
        yield return new WaitForSeconds(_config.AttackSpeed);

        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();
        else
            StateSwitcher.SwitchState<RunningState>();
    }
}
