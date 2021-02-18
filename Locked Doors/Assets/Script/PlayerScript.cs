using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{


    private Rigidbody2D rb;
    private Animator animator;
    private int skor = 0;
    public Text toplamSkor;
    [SerializeField] private GameObject anahtaVar;

    [SerializeField] private float hiz;
    [SerializeField]private bool sagaBak;

    [SerializeField]private bool atak;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sagaBak = true;
    }

    private void FixedUpdate()
    {
        float yatay = Input.GetAxisRaw("Horizontal");
        KarakterHaraket(yatay);
        YonCevir(yatay);
        AtakHareketleri();
        DegeriResetle();
    }

    void Update()
    {
        Kontroller();
    }

    private void KarakterHaraket(float yatay)
    {
        if (!this.animator.GetCurrentAnimatorStateInfo(0).IsTag("atak"))
        {
            rb.velocity = new Vector2(yatay * hiz, rb.velocity.y);
            
        }
        animator.SetFloat("karakterHizi", Mathf.Abs(yatay));
    }
    private void Kontroller()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            atak = true;
        }
    }

    private void AtakHareketleri()
    {
      
            if (atak && !this.animator.GetCurrentAnimatorStateInfo(0).IsTag("atak"))
            {
                animator.SetTrigger("atak");
                rb.velocity = Vector2.zero;
            }

        
    }

   
    private void YonCevir(float yatay)
    {
        if (yatay > 0 && !sagaBak || yatay < 0 && sagaBak)
        {
            sagaBak = !sagaBak;
            Vector3 yon = transform.localScale;
            yon.x *= -1;
            transform.localScale = yon;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag=="altin")
        {
            other.gameObject.SetActive(false);
            skor = skor + 100;
            SkorAyarla();
        }
        if (other.gameObject.tag == "anahtar") 
        {
            other.gameObject.SetActive(false);
            anahtaVar.SetActive(true);
        }
    }


    private void SkorAyarla()
    {
        toplamSkor.text = "SKOR:"+skor;
    }
    private void DegeriResetle()
    {
        atak = false;
    }

}
