using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    [Header("敌人血量")]
    public Slider enemyHP;
    // Start is called before the first frame update
    void Start()
    {
        enemyHP.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.K))
        //{
        //    EnemyHPLoss();
        //}
    }

    //敌人扣血
    public void EnemyHPLoss()
    {
        enemyHP.value -= 0.333f;

        //敌人死亡
        if (enemyHP.value <= 0)
        {
            Destroy(gameObject);
            //敌人
        }
    }
}
