using UnityEngine;
using UnityEngine.AI;

public class Enemy_StateManager : MonoBehaviour
{
    Enemy_BaseState currentState;

    public Enemy_AttackState attackState = new Enemy_AttackState();
    public Enemy_FollowState followState = new Enemy_FollowState();
    public Enemy_StunState stunState = new Enemy_StunState();
    public Enemy_TakeDamageState takeDamageState = new Enemy_TakeDamageState();

    [Header("General Components and Attributes")]
    private Animator animator;
    public Animator Animator { get { return animator; } }

    [Header("Enemy Follow Attributes")]
    private NavMeshAgent _nma;
    public NavMeshAgent NMA { get { return _nma; }}

    private Collider coll;
    public Collider Coll { get { return coll; }}

    private Transform player;
    public Transform Player { get { return player; }}

    private Transform berco;
    public Transform Berco { get { return berco; } }

    [Header("Enemy Stun Attributes")]
    [SerializeField] private float timeStun = 5f;
    public float TimeStun { get { return timeStun; }}

    [Header("Enemy Attack Attributes")]
    [SerializeField] private float cooldownAttack = 2f;
    public float CooldownAttack { get { return cooldownAttack; }}

    private Berco_Life bercoLife;
    public Berco_Life BercoLife { get { return bercoLife; }}

    void Awake()
    {
        //Start state for the state machine
        currentState = followState;

        //Enemy Follow Components getters
        _nma = GetComponent<NavMeshAgent>();
        coll = GetComponent<Collider>();
        berco = GameObject.Find("Berco").transform;
        bercoLife = berco.GetComponent<Berco_Life>();
        player = GameObject.Find("Player").transform;

        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(Enemy_BaseState enemy)
    {
        currentState = enemy;
        currentState.EnterState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this, other);
    }
}
