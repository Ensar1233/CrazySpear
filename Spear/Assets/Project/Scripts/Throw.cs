using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Throw : MonoBehaviour
{
    // 255 153 153
    [SerializeField] private Slider slider;
    [SerializeField] private Transform tSlider;

    public bool click;

    public void ThrowEnemy()
    {
        if (transform.childCount > 3)
        {
            FinalEnemyPosition enemyPosition;
            enemyPosition = transform.GetChild(transform.childCount - 1).GetComponent<FinalEnemyPosition>();
            enemyPosition.enabled = true;

            enemyPosition.head.GetComponent<SpearOut>().force = slider.value;
            click = true;
        }
    }
}
