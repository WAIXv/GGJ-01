using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_Bullet : MonoBehaviour
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
