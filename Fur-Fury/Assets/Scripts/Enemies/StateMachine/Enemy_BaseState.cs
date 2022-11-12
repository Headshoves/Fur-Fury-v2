using UnityEngine;

public abstract class Enemy_BaseState
{
    public abstract void EnterState(Enemy_StateManager enemy);
    public abstract void UpdateState(Enemy_StateManager enemy);
    public abstract void OnTriggerEnter(Enemy_StateManager enemy, Collider collider);

}
