using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    public float health;
    bool punched = false;
    float force = 2000;
    public float GotPunched() {
        GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<Animator>().enabled = false;
        for(int i= transform.childCount-1; i>=0 ; i--)
        {
            Transform c = transform.GetChild(i);

            DetachBodyPart(c);
            for (int j = c.childCount-1; j >=0 ; j--)
            {
                DetachBodyPart(c.GetChild(j));
            }
        }
        punched = true;
        return health;
    }
    private void LateUpdate()
    {
        if (punched)
        {
            Destroy(gameObject);
        }
    }
    void DetachBodyPart(Transform c)
    {
        Rigidbody2D rb = c.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.simulated = true;
        }
        c.SetParent(null, true);
        Vector2 dir = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
        dir.Normalize();
        rb.AddForce(dir * force);
    }
}
