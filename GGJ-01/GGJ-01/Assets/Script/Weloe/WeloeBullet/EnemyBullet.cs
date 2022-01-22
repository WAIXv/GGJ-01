using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
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
                ui.player1_HPLoss();//ø€—™->À¿Õˆ
                Destroy(gameObject);
                break;


            case "Player2":
                ui.player2_HPLoss();//ø€—™->À¿Õˆ
                Destroy(gameObject);
                break;



            default:
                break;
        }
    }
}
