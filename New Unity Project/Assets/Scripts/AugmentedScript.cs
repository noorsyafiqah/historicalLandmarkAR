using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AugmentedScript : MonoBehaviour
{
  public float originalLatitude;
  public float originalLongitude;
  private float currentLongitude;
  private float currentLatitude;

  public string textTag;

  private GameObject distanceTextObject;
  private double distance;

  private bool setOriginalValues = true;

  private Vector3 targetPosition;
  private Vector3 originalPosition;

  private float speed = .1f;

  
  public void Calc(float lat1, float lon1, float lat2, float lon2)
  {

    var R = 6378.137; // Radius of earth
    var dLat = lat2 * Mathf.PI / 180 - lat1 * Mathf.PI / 180;
    var dLon = lon2 * Mathf.PI / 180 - lon1 * Mathf.PI / 180;
    float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
      Mathf.Cos(lat1 * Mathf.PI / 180) * Mathf.Cos(lat2 * Mathf.PI / 180) *
      Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);
    var c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
    distance = R * c;
    distance = distance * 1000f; // meters
    distanceTextObject.GetComponent<Text>().text = "Distance: " + distance;
    float distanceFloat = (float)distance;
    targetPosition = originalPosition - new Vector3 (0, 0, distanceFloat * 12);
  }

  void Start(){
    //get distance text reference
    distanceTextObject = GameObject.FindGameObjectWithTag (textTag);
    //initialize target and original position
    targetPosition = transform.position;
    originalPosition = transform.position;

  }

  void Update(){

    currentLatitude = GPSManager.instance.myCurrentLatitude;
    currentLongitude = GPSManager.instance.myCurrentLongitude;
    Calc(originalLatitude, originalLongitude, currentLatitude, currentLongitude);

    //linearly interpolate from current position to target position
    transform.position = Vector3.Lerp(transform.position, targetPosition, speed);
    //rotate by 1 degree about the y axis every frame
    transform.eulerAngles += new Vector3(0, 1f, 0);

  }
}
