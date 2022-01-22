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
                //1-��2 1��2���
                ui.player2_HPLoss();//��Ѫ->����
                Destroy(gameObject);                
                break;


            case "Enemy":
                ui.player1_DefeatNumChange();
                enemyHP.EnemyHPLoss();//��Ѫ->����
                Destroy(gameObject);
                break;
            
            //������ɫ��2��Ѫ
            case "BlueLove":
                collision.SendMessage("BlueDisappear");//������ʧ
                ui.player2_HPIncrease();
                Destroy(gameObject);
                break;

            default:
                break;
        }
    }

}
