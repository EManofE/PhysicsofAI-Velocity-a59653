using UnityEngine;

public class movebullet : MonoBehaviour
{
    public float speed = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0,0,Time.deltaTime * speed);
    }
}
