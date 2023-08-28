using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyAuthServer.Core.DTOs;

namespace UdemyAuthServer.Core.Services
{
    public interface IAuthenticationService
    {
    //burada kullanıcıdan kullanıcı adı ve şifre alıp toekn oluşturma işlemi yapacağız

        Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto);

        Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken);

        //refresh token sonlanabilir ,kullanıcı logout olduğunda hem token hemde refsresh token silinmesi lazım

        Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken);

        Response<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto);




    }
}
