using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour
{
    private Animator k;
    private Rigidbody m;
    private float p = 800.0f;

    private float r = 500.0f;
    private float s = 3.4f;

    private float t = 500.0f;
    private float u = .95f;
    private bool v = false;
    private GameObject w;
    private GameObject x;
    private int y = 0;

    private bool a = false;
    private bool b = false;


    private void Start()
    {



        this.k = GetComponent<Animator>();
        this.k.SetFloat("Speed", 1);
        this.m = GetComponent<Rigidbody>();
        this.w = GameObject.Find("GameResultText");
        this.x = GameObject.Find("ScoreText");


    }
    private void Update()
    {




        if (this.v)
        {
            this.p *= this.u;
            this.r *= this.u;
            this.t *= this.u;
            this.k.speed *= this.u;
        }

        this.m.AddForce(this.transform.forward * this.p);

        if ((Input.GetKey(KeyCode.LeftArrow)||this.a) && -this.s < this.transform.position.x)
        {
            this.m.AddForce(-this.r, 0, 0);
        }
        else if ((Input.GetKey(KeyCode.RightArrow)||this.b) && this.transform.position.x < this.s)
        {
            this.m.AddForce(this.r, 0, 0);
        }

        if (this.k.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.k.SetBool("Jump", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < .5f)
        {
            this.k.SetBool("Jump", true);
            this.m.AddForce(this.transform.up * this.r);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
        {
            this.v = true;
            this.w.GetComponent<Text>().text = "GAME OVER";
        }
        if (other.gameObject.tag == "GoalTag")
        {
            this.v = true;
            this.w.GetComponent<Text>().text = "CLEAR!!";
        }
        if (other.gameObject.tag == "CoinTag")
        {
            this.y += 10;
            this.x.GetComponent<Text>().text = "Score" + this.y + "pt";
            GetComponent<ParticleSystem>().Play();
            Destroy(other.gameObject);

        }

    }
    public void GetMyJumpButtonDown()
    {
        if (this.transform.position.y < .5f)
        {
            this.k.SetBool("Jump", true);
            this.m.AddForce(this.transform.up * this.t);
        }
    }
    public void GetMyLeftButtonDown()
    {
        this.a = true;
    }
    public void GetMyLeftButtonUp()
    {
        this.a = false;
    }
    public void GetMyRightButtonDown()
    {
        this.b = true;
    }
    public void GetMyRightButtonUp()
    {
        this.b = false;
    }

}