using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IOrderServices
    {
        Task<bool> AddToCart(string userid, int productid, int count);
    }
}