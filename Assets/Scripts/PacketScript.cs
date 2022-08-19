using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

    public class PacketScript : MonoBehaviour
    {
        [SerializeField] public string type;
        [SerializeField] public string malwareType;
        [SerializeField] protected Transform[] points;
        private NavMeshAgent agent;
        private int destPoint = 0;

        public static explicit operator PacketScript(GameObject v)
        {
            throw new NotImplementedException();
        }

        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            GotoNextPoint();
        }

        // Update is called once per frame
        void Update()
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }

        void GotoNextPoint()
        {
            // Returns if no points have been set up
            if (points.Length == 0)
                return;

            if (destPoint < points.Length){
                // Set the agent to go to the currently selected destination.
                agent.destination = points[destPoint].position;
                // Choose the next point in the array as the destination,
                // cycling to the start if necessary.
                destPoint++;
                return;
            }
            //else
            //{

              //  destPoint = 0;
                
            //}

        }
    }
