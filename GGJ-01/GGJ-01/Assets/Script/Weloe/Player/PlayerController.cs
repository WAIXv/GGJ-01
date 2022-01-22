using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1;


    public float bulletSpeed = 5;
    public float fireCD;
    public float fireTimeValue;


    public GameObject bulletPrefab;

    private Collider2D coll;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        //攻击CD
        if (fireTimeValue >= fireCD)
        {

            Fire();
        }
        else
        {
            fireTimeValue += Time.deltaTime;
        }

    }


    //移动
    private void Move()
    {
        //更改Sprite来实现方向变化
        float h = Input.GetAxisRaw("HorizontalPlayer1");
        transform.Translate(Vector3.right * h * moveSpeed * Time.deltaTime, Space.World);
        if (h < 0)
        {


        }
        else if (h > 0)
        {

        }

        if (Mathf.Abs(h) > 0.05f)
        {

        }

        //优先级
        if (h != 0)
        {
            return;
        }

        float v = Input.GetAxisRaw("VerticalPlayer1");
        transform.Translate(Vector3.up * v * moveSpeed * Time.deltaTime, Space.World);
        if (v < 0)
        {

        }
        else if (v > 0)
        {

        }



    }

    //射击
    void Fire()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {

            //填充 发射子弹
            //对象池
            //if (BulletPool.instance.availableObjects.Count == 0)
            //{
            //    BulletPool.instance.FillPool();
            //}
            //for (int i = 0; i < 5; i++)
            //{
            //    if(i==0)
            //    {
            //        Invoke("InvokeBullet", 0);
            //    }
            //    else
            //    {
            //        Invoke("InvokeBullet", 0.1f*i);
            //    }
            //}

            fireTimeValue = 0;
            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    Invoke("InvokeBullet", 0);
                }

                else
                {
                    Invoke("InvokeBullet", 0.1f * i);
                }

            }

        }
    }
    void InvokeBullet()
    {
        //GameObject bullet = BulletPool.instance.GetFromPool();
        //bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(bulletSpeed, 0, 0);

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(bulletSpeed, 0, 0);
    }



}
