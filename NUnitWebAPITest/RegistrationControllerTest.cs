using Epassport;
using System.Collections.Generic;
using Epassport.Models;
using System.Net;
using System.Reflection;
using EPassport.Models;
using System.Linq;
using NUnit.Framework;
using System.Net.Http;

namespace NUnitWebAPITest
{
    public class Tests
    {
        private IList<UserRegistration> _userListExpected, _userListActual;
        private UserRegistration user1, user2;
        private HttpClient _client;
        private HttpResponseMessage _response;
        private const string ServiceBaseURL = "https://localhost:44309/api/";


        [SetUp]
        public void Setup()
        { 
         _client = new HttpClient {BaseAddress = new Uri(ServiceBaseURL)};

           _userListExpected = new List<UserRegistration>()
            {
                new UserRegistration { firstName = "chandrika", lastName = "Gollapudi", dOB = DateTime.Parse("2000/05/30"), gender = "Female", eMailId = "goaklghgfewu8@gmail.com", password = "ryedwuhji@43", phoneNumber = 1324456789, UserType = "Admin", UserID = "rytwegfrdiuew2q817" },
                new UserRegistration { firstName = "sai", lastName = "Divya", dOB = DateTime.Parse("2000/01/28"), gender = "Female", eMailId = "goaklghghfewu8@gmail.com", password = "ytghmewuhji@43", phoneNumber = 1324457654, UserType = "User", UserID = "rytwegfrdiu8t62q817" },
                new UserRegistration { firstName = "Soumy", lastName = "Mishra", dOB = DateTime.Parse("2000/01/17"), gender = "Male", eMailId = "soumy@gmail.com", password = "Soumy@123", phoneNumber = 456321457, UserType = "User", UserID = "A" }
              
            };
        }

        [TearDown]
        public void DisposeTest()
        {
            if (_response != null)
                _response.Dispose();

            if (_client != null)
                _client.Dispose();
        }


        [Test]
        public void Test1()
        {

            var responseTask = _client.GetAsync("Registration");
            responseTask.Wait();
            _response = responseTask.Result;
            if (_response.IsSuccessStatusCode)
            {
                var readTask = _response.Content.ReadAsAsync<UserRegistration[]>();
                readTask.Wait();
                _userListActual = readTask.Result;
            }
            Assert.IsNotNull(_userListActual);
        }
    }
}