using System;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Tooling.Connector;

static void Main(string[] args)
{
    string url = "https://contoso.crm.dynamics.com";
    string username = "user@contoso.onmicrosoft.com";
    string password = "Pass@rowd1";
    string conn = $@"Url = {url}; AuthType = Office365; UserName = {username}; Password = {password};";
    using (var svc = new CrmServiceClient(conn))
    {
        WhoAmIRequest request = new WhoAmIRequest();
        WhoAmIResponse response = (WhoAmIResponse)svc.Execute(request);
        Console.WriteLine("Your userid = {0}", response.UserId);
    }
}
