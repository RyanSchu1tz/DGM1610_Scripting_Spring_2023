using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Enemy : MonoBehaviour
{

    // Enemy Stats
    public int curHp, maxHp, scoreToGive;
    //Movement
    public float moveSpeed, attackRange, yPathOffset;
    // Cordinates for a path
    private List<Vector3> path;

    // Enemy Weapon
    //private Weapon weapon;

    // Target to follow
    private GameObject target;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        //Get the Components
        //weapon = GetComponent<Weapon>();
        target = FindObjectOfType<PlayerController>().gameObject;

        player = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("UpdatePath", 0.0f, 0.5f);

        curHp = maxHp;
    }

    void Update()
    {
        //Look at the target
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.x,dir.z) * Mathf.Rad2Deg;
        transform.eulerAngles = Vector3.up * angle;

        // Calculate the distance between the enemy and the player
        float dist = Vector3.Distance(transform.position, target.transform.position);
        // If within attackrange shoot at Player
        if (dist <- attackRange)
        {
            player.TakeDamage(1);

            /*if(weapon.CanShoot())
                weapon.Shoot();*/
        }
        //if enemy is too fat away chase after Player
        else
        {
            ChaseTarget();
        }

    }

    void UpdatePath()
    {
        //Calculate a path to the Target
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);

        path = navMeshPath.corners.ToList();
    }

    void ChaseTarget()
    {
        if(path.Count == 0)
            return;

        //Move towards the closest path
        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0,yPathOffset, 0), moveSpeed * Time.deltaTime);

        if(transform.position == path[0] + new Vector3(0, yPathOffset, 0))
            path.RemoveAt(0);
    }

    public void TakeDamage(int damage)
    {
        curHp -= damage;

        if(curHp <= 0)
            Die();
    }

    void Die()
    {
        //GameManager.instance.AddScore(scoreToGive);
        Destroy(gameObject);
    }
}
