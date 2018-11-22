using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonBall : MonoBehaviour {

    public Rigidbody2D physics;
    [SerializeField]
    [Range(10f, 80f)]
    private float angle = 45f;

    public GameObject target;
    public Vector3 targetPos;
    public Level1E level1E;
    private int numOfTrajectoryPoints = 30;
    private List<GameObject> trajectoryPoints = new List<GameObject>();

   // public Transform target;
    public Rigidbody2D projectile;
    public float gravity = 9.81f;
    public float force = 100;
    bool hasFired = false;

    // Use this for initialization
    void Start () {

        level1E = FindObjectOfType<Level1E>();
        projectile = GetComponent<Rigidbody2D>();
        physics = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<EnemyBoat>().transform.GetChild(0).gameObject;
        targetPos = target.transform.position;


    }


    void FireAtWill()
    {
       physics.AddForce(GetForceFrom(transform.localPosition, targetPos, new Vector3(750, -300, 0)), ForceMode2D.Impulse);     
        hasFired = true;
    }

    void Update()
    {

        targetPos = target.transform.position;

        if (hasFired)
            return;

        if (!hasFired)
            FireAtWill();

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1,0,0,1);
        Gizmos.DrawLine(level1E.muzzlePos.position, targetPos);
    }


    private Vector2 GetForceFrom(Vector3 fromPos, Vector3 toPos, Vector3 speed)
    {
        return (new Vector2(toPos.x, toPos.y) - new Vector2(fromPos.x, fromPos.y) - new Vector2(speed.x, speed.y));
    }


}
