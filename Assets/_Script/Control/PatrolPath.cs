﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core{
    public class PatrolPath : MonoBehaviour
    {
        const float waypointGizmosRadius = 0.3f;

        private void OnDrawGizmosSelected() {
            for (int i = 0; i < transform.childCount ; i++)
            {
                int j = GetNextIndex(i);

                Gizmos.DrawSphere(GetWaypoint(i), waypointGizmosRadius);
                Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(j));
            }
        }

        public int GetNextIndex(int i)
        {
            if (i + 1 == transform.childCount){
                return 0;
            }

            return i + 1;
        }

        public Vector3 GetWaypoint(int i)
        {
            return transform.GetChild(i).position;
        }
    }
}
