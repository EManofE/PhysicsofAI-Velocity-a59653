using UnityEngine;

public class fire : MonoBehaviour
{

    public GameObject bullet;
    public GameObject turret;
    public GameObject enemy;
    float rotspeed = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Shoot()
    {
        Instantiate(bullet, turret.transform.position, turret.transform.rotation);
    }

    

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (enemy.transform.position - this.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0,direction.z));
        this.transform.rotation=Quaternion.Slerp(this.transform.rotation, lookRotation, Time.deltaTime * rotspeed);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
}
