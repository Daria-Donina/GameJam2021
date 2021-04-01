using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector3 direction;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.enabled = false;

        KeyPressHandler();
    }

    private void KeyPressHandler()
	{
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GoLeft();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            GoUp();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            GoDown();
        }

        if (Input.GetKey(KeyCode.RightArrow))
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
        direction = new Vector3(0.0f, 1.0f, 0.0f);
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
        direction = new Vector3(0.0f, -1.0f, 0.0f);
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
        direction = new Vector3(-1.0f, 0.0f, 0.0f);
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
        direction = new Vector3(1.0f, 0.0f, 0.0f);
        transform.position += direction * speed * Time.deltaTime;

        //�������� ��������.
        animator.enabled = true;
    }
}


