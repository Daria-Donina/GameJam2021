using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector3 direction;

    private Vector3 rotation;

    private Animator animator;

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
        rotation = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        animator.enabled = false;

        KeyPressHandler();

        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        rotation.z = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        transform.rotation = Quaternion.Euler(rotation);
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
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
    }


    /// <summary>
    /// �����, �������� ����������� �������� ��������� �����.
    /// </summary>
    void GoUp()
    {
        //������ �����������.
        direction = up;
        transform.position += direction * speed * Time.deltaTime;

        //�������� ��������.
        animator.enabled = true;
    }

    /// <summary>
    /// ������ ����������� �������� ��������� ����.
    /// </summary>
    void GoDown()
    {
        //������ �����������.
        direction = down;
        transform.position += direction * speed * Time.deltaTime;

        //�������� ��������.
        animator.enabled = true;
    }

    /// <summary>
    /// ������ ����������� �������� ��������� �����.
    /// </summary>
    void GoLeft()
    {
        //������ �����������.
        direction = left;
        transform.position += direction * speed * Time.deltaTime;


        //�������� ��������.
        animator.enabled = true;
    }

    /// <summary>
    /// ������ ����������� �������� ��������� ������.
    /// </summary>
    void GoRight()
    {
        //������ �����������.
        direction = right;
        transform.position += direction * speed * Time.deltaTime;


        //�������� ��������.
        animator.enabled = true;
    }
}


