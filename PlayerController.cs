using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed=8.0f;
    public GameObject bulletPrefab;
    public GameObject firingPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shot();

    }
    private void Move(){
        float x=Input.GetAxis("Horizontal")*moveSpeed;
        float y=Input.GetAxis("Vertical")*moveSpeed;
        transform.position+=new Vector3(x, y, 0)*Time.deltaTime;
    }

    private void Shot(){
        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(
                bulletPrefab,
                firingPosition.transform.position,
                transform.rotation
            );
        }
    }
}
