using BackEndPreguntas.Domain.Models;

namespace BackEndPreguntas.Domain.IServices
{
    public interface INotasUpdateService
    {
        ServiceResponse Execute(Notas notas);
    }
}
