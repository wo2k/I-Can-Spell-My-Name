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
        target = FindObjectOfType<EnemyBoat>().gameObject;
        targetPos = target.transform.localPosition;


    }

    void setTrajectoryPoints(Vector3 pStartPosition, Vector3 pVelocity)
    {
        float velocity = Mathf.Sqrt((pVelocity.x * pVelocity.x) + (pVelocity.y * pVelocity.y));
        float angle = Mathf.Rad2Deg * (Mathf.Atan2(pVelocity.y, pVelocity.x));
        float fTime = 0;

        fTime += 0.1f;
        for (int i = 0; i < numOfTrajectoryPoints; i++)
        {
            float dx = velocity * fTime * Mathf.Cos(angle * Mathf.Deg2Rad);
            float dy = velocity * fTime * Mathf.Sin(angle * Mathf.Deg2Rad) - (Physics2D.gravity.magnitude * fTime * fTime / 2.0f);
            Vector3 pos = new Vector3(pStartPosition.x + dx, pStartPosition.y + dy, 2);
            trajectoryPoints[i].transform.localPosition = pos;
            //trajectoryPoints[i].renderer.enabled = true;
            trajectoryPoints[i].transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(pVelocity.y - (Physics.gravity.magnitude) * fTime, pVelocity.x) * Mathf.Rad2Deg);
            fTime += 0.1f;
        }
    }

    /*void Fire()
    {
       // float force = this.force;
        float barrelAngle = CalculateProjectileFiringSolution(force, 20, level1E.muzzlePos);
        float yRotation = GetYRotation() - 90;

        // print("Rot " + yRotation);

        // fire projectile
            if (!hasFired)
          {
        Vector3 fVector = new Vector3(force, 0, 0);

        Vector3 rVector = Quaternion.Euler(0, yRotation, barrelAngle) * fVector;

        projectile.AddRelativeForce(rVector, ForceMode2D.Impulse);

           hasFired = true;
           }
    }*/

    // rotate to face target
  /*  float GetYRotation()
    {
        Vector3 relativePos =
            transform.InverseTransformPoint(target.localPosition);

        float x = (relativePos.x);
        float z = (relativePos.z);

        float angle = Mathf.Atan2(x, z) * Mathf.Rad2Deg;

        return angle;
    }*/

    /*float CalculateProjectileFiringSolution(float vel, float alt, Transform muzzle)
    {
        Vector2 a = new Vector2(muzzle.localPosition.x, muzzle.localPosition.y);
        Vector2 b = new Vector2(target.localPosition.x, target.localPosition.y);
        float dis = Vector2.Distance(a, b);
        alt = -(muzzle.localPosition.y - target.localPosition.y);
        //print("Range " + dis);

        float g = Mathf.Abs(Physics.gravity.y);

        float dis2 = dis * dis;
        float vel2 = vel * vel;
        float vel4 = vel * vel * vel * vel;
        float num;
        float sqrt = vel4 - g * ((g * dis2) + (2 * alt * vel2));
        if (sqrt < 0)
        {
           print("No solution!");
            return (45);
        }
       // Direct Fire
        if (Vector3.Distance(muzzle.transform.localPosition, target.localPosition) > vel / 2)
           num = vel2 - Mathf.Sqrt(vel4 - g * ((g * dis2) + (2 * alt * vel2)));
        else
            num = vel2 + Mathf.Sqrt(vel4 - g * ((g * dis2) + (2 * alt * vel2)));

        float dom = g * dis;
        float angle = Mathf.Atan(num / dom);

        return angle * Mathf.Rad2Deg;
    }*/

    // Update is called once per frame
    void Update () {

         targetPos = target.transform.localPosition;
     //   Fire();
     //   if (target.activeInHierarchy)
     //   {
         //   Vector3 vel = GetForceFrom(level1E.muzzlePos.localPosition, targetPos);
         //   float angle = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;
          //  transform.eulerAngles = new Vector3(0, 0, angle);
         //   setTrajectoryPoints(level1E.muzzlePos.localPosition, vel / physics.mass);
            FireCannonAtPoint(targetPos);

       // }
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1,0,0,1);
        Gizmos.DrawLine(level1E.muzzlePos.position, targetPos);
    }


    private Vector2 GetForceFrom(Vector3 fromPos, Vector3 toPos)
    {
        return (new Vector2(toPos.x, toPos.y) - new Vector2(fromPos.x, fromPos.y)) * 25;
    }

    private void FireCannonAtPoint(Vector3 point)
    {
        var velocity = BallisticVelocity(point, angle);
     //   Debug.Log("Firing at " + point + " velocity " + velocity);

        physics.transform.localPosition = transform.position;
        physics.velocity = velocity;
    }

    private Vector3 BallisticVelocity(Vector3 destination, float angle)
    {
        Vector3 dir = destination - transform.position; // get Target Direction
        float height = dir.y; // get height difference
        dir.y = 0; // retain only the horizontal difference
        float dist = dir.magnitude; // get horizontal direction
        float a = angle * Mathf.Deg2Rad; // Convert angle to radians
        dir.y = dist * Mathf.Tan(a); // set dir to the elevation angle.
        dist += height / Mathf.Tan(a); // Correction for small height differences

        // Calculate the velocity magnitude
        float velocity = Mathf.Sqrt(dist * Physics2D.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * dir.normalized; // Return a normalized vector.
    }
}
