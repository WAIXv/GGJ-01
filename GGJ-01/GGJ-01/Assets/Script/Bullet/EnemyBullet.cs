using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject uiManager;
    public GameObject enemyHPManager;

    public float bulletSpeed;
    public Rigidbody2D bulletRb;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = Random.Range(1.0f, 2.0f);
        GameObject dadObject = this.transform.parent.gameObject;
        if (dadObject.name == "LeftGun") bulletSpeed = -bulletSpeed;
        //Debug.Log(dadObject.name);
        //Debug.Log(bulletSpeed);
        bulletRb = GetComponent<Rigidbody2D>();
        bulletRb.velocity = new Vector3(bulletSpeed, 0, 0);
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
