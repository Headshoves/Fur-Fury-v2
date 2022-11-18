using UnityEngine;
using UnityEngine.AI;

public class Enemy_StateManager : MonoBehaviour
{
    Enemy_BaseState currentState;

    public Enemy_AttackState attackState = new Enemy_AttackState();
    public Enemy_FollowState followState = new Enemy_FollowState();
    public Enemy_StunState stunState = new Enemy_StunState();
    public Enemy_TakeDamageState takeDamageState = new Enemy_TakeDamageState();
    public Enemy_DieState dieState = new Enemy_DieState();

    [Header("General Components and Attributes")]
    private Animator animator;
    public Animator Animator { get { return animator; } }
    
    private Rigidbody rb;
    public Rigidbody Rigidbody { get { return rb; } }

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
    public bool isStuned;

    [Header("Enemy Attack Attributes")]
    [SerializeField] private float cooldownAttack = 2f;
    public float CooldownAttack { get { return cooldownAttack; }}

    private Berco_Life bercoLife;
    public Berco_Life BercoLife { get { return bercoLife; }}

    [Header("Enemy Life Attributes")]
    [SerializeField] private int life = 2;
    public int Life { get { return life; } set { life = value; } }

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
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

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
