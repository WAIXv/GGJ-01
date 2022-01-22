using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_Bullet : MonoBehaviour
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
        rig.velocity = Vector2.right * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        UIManager ui = uiManager.GetComponent<UIManager>();
        EnemyHP enemyHP = enemyHPManager.GetComponent<EnemyHP>();

        switch (collision.tag)
        {
            case "Player2":
                //1-¡·2 1Ïò2Éä»÷
                ui.player2_HPLoss();//¿ÛÑª->ËÀÍö
                Destroy(gameObject);                
                break;


            case "Enemy":
                ui.player1_DefeatNumChange();
                enemyHP.EnemyHPLoss();//¿ÛÑª->ËÀÍö
                Destroy(gameObject);
                break;
            
            //Åöµ½À¶É«¸ø2¼ÓÑª
            case "BlueLove":
                collision.SendMessage("BlueDisappear");//À¶ÐÄÏûÊ§
                ui.player2_HPIncrease();
                Destroy(gameObject);
                break;

            default:
                break;
        }
    }

}
