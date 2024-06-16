using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    float speed;

    void Update()
    {
        transform.Translate(new Vector3(-speed, 0, 0)*(float)Game_Info.gameSpeed);
        if (transform.position.x < Game_Info.termination_Point)
        {
            //Destroy(this.gameObject);
            //Game_Info.obs_Count-- ;
            gameObject.SetActive(false);
            transform.Translate(new Vector3(Game_Info.spawn_Distance, 0));
            gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Game_Info.isAlive = false;
            Game_Info.gameSpeed = 0;
            StartCoroutine(stopper());
            Game_Info.panel.SetActive(true);
            Game_Info.UI_Panel.SetActive(false);
            collision.gameObject.GetComponent<Animator>().SetBool("Dead", true);
        }
    }

    IEnumerator stopper()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0;
    }
}
