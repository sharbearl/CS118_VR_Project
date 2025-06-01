using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using static Unity.VisualScripting.Member;

public class LightSwitchUI : MonoBehaviour
{
    public XROrigin player;
    public GameObject lightSwitch;
    public Canvas interactUI;

    private XRGazeInteractor gaze;
    private BoxCollider lightCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gaze = player.GetComponent<XRGazeInteractor>();
        lightCollider = lightSwitch.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
