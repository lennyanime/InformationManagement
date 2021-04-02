using System.Threading.Tasks;

namespace InformationManagement.Infraestructura.Transversal.GenericClass
{
    public interface IHttpBaseClientGenericClass<T> where T : class
    {
        Task<T> Get(string path, string request);

        Task<T> Post(string path, T request);

        T Put(string path, T request);

        T Patch(string path, T request);
    }
}
