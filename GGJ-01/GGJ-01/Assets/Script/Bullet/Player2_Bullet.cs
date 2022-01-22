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
                //1��-2
                ui.player1_HPLoss();//��Ѫ->����
                Destroy(gameObject);
                break;


            case "Enemy":
                ui.player2_DefeatNumChange();//���2 ɱ�����仯
                enemyHP.EnemyHPLoss();//��Ѫ->����
                Destroy(gameObject);
                break;

            //������ɫ��1��Ѫ
            case "RedLove":
                collision.SendMessage("RedDisappear");//������ʧ
                ui.player1_HPIncrease();//��� 1 ��Ѫ
                Destroy(gameObject);
                break;

            default:
                break;
        }
    }
}
