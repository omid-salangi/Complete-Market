using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IOrderServices
    {
        Task<bool> AddToCart(string username, int productid, int count);
    }
}