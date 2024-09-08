using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance;

    [Header("Controller")]
    [SerializeField] public float speed;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private FixedJoystick _joystick2;
    private Rigidbody2D rb;

    private bool m = false;

    [Header("Animator")]
    public Animator Walk;

    [Header("Music")]
    private AudioSource music;
    public  AudioClip Stap_Wood;

    [Header("CutScene")]
    public PlayableDirector directir;

    [Header("Buttons")]
    private GameObject Body;
    public GameObject Shoot_B;
    [Header("Sprite")]
    public Sprite ShootSp;
    public Sprite KnifeSp;
    public GameObject CatridgeText;

    [Header("Health")]
    public Text HealthText;
    public Volume VolumeHealth;
    public Transform TargetToRespawn;
    public int PlayerHealthInt = 100;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        music = GameObject.Find("Music").GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        
        if (directir.state != PlayState.Playing)
        {
            rb.velocity = new Vector2(_joystick.Horizontal * speed * Time.deltaTime, _joystick.Vertical * speed * Time.deltaTime);

            if (_joystick2.Horizontal != 0 & _joystick2.Vertical != 0)
            {
                Vector3 moveVector = -(Vector3.left * _joystick2.Horizontal - Vector3.up * _joystick2.Vertical);
                transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
            }
            if (_joystick.Horizontal != 0 & _joystick.Vertical != 0 && m == false)
            {
                if (!music.isPlaying)
                {
                    music.PlayOneShot(Stap_Wood);
                }
                Walk.SetBool("Stop", false);

            }
            else
            {
                Walk.SetBool("Stop", true);
                music.Stop();
            }
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            Walk.SetBool("Stop", true);
            music.Stop();
        }

        HealthText.text = PlayerHealthInt.ToString();
    }

    public void Change(GameObject bod)
    {
        Body = GameObject.FindGameObjectWithTag("Body");
        GameObject a =  Instantiate(bod, Body.transform.position, Body.transform.rotation);
        a.transform.SetParent(gameObject.transform);
        Destroy(Body);
    }

    public void onShoot()
    {
        
        if (QuickInventory.Instance.itemNow.weapt == Item.WeapT.Weapon)
        {
            CatridgeText.SetActive(true);
            Shoot_B.GetComponent<Image>().sprite = ShootSp;
        }
        else
        {
            CatridgeText.SetActive(false);
            Shoot_B.GetComponent<Image>().sprite = KnifeSp;
        }
        Shoot_B.SetActive(true);
    }
}
