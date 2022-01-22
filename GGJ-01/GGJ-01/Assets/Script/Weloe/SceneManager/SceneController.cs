using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject uiManager;
    public GameObject itemCreat;

    public bool player1_isDead;
    public bool player2_isDead;
    public bool isPlayer1=true;
    public bool isPlayer2;

    public int itemNum=3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Revive();

        
    }

    public void Revive()
    {
        UIManager ui = uiManager.GetComponent<UIManager>();
        //血量为0
        //if (ui.player1_HP==0)
        //{
        //    player1.SetActive(false);
        //    player1_isDead = true;
        //}
        //if(player1_isDead && ui.player1_HP==1)
        //{
        //    player1.SetActive(true);
        //}
        DieAndRevive(player1_isDead, player1, ui.player1_HP);
        
        DieAndRevive(player2_isDead, player2, ui.player2_HP);
        

        

    }

    public void DieAndRevive(bool isDie,GameObject player,int HP)
    {
        if (HP == 0)
        {
            
            player.SetActive(false);
            isDie = true;
        }
        if (isDie && HP == 1)
        {

            player.SetActive(true);
            isDie = false;
        }
        
    }

    //其中一个玩家死亡时判断生成红心还是蓝心
    public void RedOrBlue()
    {
        UIManager ui = uiManager.GetComponent<UIManager>();
        ItemCreat creat = itemCreat.GetComponent<ItemCreat>();
        if (ui.player1_HP==0)
        {
            
            creat.CreatRedItem();
        }
        if (ui.player1_HP == 0)
        {
            
            creat.CreatBlueItem();
        }

    }

}
