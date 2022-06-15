using CarPool.Models.Authentication;




namespace CarPool.BL.Authentication
{
    public interface IAuthenticationManager
    {
        JWT Authenticate(LoginRequest loginRequest);
    }
}
