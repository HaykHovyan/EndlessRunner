using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    float speed;
    float length;
    
    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

     void FixedUpdate()
    {
        transform.Translate(new Vector3(-speed, 0, 0)*(float)Game_Info.gameSpeed);
        if (transform.position.x < -length)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            transform.Translate(new Vector3(3 * length, 0, 0));
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
