using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector3 direction;

    private Animator animator;

    private RotatorToCursor rotator;

    private Renderer renderer;

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
        renderer = GetComponent<Renderer>();
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
    /// Обработка нажатия клавиш.
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
    /// Метод, задающий направление движения персонажа вверх.
    /// </summary>
    void GoUp()
    {
        //Меняем направление.
        direction = up;
        transform.position += direction * speed * Time.deltaTime;

        //Включаем анимацию.
        animator.enabled = true;
    }

    /// <summary>
    /// Задает направление движения персонажа вниз.
    /// </summary>
    void GoDown()
    {
        //Меняем направление.
        direction = down;
        transform.position += direction * speed * Time.deltaTime;

        //Включаем анимацию.
        animator.enabled = true;
    }

    /// <summary>
    /// Задает направление движения персонажа влево.
    /// </summary>
    void GoLeft()
    {
        //Меняем направление.
        direction = left;
        transform.position += direction * speed * Time.deltaTime;


        //Включаем анимацию.
        animator.enabled = true;
    }

    /// <summary>
    /// Задает направление движения персонажа вправо.
    /// </summary>
    void GoRight()
    {
        //Меняем направление.
        direction = right;
        transform.position += direction * speed * Time.deltaTime;


        //Включаем анимацию.
        animator.enabled = true;
    }

	public void Disable()
	{
        renderer.enabled = false;
        movingAllowed = false;
    }

	public void Enable()
	{
        renderer.enabled = true;
        movingAllowed = true;
	}
}


