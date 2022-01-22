using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControler : MonoBehaviour
{
    public Rigidbody2D rb;
    private Collider2D coll;
    public Animator anim;

    float moveX, moveY;
    //public float XSpeed, YSpeed;
    public float moveSpeed;
    Vector3 moveFace;
    public Transform left, right, up, down;
    public Transform leftGun, rightGun;
    bool inPlatform = true;
    [SerializeField] bool inAttacking = false, inShooting = false;
    public float attaackTime, attackTimer, shootTimer, shootTimerSet = 2f;
    public float bulletSeconds = 0.05f;
    public GameObject bullet;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        moveX = Random.Range(-250, 250);
        moveY = Random.Range(-250, 250);
        while (moveX == 0 || Mathf.Abs(moveX) * 2 > Mathf.Abs(moveY) || Mathf.Abs(moveX) * 6 < Mathf.Abs(moveY))
        {
            moveX = Random.Range(-250, 250);
            moveY = Random.Range(-250, 250);
        }
        inPlatform = true;
        inAttacking = false;
        inShooting = false;
        moveSpeed = 0.8f;
        shootTimerSet = (float)(Random.Range(2.5f, 5.0f));
        bulletSeconds = 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        attackCircle();
    }

    public void move()
    {

        rb.velocity = (new Vector3(moveX, moveY, 0).normalized) * moveSpeed;
        if (inPlatform)
        {
            if (transform.position.x < left.position.x || transform.position.x > right.position.x)
            {
                moveX *= -1;
                inPlatform = false;
            }
            else if (transform.position.y < down.position.y || transform.position.y > up.position.y)
            {
                moveY *= -1;
                inPlatform = false;
            }
        }
        if (transform.position.x >= left.position.x && transform.position.x <= right.position.x && transform.position.y >= down.position.y && transform.position.y <= up.position.y)
        {
            inPlatform = true;
        }

    }

    public void attackCircle()                                                  //攻击循环
    {
        if (!inShooting)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootTimerSet)
            {
                shootTimer = 0;
                shootTimerSet = (float)(Random.Range(2.5f, 5.0f));
                inShooting = true;
                StartCoroutine(Shooting());
            }
        }
    }

    IEnumerator Shooting()
    {
        int bossBullet = 5;
        for (; bossBullet > 0; bossBullet--)
        {
            Instantiate(bullet, rightGun);
            Instantiate(bullet, leftGun);
            //Debug.Log("创建子弹成功");
            if (bossBullet == 5)
            {
                moveX = Random.Range(-250, 250);
                moveY = Random.Range(-250, 250);
                while (moveX == 0 || Mathf.Abs(moveX) * 2 > Mathf.Abs(moveY) || Mathf.Abs(moveX) * 6 < Mathf.Abs(moveY))
                {
                    moveX = Random.Range(-250, 250);
                    moveY = Random.Range(-250, 250);
                }
            }
            yield return new WaitForSeconds(bulletSeconds);
        }
        inShooting = false;
    }
}
