using SocketIO;
using UnityEngine;

public class NetworkClient : SocketIOComponent
{
    // __________________________________________________________________________________________________________/ Start
    public override void Start()
    {
        base.Start();
        
        SetupEvents();
    }
    
    // __________________________________________________________________________________________________/ Set up Events
    private void SetupEvents()
    {
        On("open", (data) =>
        {
            print("connection made ^^");
        });
    }

    public bool fuck = false;
    void Update()
    {
        if (fuck)
        {
            fuck = false;
            SendUpdate("zoo");
        }
    }
    
    // ____________________________________________________________________________________________________/ Update Area 
    public void SendUpdate(string area)
    {
        Emit("areaUpdate", new JSONObject(JsonUtility.ToJson(new JsonArea(area))));
    }

}

public class JsonArea
{
    public string area;
    public JsonArea(string area)
    {
        this.area = area;
    }
}
