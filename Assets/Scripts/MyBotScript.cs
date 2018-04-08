using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MyNameSpace;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(ThirdPersonCharacter))]

public class MyBotScript : MyBaseObjectScene, ISetDamage
{
    public float activeDistance = 20f;
    public float activeAngle = 70f;
    public float hp = 10f;

    private float waitTime;
    private float maxHp;
    private float currentTime;
    private float stoppingPointDis = 0.1f;
    private float stoppingPlayerDis = 2f;

    private NavMeshAgent agent;
    private ThirdPersonCharacter character;
    private Transform target;
    private Transform player;
    private MyGunBot weapon;

    private bool spawnIsDone = false;
    private bool isDead = false;
    private bool isAngry = false;

    private Vector3 castPosition;
    private WayPointsController WPController;

    protected override void Awake()
    {
        base.Awake();

        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
        player = GameObject.Find("FPSController").transform;
        weapon = transform.Find("WeaponGun").GetComponent<MyGunBot>();
    }

    private void Start()
    {
        WPController = MyMain.Instance.WayPointsController;
        waitTime = Random.Range(3f, 6f);
        maxHp = hp;
    }

    private void Update()
    {
        if (isDead)
        {
            MyMain.Instance.GeneratedObjectController.AddSceneObject(weapon.transform.position);
            Destroy(gameObject);
        }

        currentTime += Time.deltaTime;

        var distance = Vector3.Distance(transform.position, player.position);
        var angle = Vector3.Angle(transform.forward, player.position - transform.position);

        if (distance < activeDistance && angle < activeAngle && IsPlayerVisible())
        {
            SetPlayerFounded();

            if (distance <= stoppingPlayerDis + 0.5f)
                weapon.MeleeAnimationOn();
        }
        else if (currentTime > waitTime)
        {
            currentTime = 0;
            waitTime = Random.Range(3f, 6f);
            SetPatrolling();
        }

        if (agent.remainingDistance > agent.stoppingDistance)
            character.Move(agent.desiredVelocity, false, false);
        else character.Move(Vector3.zero, false, false);
    }

    private bool IsPlayerVisible()
    {
        castPosition = new Vector3(transform.position.x, transform.position.y + 0.8f * agent.height, transform.position.z);
        RaycastHit hit;
        if (Physics.Linecast(castPosition, player.position, out hit))
            if (hit.transform == player)
            {
                return true;
            }

        return false;
    }

    private void SetPatrolling()
    {
        agent.stoppingDistance = stoppingPointDis;
        agent.SetDestination(WPController.GetRandomWayPoint());
        isAngry = false;
    }

    private void SetPlayerFounded()
    {
        agent.stoppingDistance = stoppingPlayerDis;
        agent.SetDestination(player.position);
        isAngry = true;
    }

    public void ApplyDamage(float damage)
    {
        if (hp > 0)
            hp -= damage;

        if (hp > maxHp)
            hp = maxHp;

        if (hp <= 0 && !spawnIsDone)
        {
            spawnIsDone = true;
            hp = 0;
            isDead = true;
            MyMain.Instance.SpawnController.SpawnBot();
        }
    }

    public bool IsAngry
    {
        get { return isAngry; }
    }
}
