#
# This sets secrets in Azure KeyVault
#

Param(
    [string] [Parameter(Mandatory=$true)] $KeyVaultName,
    [hashtable] [Parameter(Mandatory=$true)] $Secrets,
    [switch] [Parameter(Mandatory=$false)] $IsLocal,
    [string] [Parameter(Mandatory=$false)] $Username = $null,
    [string] [Parameter(Mandatory=$false)] $Password = $null,
    [string] [Parameter(Mandatory=$false)] $TenantId = $null
)

# Login if NOT local
if ($IsLocal -eq $false) {
    az login --service-principal -u $Username -p $Password -t $TenantId
}

$Secrets.Keys | ForEach-Object {
    $result = az keyvault secret set `
                  --vault-name $KeyVaultName `
                  --name $_ `
                  --value $Secrets[$_]

    Write-Host "A secret has been set to `"$_`"" -ForegroundColor Green
}

Remove-Variable result
