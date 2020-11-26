# AKS Test Deployment

## Install a Aks cluster
**Note:** Should run commands in a Azure cloud PowerShell
```powershell
$subscriptionid = '8b2ebf84-151c-4f50-a5c2-cfcbe4c779b5'
$aksClusterName = 'akspostmeetup01'
$aksClusterResourceGroup = 'akspostmeetup01'
$nodeCount = '1'
$resourceGroupLocation = 'westeurope'
$acrName = 'akspostmeetup01acr01'
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

cd <Path to solution of AksTest>

# Run in the directory where the code is
dotnet build

# Create the image
cd AksTestFrontend
docker build . -t xinfli/akstestfrontend:dev

cd ..\AksTestBackend
docker build . -t xinfli/akstestbackend:dev

# Start docker
cd ..
docker run -p 8081:80 `
           --name AksTest_Backend `
           -e Options__FrontendApiEndpoint=http://localhost:8082/api/Message/SendMessage `
           xinfli/akstestbackend:dev

# Parameter below can be added for debugging
# -e ASPNETCORE_ENVIRONMENT=Development `

docker run -p 8082:80 `
           --name AksTest_Frontend `
           xinfli/akstestfrontend:dev
```

## Push image to acr
**Note:** Should run commands in a local PowerShell
```powershell
$acrName = 'xlcr01'

# Its a cli on the docker login command
az acr login --name $acrName

# Check the login server
az acr list --output table

# List the repositories in the acr
az acr repository list --name $acrName

# Show all local images
docker image list
# Tag image
docker tag xinfli/akstestbackend:dev xlcr01.azurecr.io/xfdemo/akstestbackend:v1
# Show updated local images
docker image list
# Push image to new created acr
docker push xlcr01.azurecr.io/xfdemo/akstestbackend:v1

docker image list
docker tag xinfli/akstestfrontend:dev xlcr01.azurecr.io/xfdemo/akstestfrontend:v1
docker image list
docker push xlcr01.azurecr.io/xfdemo/akstestfrontend:v1

az acr repository list -n $acrName -o table
```
