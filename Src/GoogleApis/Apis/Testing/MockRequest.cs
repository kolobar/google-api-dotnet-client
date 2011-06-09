/*
Copyright 2010 Google Inc

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Google.Apis.Requests;
using Google.Apis.Authentication;

namespace Google.Apis.Testing
{
    /// <summary>
    /// Mock request for testing purposes
    /// </summary>
    public class MockRequest : IRequest
    {
        public MockRequest()
        {
            HasExecuted = false;
        }

        public string RpcName { get; set; }
        public ReturnType ReturnType { get; set; }
        public IDictionary<string, string> Parameters { get; set; }
        public string Body { get; set; }
        public IAuthenticator Authenticator { get; set; }
        public bool HasExecuted { get; set; }
        public Stream StreamToReturn { get; set; }
        public string DeveloperKey { get; set; }

        #region IRequest Members

        public IRequest On(string rpcName)
        {
            RpcName = rpcName;
            return this;
        }


        public IRequest Returning(ReturnType returnType)
        {
            ReturnType = returnType;
            return this;
        }

        public IRequest WithParameters(IDictionary<string, object> parameters)
        {
            return WithParameters(parameters.ToDictionary(k => k.Key, v => v.Value != null ? v.Value.ToString() : null));
        }

        public IRequest WithParameters(IDictionary<string, string> parameters)
        {
            Parameters = parameters;
            return this;
        }


        public IRequest WithParameters(string parameters)
        {
            throw new NotImplementedException();
        }


        public IRequest WithBody(string body)
        {
            Body = body;
            return this;
        }


        public IRequest WithAuthentication(IAuthenticator authenticator)
        {
            Authenticator = authenticator;
            return this;
        }

        public IRequest WithDeveloperKey(string key)
        {
            DeveloperKey = key;
            return this;
        }


        public Stream ExecuteRequest()
        {
            HasExecuted = true;
            return StreamToReturn;
        }

        #endregion

        public IRequest WithBody(IDictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}