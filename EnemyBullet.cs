using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float dx;
    float dy;
    public void Setting(float angle, float speed)
    {
        float rad = angle * Mathf.Deg2Rad;
        dx = Mathf.Cos(rad) ;
        dy = Mathf.Sin(rad) ;
    }
 
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(dx, dy, 0) * 4 * Time.deltaTime;
        OffScreen();
    }



    private void OffScreen(){
        if(this.transform.position.y>8f || this.transform.position.y<-9f){
            Destroy(this.gameObject);
        }else if(this.transform.position.x>11f || this.transform.position.x < -11f){
                        Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){

        if(!collision.gameObject.CompareTag("Enemy")){
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
    
}
