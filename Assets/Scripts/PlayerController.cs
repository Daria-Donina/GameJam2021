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
    /// Метод, задающий направление движения персонажа вверх.
    /// </summary>
    void GoUp()
    {
        //Меняем направление.
        direction = new Vector3(0.0f, 1.0f, 0.0f);
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
        direction = new Vector3(0.0f, -1.0f, 0.0f);
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
        direction = new Vector3(-1.0f, 0.0f, 0.0f);
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
        direction = new Vector3(1.0f, 0.0f, 0.0f);
        transform.position += direction * speed * Time.deltaTime;

        //Включаем анимацию.
        animator.enabled = true;
    }
}


