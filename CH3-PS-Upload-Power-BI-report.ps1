New-PowerBIReport -Path '.\contososales1.pbix' -Name 'Contoso Sales Analysis Report' -Workspace ( Get-PowerBIWorkspace -Name 'Contoso Sales Workspace' )
