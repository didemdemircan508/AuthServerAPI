using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyAuthServer.Core.Configuration;
using UdemyAuthServer.Core.DTOs;
using UdemyAuthServer.Core.Models;

namespace UdemyAuthServer.Core.Services
{
    public interface ITokenService
    {

        //burada birşey dönmiyeceğiz

        TokenDto CreateToken(UserApp userApp);

        ClientTokenDto CreateTokenByClient(Client client);


    }
}
