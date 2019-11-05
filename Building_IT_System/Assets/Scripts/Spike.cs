using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField]
    float damage;
    [SerializeField]
    float interval = 4;
    [SerializeField]
    float movingTime;
    [SerializeField]
    float movingSpeed = 2;

    [SerializeField]
    Transform pointA;
    [SerializeField]
    Transform pointB;

    [SerializeField]
    bool upordown; //up is true, down is false
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if(pointA && pointB)
        {
            if(upordown)
            {
                transform.position = Vector3.Lerp(transform.position, pointA.position, movingSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, pointB.position, movingSpeed * Time.deltaTime);
            }
        }
        movingTime += Time.deltaTime;
        if(movingTime > interval)
        {
            if (upordown)
            {
                upordown = false;
            }
            else
            {
                upordown = true;
            }
            movingTime = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>())
        {
            Player player = other.GetComponent<Player>();
            player.applyDamge(damage, Tank.Team.enemy);
        }
        if (other.GetComponent<Enemy>())
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.applyDamge(damage, Tank.Team.player);
        }
    }
}
