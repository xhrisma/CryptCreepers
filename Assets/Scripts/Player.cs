using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float horizontal;
    float vertical;
    public float speed = 3;
    Vector3 moveDirection;
    [SerializeField] Transform mira;
    [SerializeField] Camera camera;
    Vector2 facingDirection;
    [SerializeField]Transform bulletPrefab;
    bool gunLoaded=true;
    [SerializeField]float fireRate = 1;

    [SerializeField] int health = 3;
    bool powerShotEnabled ;
    bool invulnerable;
    [SerializeField] float invulnerabilidadTime=3;
    [SerializeField]Animator anim;
    [SerializeField]SpriteRenderer spriteRenderer;

    [SerializeField]float blinkRate = 1;
    CameraController camController;
    [SerializeField]AudioClip impact;
    [SerializeField]AudioClip powr;
    public int Health
    {
        get => health;
        set{
            health = value;
            UIManager.Instance.UpdateUIHealtth(health);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        camController = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal=Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        moveDirection.x = horizontal;
        moveDirection.y = vertical;

        transform.position += moveDirection * Time.deltaTime*speed;

        //mov mira
        facingDirection = camera.ScreenToWorldPoint(Input.mousePosition)- transform.position;
        mira.position = transform.position + (Vector3)facingDirection.normalized;

        if (Input.GetMouseButton(0) && gunLoaded)
        {
            gunLoaded = false;
            float angle = Mathf.Atan2(facingDirection.y, facingDirection.x)*Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
           Transform bulletClone= Instantiate(bulletPrefab,transform.position, targetRotation);
            if (powerShotEnabled)
            {
                bulletClone.GetComponent<Bullet>().powerShot = true;
            }
            StartCoroutine(ReloadGun());
        }

        anim.SetFloat("speed", moveDirection.magnitude);
        if (mira.position.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
        }else if(mira.position.x < transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
    }
    IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1/fireRate);
        gunLoaded = true;
    }
    public void RestarVidaPlayer()
    {
        if (invulnerable)
            return;
        Health--;
        AudioSource.PlayClipAtPoint(impact, transform.position);
        invulnerable = true;
        camController.Shake();
        StartCoroutine(MakeInvulnerableAgain());
        if (Health<=0) {
            Destroy(gameObject,0.1f);
            GameManager.Instance.gameOver = true;
            UIManager.Instance.ShowGameOverScreen();
            
        }
    }
    IEnumerator MakeInvulnerableAgain()
    {
        StartCoroutine(BlinkRoutine());
        yield return new WaitForSeconds(invulnerabilidadTime);
        invulnerable = false;
    }
    IEnumerator BlinkRoutine()
    {
        int t = 10;
        while (t > 0){
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(t*blinkRate);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(t * blinkRate);
            t--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            switch (collision.GetComponent<PoweUp>().powerUpType)
            {
                case PoweUp.PowerUPType.FireRateIncrease:
                    fireRate++;
                    break;

                case PoweUp.PowerUPType.PowerShot:
                    powerShotEnabled = true;
                    break;
            }
            AudioSource.PlayClipAtPoint(powr, transform.position);
            Destroy(collision.gameObject, 0.1f);
        }
    }
}
