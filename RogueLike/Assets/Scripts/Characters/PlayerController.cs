using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : AEntity, ICollectable, InputControllers.IPlayerActions
{
    Rigidbody2D rigidbody;
    Animator animator;
    private Vector2 direction;
    private InputControllers controls;
    public float idleTime = 3f;
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
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else if(direction.x < 0)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        if (direction.y > 0)
        {
            transform.localScale = new Vector2(transform.localScale.x, -Mathf.Abs(transform.localScale.y));
        }
        else if (direction.y < 0)
        {
            transform.localScale = new Vector2(transform.localScale.x, Mathf.Abs(transform.localScale.y));
        }
        IsAsleep();
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        //coinCollectorText.text = coinCollector.ToString();
    }

    void IsAsleep()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("IdleBlendTree"))
        {
            timer += Time.deltaTime;
            if(timer >= idleTime)
            {
                animator.SetTrigger("Asleep");
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
