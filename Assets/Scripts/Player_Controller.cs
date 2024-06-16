using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    Animator anim;
    [SerializeField]
    float force;
    [SerializeField]
    bool isGrounded;
    [SerializeField]
    int addition;
    [SerializeField]
    GameObject canvas;

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    private void Start()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = canvas.GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = canvas.GetComponent<EventSystem>();

        Debug.Log(Game_Info.isAlive);
        anim = GetComponent<Animator>();
        isGrounded = true;
        StartCoroutine(score(addition));
    }
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButton(0))  && isGrounded)
        {
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                if (result.gameObject.tag == "Button")
                    return;
            }

            Debug.Log(isGrounded);
            isGrounded = false;
            anim.SetTrigger("Jump");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force), ForceMode2D.Impulse);

        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            
        }
    }

    IEnumerator score(int addition)
    {
     while(Game_Info.isAlive)
     {
        yield return new WaitForSeconds(0.5f);
        Game_Info.score = Game_Info.score + addition;
     }

    }
}
