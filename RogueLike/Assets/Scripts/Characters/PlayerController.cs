using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : AEntity, ICollectable, InputControllers.IPlayerActions
{
    Rigidbody2D rigidbody;
    Animator animator;
    private Vector2 direction;
    private InputControllers controls;
    public float idleTime = 0.3f;
    private float timer = 0;
    public Text coinCollectorText;
    public static int coinCollector = 0;
    private Weapon equipedWeapon;
    private Inventory backpack;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        controls = new InputControllers();
        controls.Enable();
    }

    void Update()
    {
        direction = controls.Player.Movement.ReadValue<Vector2>();
        animator.SetFloat("X", direction.x);
        animator.SetFloat("Y", direction.y);
        if(direction.x > 0)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else if(direction.x < 0)
        {
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        IsAsleep();
        IsWalking();
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        //coinCollectorText.text = coinCollector.ToString();
    }

    void IsWalking()
    {
        if (direction.x == 0 && direction.y == 0)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
        }
    }

    void IsAsleep()
    {
        Debug.Log(timer);
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Idle Blend Tree"))
        {
            timer += Time.deltaTime;
            if(timer >= idleTime)
            {
                animator.SetTrigger("isAsleep");
                timer = 0;
            }
        }
        else
        {
            timer = 0;
        }
    }

    public void Collect() { }
    public void Buy() { }

    public void OnMovement(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }
}
