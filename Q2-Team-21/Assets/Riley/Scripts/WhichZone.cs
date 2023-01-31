using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhichZone : MonoBehaviour
{
    private GameObject player;
    public bool IsInSpikeZone;
    public GameObject SpikeTheme;
    public bool IsInCoralArea;
    public GameObject CoralTheme;
    public bool InMainArea;
    public GameObject MainTheme;
    public GameObject CoralZoneMarker;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerBoat");
        IsInSpikeZone = false;
        IsInCoralArea = false;
        InMainArea = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > 100 && player.transform.position.z > -180) IsInSpikeZone = true;
        if(player.transform.position.x <= 100 || player.transform.position.z <= -180) IsInSpikeZone = false;

        if (Vector3.Distance(player.transform.position, CoralZoneMarker.transform.position) < 300) IsInCoralArea = true;
        else IsInCoralArea = false;

        if (IsInSpikeZone == false && IsInCoralArea == false) InMainArea = true;
        else if (IsInSpikeZone == true || IsInCoralArea == true) InMainArea = false;

        CoralTheme.SetActive(IsInCoralArea);
        MainTheme.SetActive(InMainArea);
        SpikeTheme.SetActive(IsInSpikeZone);




    }
}
