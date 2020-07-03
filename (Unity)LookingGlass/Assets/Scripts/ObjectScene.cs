using UnityEngine;
using UnityEngine.Events;

public class ObjectScene : MonoBehaviour
{
    [SerializeField] private Color32 color;
    [SerializeField] private GameObject floor;
    [SerializeField] private Transform wantedObjectPos;
    [SerializeField] private float closeEnoughDistance = 0.125f;
    [SerializeField] private string areaName;
    [SerializeField] private NetworkClient networkClient;
    private bool _onit = false;
    private bool grabbed = false;
    private Rigidbody _rigidbody;
    [SerializeField] private float maxWaitTime;
    private float currentTime = 0f;
    private bool allowed = true;
    public UnityEvent _sceneActive;
    public UnityEvent _sceneDeactive;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (currentTime < maxWaitTime) currentTime += Time.deltaTime;
        else allowed = true;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = wantedObjectPos.position;
            transform.rotation = wantedObjectPos.rotation;
        }
        
        if (!_onit) return;
        if (grabbed)
        {
            floor.GetComponent<MeshRenderer>().material.color = Color.white;
            _rigidbody.constraints = RigidbodyConstraints.None;
            _sceneDeactive.Invoke();
            _onit = false;
        }
    }

    public void SetWorld()
    {
        if (CloseEnough())
        {
            grabbed = false;
            floor.GetComponent<MeshRenderer>().material.color = color;
            _sceneActive.Invoke();
            _onit = true;
            networkClient.SendUpdate(areaName);
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            allowed = false;
            currentTime = 0;
        }
    }

    private bool CloseEnough()
    {
        float distance = Vector3.Distance(this.transform.position, wantedObjectPos.position);
        
        if (distance < closeEnoughDistance)
        {
            transform.position = wantedObjectPos.position;
            transform.rotation = wantedObjectPos.rotation;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("HandZone")) return;
        if (other.name.Contains("Contact") && allowed)
        {
            grabbed = true;
            _rigidbody.constraints = RigidbodyConstraints.None;
        }
    }
}
