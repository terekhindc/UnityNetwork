using UnityEngine;

public class NetworkManager :  MonoBehaviour{

    public static NetworkManager Instance;

    Token token;
    [HideInInspector] public Active active;
    [HideInInspector] public Relax relax;

    [HideInInspector]public TokenData tokenData = new TokenData();

    [HideInInspector]public bool isFinished;

    private void Awake()
    {
        Instance = this;
        token = GetComponent<Token>();
        active = GetComponent<Active>();
        relax = GetComponent<Relax>();
    }

    public void StartConnect ()
    {
        isFinished = false;
        GetToken();
    }    

    public void GetToken ()
    {
        token.SetConnection();
    }


    public void GetActiveData()
    {
        active.SetConnection();
    }

    public void GetRelaxData()
    {
        relax.SetConnection();
    }
}
