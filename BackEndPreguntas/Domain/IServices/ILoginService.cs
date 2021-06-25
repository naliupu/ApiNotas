using BackEndPreguntas.Domain.Models;

namespace BackEndPreguntas.Domain.IServices
{
    public interface ILoginService
    {
        AuthenticateResponse Login(Users users);
    }
}