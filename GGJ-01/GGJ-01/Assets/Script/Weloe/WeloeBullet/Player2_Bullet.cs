using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_Bullet : MonoBehaviour
{
    public GameObject uiManager;
    public GameObject enemyHPManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        UIManager ui = uiManager.GetComponent<UIManager>();
        EnemyHP enemyHP = enemyHPManager.GetComponent<EnemyHP>();

        switch (collision.tag)
        {
            case "Player1":
                //1《-2
                ui.player1_HPLoss();//扣血->死亡
                Destroy(gameObject);
                break;


            case "Enemy":
                ui.player2_DefeatNumChange();//玩家2 杀敌数变化
                enemyHP.EnemyHPLoss();//扣血->死亡
                Destroy(gameObject);
                break;

            //碰到红色给1加血
            case "RedLove":
                collision.SendMessage("RedDisappear");//红心消失
                ui.player1_HPIncrease();//玩家 1 加血
                Destroy(gameObject);
                break;

            default:
                break;
        }
    }
}
