string url = "https://contoso.crm.dynamics.com";
string clientId = "51f81489-12ee-4a9e-aaae-a2591f45987d";
string clientsecret = "<yourclientsecret>";
string tenantid = "<yourtenantid>";

AuthenticationContext authContext = new AuthenticationContext("https://login.microsoftonline.com/common" + tenantid, false);
ClientCredential credential = new ClientCredential(clientId, clientsecret);
AuthenticationResult result = authContext.AcquireToken(url, credential);
