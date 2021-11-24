# Exercise 1 - Simple app

Name: Playgroundapp

Git: https://github.com/alineutron/k8s

OS:Windows

req: kubectl,docker must be installed

##### commands

1. git clone https://github.com/alineutron/k8s
2. cd dockerplayground
3. dotnet build
4. dotnet run
5. docker login docker.io  (use the username alineutron)
6. cd ..
7. docker build . -t alineutron/dockerplayground:dev
8. Docker run -p 8085:80 alineutron/dockerplayground:dev
9. docker exec -it 3088aee6c5f5 cmd



# Exercise 2 - using deployment files

Name: 02-dockerplayground-deployment

Git: https://github.com/alineutron/k8s

OS:Windows

req: kubectl,docker must be installed

##### commands

1. git clone https://github.com/alineutron/k8s
2. cd dockerplayground
3. dotnet build
4. dotnet run
5. docker login docker.io  (use the username alineutron)
6. cd ..
7. docker build . -t alineutron/dockerplayground:dev
8. Docker run -p 8085:80 alineutron/dockerplayground:dev
9. kubectl create -f .\deployment.yaml
10. kubectl create -f .\service.yaml
11. kubectl get pods
12. kubectl get services



# Exercise 3 - using helm

Name: 03-dockerplayground-chart

Git: https://github.com/alineutron/k8s

OS:Windows

req: kubectl,helm,docker must be installed

##### commands

1. git clone https://github.com/alineutron/k8s
2. cd dockerplayground
3. dotnet build
4. dotnet run
5. docker login docker.io  (use the username alineutron)
6. cd ..
7. docker build . -t alineutron/dockerplayground:dev
8. Docker run -p 8085:80 alineutron/dockerplayground:dev
9. helm install dockerplayground ./chart/
10. kubectl get pods
11. kubectl get services



# Exercise 4- Linux containers with helm

Name: 04-dockerplayground-linux

Git: https://github.com/alineutron/k8s

OS: linux

req: kubectl,helm,docker,minikube

##### Commands

1. cd .\04-dockerplayground-linux\
2. cd .\dockerplayground\
3. dotnet build
4. dotnet run
5. docker build . -t alineutron/dockerplayground:dev
6. docker push alineutron/dockerplayground:dev
7. helm install dockerplayground ./chart





Exercise 5- pipeline to create aks cluster

Name: 

Git: https://github.com/alineutron/k8s

OS: linux

req: kubectl,helm,docker,minikube



Exercise 9- pipeline to remove aks cluster

Name: 

Git: https://github.com/alineutron/k8s

OS: linux

req: kubectl,helm,docker,minikube



Exercise 9- Linux containers-build code using pipeline

Name: 

Git: https://github.com/alineutron/k8s

OS: linux

req: kubectl,helm,docker,minikube



Exercise 9- Linux containers-build code-push image using pipeline

Name: 

Git: https://github.com/alineutron/k8s

OS: linux

req: kubectl,helm,docker,minikube



Exercise 9- Linux containers-release pipeline

Name: 

Git: https://github.com/alineutron/k8s

OS: linux

req: kubectl,helm,docker,minikube







Exercise 5- Linux containers with helm and local docker

Name: 04-dockerplayground-linux

Git: https://github.com/alineutron/k8s

OS: linux

req: kubectl,helm,docker,minikube





Exercise 6- Linux containers-helm-local docker-volume

Name: 

Git: https://github.com/alineutron/k8s

OS: linux

req: kubectl,helm,docker,minikube



Exercise 7- Linux containers-helm-nodeport service

Name: 

Git: https://github.com/alineutron/k8s

OS: linux

req: kubectl,helm,docker,minikube





Exercise 8- Linux containers-helm-loadbalancer service

Name: 

Git: https://github.com/alineutron/k8s

OS: linux

req: kubectl,helm,docker,minikube



Exercise 9- Linux containers-build code using pipeline

Name: 

Git: https://github.com/alineutron/k8s

OS: linux

req: kubectl,helm,docker,minikube





Exercise 9- Linux containers-azure conatiner services

Name: 

Git: https://github.com/alineutron/k8s

OS: linux

req: kubectl,helm,docker,minikube



Exercise 9- Linux containers-connect to one of the VM

Name: 

Git: https://github.com/alineutron/k8s

OS: linux

req: kubectl,helm,docker,minikube