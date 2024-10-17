using MyFps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{
    public class EnemyTest : MonoBehaviour
    {
        #region Variables
        // ü��
        [SerializeField] private float maxHealth = 20;
        private float currentHealth;

        private bool isDeath;
        #endregion

        private void Start()
        {
            currentHealth = maxHealth;
            isDeath = false;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            Debug.Log($"currentHealth: {currentHealth}");

            // ������ ȿ��
            
            if(currentHealth <= 0 && !isDeath)
            {
                Die();
            }
        }
        
        void Die()
        {
            isDeath = true;

            // ���� ó��
            // ���� - ����ġ, ��

            // ȿ��

            Destroy(gameObject, 3f);
        }
    }
}
