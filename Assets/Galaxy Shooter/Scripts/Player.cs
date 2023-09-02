using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
//Public or private identify
//Data type ( Int, float, bool, string)
//Every variable has a NAME
//Option value assigned

public float speed = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        //Reset Player Position
        transform.position = new Vector3(0,0,0);

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right  * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);


    }
}
