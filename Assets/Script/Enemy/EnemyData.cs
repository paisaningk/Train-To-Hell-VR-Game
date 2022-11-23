using System;
using System.Collections;
using DG.Tweening;
using Script.Game;
using Script.Sound;
using Sirenix.OdinInspector;
using TMPro;
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
        public ScoreCount scoreCount;
        private static readonly int A = Animator.StringToHash("A");
        private static readonly int IsDead = Animator.StringToHash("isDead");

        public void Start()
        {
            RandomAnimation();
        }

        [Button]
        private void RandomAnimation()
        {
            var random = Random.Range(1, 3);
            Debug.Log(random);
            animator.SetInteger(A,random);
        }

        public void DoDamage()
        {
            if (isDead) return;
            hp -= 1;
            
            var instantiate = Instantiate(damageText, spawnPoint);
            var range = Random.Range(50, 100);
            instantiate.text = $"{range}";
            
            StartCoroutine(ShowTextAMoment(instantiate));
            
            if (hp <= 0 && !isDead)
            {
                Dead();
            }
            else
            {
                SoundManager.Instance.Play("Hit");
            }
        }

        private void Dead()
        {
            StartCoroutine(DelayDead());
            SoundManager.Instance.Play("Dead");
            isDead = true;
            scoreCount.AddScore();
        }
        
        IEnumerator ShowTextAMoment(TMP_Text text)
        {
            text.gameObject.transform.DOScale((Vector3.one * 2), 0.5f);
            text.color = Color.red;
            yield return new WaitForSeconds(0.5f);
            DestroyImmediate(text.gameObject);
        }
        
        IEnumerator DelayDead()
        {
            animator.SetBool(IsDead,true);
            yield return new WaitForSeconds(4f);
            DestroyImmediate(this.gameObject);
        }
    }
}