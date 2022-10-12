using UnityEngine;

public class CameraController : MonoBehaviour
{
  [SerializeField] private float speed;
  private float currentPosX;
  private Vector3 velocity = Vector3.zero;


  private void Awake()
  {

    anim = GetComponent<Animator>();
    boxCollider = GetComponent<BoxCollider2D>();
  }

  private void Update()
  {
    transform.position = Vector3.SmoothDamp();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    hit = true;
    boxCollider.enabled = false;
    anim.SetTrigger("explode");
  }

  public void SetDirection(float _direction)
  {
    lifetime = 0;
    direction = _direction;
    gameObject.SetActive(true);
    hit = false;
    boxCollider.enabled = true;

    float localScaleX = transform.localScale.x;
    if (Mathf.Sign(localScaleX) != _direction)
      localScaleX = -localScaleX;
    transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
  }

  private void Deactivate()
  {
    gameObject.SetActive(false);
  }
}
