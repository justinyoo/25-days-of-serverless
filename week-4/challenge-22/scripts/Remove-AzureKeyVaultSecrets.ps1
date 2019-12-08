#
# This removes all secrets from Azure KeyVault
#

Param(
    [string] [Parameter(Mandatory=$true)] $KeyVaultName,
    [switch] [Parameter(Mandatory=$false)] $IsLocal,
    [string] [Parameter(Mandatory=$false)] $Username = $null,
    [string] [Parameter(Mandatory=$false)] $Password = $null,
    [string] [Parameter(Mandatory=$false)] $TenantId = $null
)

# Login if NOT local
if ($IsLocal -eq $false) {
    az login --service-principal -u $Username -p $Password -t $TenantId
}

# Get the list of secret names
$secrets = az keyvault secret list `
    --vault-name $KeyVaultName `
    --query [].id `
    | ConvertFrom-Json

$names = $secrets | ForEach-Object { $_.split("/")[-1] }

# Delete secrets
$names | ForEach-Object {
    $result = az keyvault secret delete `
        --vault-name $KeyVaultName `
        --name $_

    Write-Host "A secret `"$_`" has been removed from Key Vault" -ForegroundColor Green
}

Start-Sleep -Seconds 30

# Purge secrets
$names | ForEach-Object {
    az keyvault secret purge `
    --vault-name $KeyVaultName `
    --name $_

    Write-Host "A secret `"$_`" has been purged" -ForegroundColor Green
}

Remove-Variable result
