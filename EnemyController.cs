using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject firingPosition;
    public float bulletSpeed=2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Naruto());
    }

    // Update is called once per frame
    void Update()
    {
        OffScreen();
    }

    private void Move(){
        transform.position+=new Vector3(0, -bulletSpeed, 0)*Time.deltaTime;
    }

    private void OffScreen(){
        if(this.transform.position.y>8f || this.transform.position.y<-9f){
            Destroy(this.gameObject);
        }
    }

    public float GetAim()
    {
        GameObject target = GameObject.Find("Player");
        float dx = target.transform.position.x - transform.position.x;
        float dy = target.transform.position.y - transform.position.y;
        return Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
    }


    private IEnumerator Circle() {
            int count = 0;
            while (true)
            {
                for (int rad = 0; rad < 360; rad += 24)
                {
                    GameObject bullet=Instantiate(
                        bulletPrefab,
                        firingPosition.transform.position,
                        transform.rotation
                    );  
                    EnemyBullet bulletController=bullet.GetComponent<EnemyBullet>();
                    bulletController.Setting(rad, 8);

                }
                yield return new WaitForSeconds(1.0f);
                count++;
            }
    }


    IEnumerator Spider()
    {
        float baseDirection = GetAim();
        int count = 0;
        while (true)
        {
            float dir = baseDirection + Mathf.Sin(count * Mathf.Deg2Rad) * 30.0f;

            for (int index = -3; index < 3; index++)
            {
                GameObject bullet=Instantiate(
                    bulletPrefab,
                    firingPosition.transform.position,
                    transform.rotation
                );  
                EnemyBullet bulletController=bullet.GetComponent<EnemyBullet>();
                bulletController.Setting(dir + index * 30 + 15, 3);
            }
            yield return new WaitForSeconds(0.05f);
            count++;
        }
    }


    IEnumerator Tracking()
    {
        while (true)
        {
            float rad = GetAim();
            for (int index = 0; index < 10; index++)
            {
                GameObject bullet=Instantiate(
                    bulletPrefab,
                    firingPosition.transform.position,
                    transform.rotation
                );  
                EnemyBullet bulletController=bullet.GetComponent<EnemyBullet>();
                bulletController.Setting(rad, 5);
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator Naruto()
    {
        int rad = 0;
        while (true)
        {
            GameObject bullet=Instantiate(
                bulletPrefab,
                firingPosition.transform.position,
                transform.rotation
            );  
            EnemyBullet bulletController=bullet.GetComponent<EnemyBullet>();
            bulletController.Setting(rad, 5);
            rad += 20;
            yield return new WaitForSeconds(0.05f);
        }
    }



}
