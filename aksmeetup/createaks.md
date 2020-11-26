# AKS Test Deployment

## Install a Aks cluster
**Note:** Should run commands in a Azure cloud PowerShell
```powershell
$subscriptionid = ''
$aksClusterName = 'akmeetup01'
$aksClusterResourceGroup = 'akmeetup01'
$nodeCount = '1'
$resourceGroupLocation = 'westeurope'
$acrName = 'acrmeetup01'
$sku = 'basic'

az login

az account set --subscription $subscriptionid

az account show --output table

az group create `
   --location $resourceGroupLocation `
   --name $aksClusterResourceGroup

az aks create `
   --name $aksClusterName `
   --resource-group $aksClusterResourceGroup `
   --node-count $nodeCount `
   --generate-ssh-keys
```

## Creating a azure container registry
**Note:** Should run commands in a Azure cloud PowerShell
```powershell
az acr create `
   --name $acrName `
   --resource-group $aksClusterResourceGroup `
   --sku $sku `
   --location $resourceGroupLocation

az acr list --output table
```

## Adding service principle and assign it to AKS
**Note:** Should run commands in a Azure cloud PowerShell
```powershell
# Create the service principle
$svcPrinciple = (az ad sp create-for-rbac --skip-assignment | ConvertFrom-Json)

$acrId = az acr show `
   --name $acrName `
   --resource-group $aksClusterResourceGroup `
   --query "id" `
   --output tsv

az role assignment create `
   --assignee $svcPrinciple.appId `
   --role Reader `
   --scope $acrId

az aks update-credentials `
   --name $aksClusterName `
   --resource-group $aksClusterResourceGroup `
   --reset-service-principal `
   --service-principal $svcPrinciple.appId `
   --client-secret $svcPrinciple.password

az aks list --resource-group $aksClusterResourceGroup
```

## Create docker image and run it locally
**Note:** Should run commands in a local PowerShell
```powershell
docker images

cd <code path aksmeetup>

# Run in the directory where the code is
dotnet build

# Create the image
cd AksTestFrontend
docker build . -t meetup/aksmeetup:dev


```

## Push image to acr
**Note:** Should run commands in a local PowerShell
```powershell

# Its a cli on the docker login command
az acr login --name $acrName

# Check the login server
az acr list --output table

# List the repositories in the acr
az acr repository list --name $acrName

# Show all local images
docker image list
# Tag image
docker tag meetup/aksmeetup:dev akspostmeetup01acr01.azurecr.io/aksmeetup:v1
# Show updated local images
docker image list
# Push image to new created acr
docker push akspostmeetup01acr01.azurecr.io/aksmeetup:v1


az acr repository list -n $acrName -o table
```
