using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField]
        float weaponRange = 4f;

        Transform target;
        
        private void Update()
        {
            if (target == null) return;

            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
            }
        }

        private bool GetIsInRange()
        {
            // GetComponent<ActionScheduler>().StartAction(this);
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget){
            target = combatTarget.transform;
        }

        public void Cancel(){
            target = null;
        }
    }
}