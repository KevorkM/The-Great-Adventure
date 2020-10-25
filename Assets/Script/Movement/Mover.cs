﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;

namespace RPG.Movement{
    public class Mover : MonoBehaviour ,IAction
    {
        [SerializeField]
        Transform target;

        NavMeshAgent navMeshAgent;

        private void Start() {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {

            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination){

            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination);
        }


        private void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forward", speed);
        }

        public void Cancel(){
            navMeshAgent.isStopped = true;
        }


        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }
    }
}
