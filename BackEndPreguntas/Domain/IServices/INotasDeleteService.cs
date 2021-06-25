using BackEndPreguntas.Domain.Models;

namespace BackEndPreguntas.Domain.IServices
{
    public interface INotasDeleteService
    {
        ServiceResponse Execute(Notas notas);

    }
}
