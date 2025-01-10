using UnityEngine;
using UnityEngine.UI;

public class PlayerController : AEntity, ICollectable
{
    Rigidbody2D rigidbody;
    public Text coinCollectorText;
    public static int coinCollector = 0;
    private Weapon equipedWeapon;
    private Inventory backpack;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rigidbody.velocity = new Vector3(horizontal * speed, vertical * speed, 0);
        coinCollectorText.text = coinCollector.ToString();
    }
    public void Collect() { }
    public void Buy() { }

}
