using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharpDemo.Models;
using RestSharp;
using Newtonsoft.Json;

namespace RestSharpDemo
{
    public class Demo
    {
        private Helper helper;

        public Demo()
        {
            helper = new Helper();
        }

        public RestResponse GetUsers(string baseUrl)
        {

            var client = helper.SetUrl(baseUrl, "api/users?page=2");
            var request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response = helper.GetResponse(client, request);     
            return response;
        }

        public RestResponse CreateNewUser(string baseUrl, dynamic payload)
        {
            var client = helper.SetUrl(baseUrl, "api/users");
            var jsonString = HandleContent.SerializeJsonString(payload);
            var request = helper.CreatePostRequest(jsonString);
            var response = helper.GetResponse(client, request);
            return response;
        }
    }
}
