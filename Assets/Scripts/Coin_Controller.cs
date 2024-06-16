using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Controller : MonoBehaviour
{
    [SerializeField]
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-speed, 0, 0) *(float)Game_Info.gameSpeed);
        if (transform.position.x < Game_Info.coin_termination_Point)
        {
            this.gameObject.SetActive(false);
            transform.Translate(new Vector3(25, 0, 0));
            this.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Game_Info.score = Game_Info.score + 20;
            this.gameObject.SetActive(false);
            transform.Translate(new Vector3(25,0,0));
            this.gameObject.SetActive(true);
        }
    }
}
