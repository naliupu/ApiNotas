using BackEndPreguntas.Domain.Models;

namespace BackEndPreguntas.Domain.IServices
{
    public interface INotasSearchDateService
    {
        ServiceResponse Execute(Notas notas);
    }
}
