using System;
using System.Collections;
using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Enemy
{
    public class EnemyData : MonoBehaviour
    {
        public int hp = 3;
        public Transform spawnPoint;
        public TMP_Text damageText;
        public Animator animator;
        public bool isDead = false;

        public void Start()
        {
            RandomAnimation();
        }

        [Button]
        private void RandomAnimation()
        {
            var random = Random.Range(1, 4);
            Debug.Log(random);
            animator.SetInteger("A",random);
        }

        public void DoDamage()
        {
            var range = Random.Range(50, 100);
            hp -= 1;
            
            var instantiate = Instantiate(damageText, spawnPoint);
            instantiate.text = $"{range}";
            
            StartCoroutine(ShowTextAMoment(instantiate));
            
            if (hp <= 0 && !isDead)
            {
                isDead = true;
                Dead();
            }
            else
            {
                
            }
        }

        private void Dead()
        {
            
        }
        
        IEnumerator ShowTextAMoment(TMP_Text text)
        {
            text.gameObject.transform.DOScale((Vector3.one * 2), 2f);
            yield return new WaitForSeconds(2f);
            DestroyImmediate(text.gameObject);
        }
    }
}