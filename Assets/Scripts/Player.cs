using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float jumpScale;
    public bool isGrounded = false;
    public int SpareMoney = 0;
    public float airTime = 0;
    public float timer = 0;
    public int airLevel = 0;
    public GameObject weapon;
    public GameObject light_obj;
    public GameObject flashLight;
    public int baseSpeed = 7;
    public bool itemSpeed = false;
    public bool smallSpeed = false;
    public bool onWeapon = true;
    public bool isAttack = false;
    public bool isDie = false;
    public int Money;
    public int currentHp = 0;
    public int maxHp = 0;
    public int maxAir = 100;
    public float currentAir = 0;
    public Inventory inventory;
    Animator animator;
    public float speed = 5;
    public float rotateSpeed = 5;
    Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        currentAir = maxAir;
        currentHp = maxHp;
    }
    private void Start()
    {

        inventory = GameObject.Find("Canvas").GetComponent<Inventory>();
    }
    // Update is called once per frame
    void Update()
    {
        if(isDie) { return; }

        StartCoroutine(Attack());
        if(Input.GetKeyDown(KeyCode.Q) && onWeapon)
        {
            light_obj.SetActive(true);
            flashLight.SetActive(true);
            weapon.SetActive(false);
            onWeapon = false;
        }
        else if(Input.GetKeyDown(KeyCode.Q) && !onWeapon)
        {
            light_obj.SetActive(false );
            flashLight.SetActive(false);
            weapon.SetActive(true);
            onWeapon = true;
        }
        Jump();
        AirDown();

        if (itemSpeed || smallSpeed)
        {
            SpeedUp();
        }
    }


    public void SpeedUp()
    {
        timer += Time.deltaTime;
        if (smallSpeed)
        {
            if (timer >= 3)
            {
                smallSpeed = false;
                speed = baseSpeed;
            }

        }
    }

    public void Small_Speed()
    {
        timer = 0;
        smallSpeed = true;
    }

    public void Speed()
    {
        timer = 0;
        itemSpeed = true;
    }

    private void FixedUpdate()
    {
        if(isDie) { return; }   
        Move();
    }

    void Jump()
    {
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded = false;
            rigid.AddForce(Vector3.up * jumpScale, ForceMode.Impulse);
        }
    }
    
    void AirDown()
    {
        airTime += Time.deltaTime;
        if(airTime >= 1)
        {
            airTime = 0;
            currentAir -= airLevel;
        }
    }

    void Move()
    {
        float x_pos = Input.GetAxisRaw("Horizontal");
        float z_pos = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x_pos, 0,z_pos).normalized;

        rigid.velocity = new Vector3(dir.x * speed, rigid.velocity.y, dir.z * speed);

        if ( dir != Vector3.zero )
        {
            animator.SetBool("isWalk", true);
            Quaternion rot = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotateSpeed * Time.deltaTime);
            transform.rotation = rot;
        }
        else
        {
            animator.SetBool("isWalk",false);
        }

         




    }

    IEnumerator Attack()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetTrigger("isAttack");
            isAttack = true;
            yield return new WaitForSeconds(0.7f);
            isAttack = false;
        } 
    }

    public void SetHp(int damage)
    {
        if(isDie) { return; }
        currentHp -= damage;
        if(currentHp <= 0 && !isDie)
        {
            isDie = true;
            currentHp = 0;
            SpareMoney = 0;
            animator.SetTrigger("isDie");
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if(collision.gameObject.CompareTag("Trap"))
        {
            Debug.Log("ss");
            SetHp(currentHp);
        }

        if (collision.gameObject.CompareTag("Gate_In"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            airLevel += 1;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            inventory.SetItem(other.gameObject);
            SpareMoney += other.gameObject.GetComponent<Item>().Price;
            
        }


    }

    public void Hp()
    {
        if(currentHp + 5 > maxHp)
        {
            currentHp = maxHp;
        }
        else
        {
            currentHp += 5;
        }
    }

    public void Air()
    {
        if (currentAir + 5 > maxAir)
        {
            currentAir = maxAir;
        }
        else
        {
            currentAir += 5;
        }
    }

    public void ItemDirection()
    {

    }

    public void Invisible()
    {

    }
}
