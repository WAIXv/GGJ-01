using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_Bullet : MonoBehaviour
{
    public float speed;
    public GameObject uiManager;
    public GameObject enemyHPManager;
    public Rigidbody2D rig;
    public Collider2D coll;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        rig.velocity = Vector2.right * speed * -1;
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
