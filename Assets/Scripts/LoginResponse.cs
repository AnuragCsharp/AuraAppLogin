[System.Serializable]
public class LoginResponse
{
    public string status;
    public string message;
    public Data data;

    [System.Serializable]
    public class Data
    {
        public string token;
    }
}