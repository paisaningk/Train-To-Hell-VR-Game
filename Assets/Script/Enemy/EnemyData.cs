using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Script.Enemy
{
    public class EnemyData : MonoBehaviour
    {
        public int hp = 100;
        public Transform spawnPoint;
        public TMP_Text damageText;


        public void DoDamage()
        {
            var range = Random.Range(50, 100);
            hp -= range;
            var instantiate = Instantiate(damageText, spawnPoint);
            instantiate.text = $"{range}";
            StartCoroutine(ShowTextAMoment(instantiate));
        }
        
        IEnumerator ShowTextAMoment(TMP_Text text)
        {
            text.gameObject.transform.DOScale((Vector3.one * 2), 2f);
            yield return new WaitForSeconds(3);
            DestroyImmediate(text.gameObject);
        }
    }
}