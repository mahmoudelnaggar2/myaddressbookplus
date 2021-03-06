﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;

namespace MyAddressBookPlus
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ///* using AD app registration principle
            var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(KeyVaultService.GetToken));
            var sec = kv.GetSecretAsync(WebConfigurationManager.AppSettings["CacheConnectionSecretUri"]).Result;
            KeyVaultService.CacheConnection = sec.Value;

            /////* Using Manage System Identity            
            ////AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
            ////KeyVaultClient keyVaultClient = new KeyVaultClient
            ////    (new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            ////var secret = keyVaultClient.GetSecretAsync(WebConfigurationManager.AppSettings["CacheConnectionSecretUri"]).Result;
            ////KeyVaultService.CacheConnection = secret.Value;
        }
}
}
