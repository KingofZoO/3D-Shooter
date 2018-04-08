using System;
using UnityEngine;
using MyNameSpace;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class MyAICharacterControl : MonoBehaviour, ISetDamage
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        private Transform target;                                    // target to aim for

        [SerializeField] private float hp = 10f;
        private bool isDead = false;
        private bool spawnIsDone = false;

        private void Start()
        {
            target = GameObject.Find("FPSController").transform;

            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }


        private void Update()
        {
            if (isDead)
                Destroy(gameObject);

            if (target != null)
                agent.SetDestination(target.position);

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        public void ApplyDamage(float damage)
        {
            if (hp > 0)
                hp -= damage;

            if (hp <= 0 && !spawnIsDone)
            {
                spawnIsDone = true;
                hp = 0;
                isDead = true;
                MyMain.Instance.SpawnController.SpawnBot();
            }
        }
    }
}
