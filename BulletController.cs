using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed=15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        OffScreen();
    }

    private void Move(){
        transform.position+=new Vector3(0, bulletSpeed, 0)*Time.deltaTime;
    }

    private void OffScreen(){
        if(this.transform.position.y>8f || this.transform.position.y<-9f){
            Destroy(this.gameObject);
        }else if(this.transform.position.x>11f || this.transform.position.x < -11f){
                        Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(!collision.gameObject.CompareTag("Player")){
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
