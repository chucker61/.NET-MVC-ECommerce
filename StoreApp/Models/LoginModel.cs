namespace StoreApp;

public class LoginModel
{
    private string? _returnUrl;
    public string ReturnUrl{ 
        get{return _returnUrl is null ? "/" : _returnUrl;} set{_returnUrl = value;}}
    public string? EMail { get; set; }
    public string? Password { get; set; }
}
