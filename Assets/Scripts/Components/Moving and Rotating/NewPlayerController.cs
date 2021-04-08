using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    public float speed;
    public Joystick joystick;
    Rigidbody2D rb;
    Vector2 move;
    float lastZAxis;
    Animator animator;

    bool isActive;
    SpriteRenderer[] renders;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isActive = true;
    }

    private void Update()
    {
        move.x = joystick.Horizontal;
        move.y = joystick.Vertical;

        if (isActive)
        {
            Rotating();
        }          
    }
    private void FixedUpdate()
    {
        if (isActive)
        {
            Moving();
        }        
    }

    public void Rotating()
    {
        float xAxis = joystick.Horizontal;
        float yAxis = joystick.Vertical;
        float zAxis = Mathf.Atan2(xAxis, yAxis) * Mathf.Rad2Deg;
        if (zAxis > 0 || zAxis < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, -zAxis);
            lastZAxis = -zAxis;
            animator.enabled = true;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, lastZAxis);
            animator.enabled = false;
        }        
    }

    public void Moving()
    {
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }

    public void Disable()
    {

        isActive = false;
        renders = GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < renders.Length; i++)
        {
            renders[i].enabled = false;
        }
    }

    public void Enable()
    {
        isActive = true;
        renders = GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < renders.Length; i++)
        {
            renders[i].enabled = true;
        }
    }
}
