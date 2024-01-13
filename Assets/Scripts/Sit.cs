using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sit : MonoBehaviour
{
    public Text sit_text;
    public Button button_sit;
    [SerializeField] private Transform player_tr;
    private Transform Couch_tr;
    private Transform sit_tr;
    private PlayerControl playerControl_script;
    // Start is called before the first frame update
    void Start()
    {
        player_tr = GameObject.Find("Player").GetComponent<Transform>();
        playerControl_script = GameObject.Find("Player").GetComponent<PlayerControl>();
        Couch_tr = GameObject.Find("Furtitare_couch").GetComponent<Transform>();
        sit_tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerControl_script.enabled = false;
            player_tr.rotation = Quaternion.Euler(0, 0, -Couch_tr.eulerAngles.z);
            player_tr.position = new Vector2(sit_tr.position.x, sit_tr.position.y);
            

            //Instantiate(sit_text, transform.position, Quaternion.identity);
            //Instantiate(button_sit, transform.position, Quaternion.identity);
        }
        
       
    }
    public void sit_act()
    {
        player_tr.position = new Vector2(0, 0);
    }
}
