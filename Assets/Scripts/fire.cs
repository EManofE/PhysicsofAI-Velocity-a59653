using UnityEngine;

public class fire : MonoBehaviour
{

    public GameObject bullet;
    public GameObject turret;
    public GameObject enemy;
    public Transform turretbase;
    float rotspeed = 2;
    float speed = 15;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Shoot()
    {
        Instantiate(bullet, turret.transform.position, turret.transform.rotation);
    }

    void RotateTurret()
    {
        float? angle = CalculateAngle(true);
        if (angle != null)
        {
            turretbase.localEulerAngles = new Vector3(360f - (float)angle, 0f, 0f);
        }
    }

    float? CalculateAngle(bool low)
    {
        Vector3 targetDir = enemy.transform.position - this.transform.position;
        float y = targetDir.y;
        targetDir.y = 0f;
        float x = targetDir.magnitude;
        float gravity = 9.8f;
        float sSqr = speed * speed;
        float underTheSqrRoot = (sSqr * sSqr) - gravity * (gravity * x * x + 2 * y * sSqr);

        if(underTheSqrRoot >= 0f)
        {
            float root = Mathf.Sqrt(underTheSqrRoot);
            float highAngle = sSqr + root;
            float lowAngle = sSqr - root;

            if(low)
                return (Mathf.Atan2(lowAngle, gravity * x) * Mathf.Rad2Deg);
            else
                return (Mathf.Atan2(highAngle, gravity * x) * Mathf.Rad2Deg);
        }
        else 
            return null;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (enemy.transform.position - this.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0,direction.z));
        this.transform.rotation=Quaternion.Slerp(this.transform.rotation, lookRotation, Time.deltaTime * rotspeed);
        RotateTurret();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
}
