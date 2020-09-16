using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    Animator anim;
    public float damageLeft;
    public float maxSpeed;
    public float acc;
    public float speed;
    bool attack = false;
    public GameObject[] monster;
    float time = 0;
    public float additionalDist = 0;
    public TextMeshProUGUI text;
    List<Monster> allMonster;
    
    public GameObject ground;
    public GameObject currGround;
    // Start is called before the first frame update
    void Start()
    {
        allMonster = new List<Monster>();
        anim = GetComponent<Animator>();
    }
    public void SetTotalDamage(float d)
    {
        damageLeft = d;
    }
    // Update is called once per frame
    void Update()
    {

        Camera.main.orthographicSize = 5 * (1+time/5);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack = true;
        }
        if (damageLeft <= 0)
        {
            damageLeft = 0;
            attack = false;
            //destroy the rest of monsters
            foreach(Monster m in allMonster)
            {
                if(m!=null)
                    m.GotPunched();
            }
        }
        if (attack)
        {

            time += Time.deltaTime;
            speed += acc*Time.deltaTime;
            speed = Mathf.Min(maxSpeed, speed);

            
        }
        else
        {
            speed -= acc * Time.deltaTime;
            speed = Mathf.Max(0, speed);
        }

        anim.SetFloat("Speed", speed / maxSpeed);
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        text.text = "Power Left: " + (int)damageLeft;
        //init ground
        while (currGround.transform.position.x - transform.position.x < (8f+ additionalDist))
        {
            GameObject newGround = Instantiate(ground);
            newGround.transform.position = new Vector3(currGround.transform.position.x + 25, currGround.transform.position.y, 0);
            

            int num = Random.Range(5, 8);
            for(int i = 0; i < num; i++)
            {
                var m = Instantiate(monster[Random.Range(0, monster.Length)]);
                m.transform.position = new Vector3(currGround.transform.position.x - 8f + Random.Range(18f, 44f), -2f, 0);
                float size = Random.Range(0.8f, 1.2f) * (1 + time / 3);
                m.transform.localScale = new Vector3(1, 1, 1) * size;
                m.GetComponentInChildren<Monster>().health = size;
                allMonster.Add(m.GetComponentInChildren<Monster>());
            }
            currGround = newGround;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            damageLeft -= collision.gameObject.GetComponent<Monster>().GotPunched();
        }
    }
}
