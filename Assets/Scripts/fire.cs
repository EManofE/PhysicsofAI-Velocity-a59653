using UnityEngine;

public class fire : MonoBehaviour
{

    public GameObject bullet;
    public GameObject turret;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Shoot()
    {
        Instantiate(bullet, turret.transform.position, turret.transform.rotation);
    }

    void CalculateTrajectory()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CalculateTrajectory();
            Shoot();
        }
    }
}
