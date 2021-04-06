using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float MaxSpeed;
    float currentSpeed;
    float tUp;
    float tDown;
    float tLeft;
    float tRight;


    private Vector3 direction;

    private Animator animator;

    private RotatorToCursor rotator;

    private Renderer _renderer;

    private bool movingAllowed = true;

    #region direction constants
    private Vector3 left = Vector3.left;
    private Vector3 right = Vector3.right;
    private Vector3 up = Vector3.up;
    private Vector3 down = Vector3.down;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rotator = new RotatorToCursor(gameObject);
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.enabled = false;


        if (movingAllowed)
		{
            KeyPressHandler();

            rotator.Rotate(transform.position);
        }
    }

    /// <summary>
    /// ��������� ������� ������.
    /// </summary>
    private void KeyPressHandler()
	{
        if (Input.GetKey(KeyCode.A))
        {
            GoLeft();            
        }

        if (Input.GetKey(KeyCode.W))
        {
            
            GoUp();
        }

        if (Input.GetKey(KeyCode.S))
        {
            
            GoDown();
        }

        if (Input.GetKey(KeyCode.D))
        {
           
            GoRight();
        }
        if (!Input.GetKey(KeyCode.A))
        {
            tLeft = 0;
        }
        if (!Input.GetKey(KeyCode.W))
        {
            tUp = 0;
        }
        if (!Input.GetKey(KeyCode.S))
        {
            tDown = 0;
        }
        if (!Input.GetKey(KeyCode.D))
        {
            tRight = 0;
        }
    }


    /// <summary>
    /// �����, �������� ����������� �������� ��������� �����.
    /// </summary>
    void GoUp()
    {
        tUp = tUp + Time.deltaTime*2;
        Debug.Log(tUp);
        //������ �����������.
        direction = up;
        currentSpeed = Mathf.Lerp(2f, MaxSpeed, tUp);
        transform.position += direction * currentSpeed * Time.deltaTime;        
        
        //�������� ��������.
        animator.enabled = true;
    }

    /// <summary>
    /// ������ ����������� �������� ��������� ����.
    /// </summary>
    void GoDown()
    {
        tDown = tDown + Time.deltaTime*2;
        Debug.Log(tDown);
        //������ �����������.
        direction = down;
        currentSpeed = Mathf.Lerp(2f, MaxSpeed, tDown);
        transform.position += direction * currentSpeed * Time.deltaTime;
        

        //�������� ��������.
        animator.enabled = true;
    }

    /// <summary>
    /// ������ ����������� �������� ��������� �����.
    /// </summary>
    void GoLeft()
    {
        tLeft = tLeft + Time.deltaTime*2;
        Debug.Log(tLeft);
        //������ �����������.
        direction = left;
        currentSpeed = Mathf.Lerp(2f, MaxSpeed, tLeft);
        transform.position += direction * currentSpeed * Time.deltaTime;
        

        //�������� ��������.
        animator.enabled = true;
    }

    /// <summary>
    /// ������ ����������� �������� ��������� ������.
    /// </summary>
    void GoRight()
    {
        tRight = tRight + Time.deltaTime*2;
        Debug.Log(tRight);
        //������ �����������.
        direction = right;
        currentSpeed = Mathf.Lerp(2f, MaxSpeed, tRight);
        transform.position += direction * currentSpeed * Time.deltaTime;
        

        //�������� ��������.
        animator.enabled = true;
    }

	public void Disable()
	{
        _renderer.enabled = false;
        movingAllowed = false;
    }

	public void Enable()
	{
        _renderer.enabled = true;
        movingAllowed = true;
	}
}


