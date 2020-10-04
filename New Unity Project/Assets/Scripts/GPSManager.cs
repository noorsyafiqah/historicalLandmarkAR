using System.Collections;
using UnityEngine;

class GPSManager : MonoBehaviour
{
    private float currentLongitude;
    private float currentLatitude;

    public static GPSManager instance = null;

    IEnumerator GetCoordinates()
    {
        //while true so this function keeps running once started.
        while (true)
        {
            // check if user has location service enabled
            if (!Input.location.isEnabledByUser)
                yield break;

            // Start service before querying location
            Input.location.Start(1f, .1f);

            // Wait until service initializes
            int maxWait = 20;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSeconds(1);
                maxWait--;
            }

            // Service didn't initialize in 20 seconds
            if (maxWait < 1)
            {
                print("Timed out");
                yield break;
            }

            // Connection has failed
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                print("Unable to determine device location");
                yield break;
            }
            else
            {
                // Access granted and location value could be retrieved
                print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);

                // Overwrite current lat and longitude everytime
                currentLatitude = Input.location.lastData.latitude;
                currentLongitude = Input.location.lastData.longitude;

            }
            Input.location.Stop();
        }
    }

    public float myCurrentLatitude
    {
        get
        {
            return this.currentLatitude;
        }
    }

    public float myCurrentLongitude
    {
        get
        {
            return this.currentLongitude;
        }
    }

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //start GetCoordinate() function 
        StartCoroutine("GetCoordinates");
    }

    void Update()
    {
        
    }
}
