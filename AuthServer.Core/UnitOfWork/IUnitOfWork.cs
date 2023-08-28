using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyAuthServer.Core.UnitOfWork
{
    public interface IUnitOfWork
    {

        //asekron metodunu yazıyoruz

        Task CommitAsync();
        //bazen asekron olamayan methoduna ihtiyacmız var o yüzden asekron olamayanını yazıyoruz
        void Commit();
    }
}
