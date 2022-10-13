using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
  [SerializeField] private Transform previousRoom;
  [SerializeField] private Transform nextRoom;
  [SerializeField] private CameraController cam;
  [SerializeField] private int nextLevel = 0;

  private void Awake()
  {
    cam = Camera.main.GetComponent<CameraController>();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.tag == "Player")
    {
      if (collision.transform.position.x < transform.position.x)
      {
        if (nextLevel > 0)
        {
          SceneManager.LoadScene(PlayerPrefs.GetInt("level", nextLevel));
        }
        else
        {
          cam.MoveToNewRoom(nextRoom);
          nextRoom.GetComponent<Room>().ActivateRoom(true);
          previousRoom.GetComponent<Room>().ActivateRoom(false);
        }
      }
      else
      {
        cam.MoveToNewRoom(previousRoom);
        previousRoom.GetComponent<Room>().ActivateRoom(true);
        nextRoom.GetComponent<Room>().ActivateRoom(false);
      }
    }
  }
}