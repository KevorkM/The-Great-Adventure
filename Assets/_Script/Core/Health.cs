using UnityEngine;


namespace RPG.Core{

    public class Health : MonoBehaviour
    {
        [SerializeField]
        float HealthPoint = 100.0f;

        public bool isDead = false;

        public bool IsDead(){
            return isDead;
        }

        public void TakeDamage(float damage){
            HealthPoint = Mathf.Max(HealthPoint - damage, 0);
            if (HealthPoint == 0 )
            {
                Die();
            }
        }

        private void Die()
        {
            if (isDead) return;

            isDead = true;

           
            GetComponent<Animator>().SetTrigger("die");

            GetComponent<ActionScheduler>().CancelCurrentAction();
            
        }
    }
}