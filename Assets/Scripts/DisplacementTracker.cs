using UnityEngine;
using TMPro;

public class DisplacementTracker : MonoBehaviour
{
  private float startX;
  private float timeElapsed;
  private Displacement displacement1;

  [SerializeField] private TextMeshProUGUI displacementText;

  void Start()
  {
    startX = transform.position.x;
    displacement1 = GetComponent<Displacement>();
  }


  void Update()
  {
    timeElapsed += Time.deltaTime;
    float displacement = transform.position.x - startX;
    displacementText.text = $"Displacement: {displacement:F2} m\nTime Elapsed: {timeElapsed:F2} s";

  }
}
