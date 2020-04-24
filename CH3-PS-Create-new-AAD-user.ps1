$PasswordProfile = New-Object -TypeName Microsoft.Open.AzureAD.Model.PasswordProfile
$PasswordProfile.Password = "ContosoUserPassword"
New-AzureADUser -DisplayName "Contoso User 1" -PasswordProfile $PasswordProfile -UserPrincipalName "user1@contosoinc.onmicrosoft.com" -AccountEnabled $true -MailNickName "user1"
