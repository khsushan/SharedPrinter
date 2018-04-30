using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarkPredictor.Dto;
using MarkPredictor.Common;

namespace MarkPredictor.Controllers.Account
{
    public class AccountController : IAccountController
    {
        private HttpClient _httpClient;

        public AccountController()
        {
            _httpClient = InstanceFactory.GetHttpClientInstance();
        }

        public async Task<StudentDto> login(StudentDto studentDto)
        {
            return await _httpClient.Login(studentDto);
        }
    }
}
