1.Build the image with sdk 2.1
docker build --tag jordiascension/dependency_injection .
2.Create the image
docker run --rm --name dependency jordiascension/dependency_injection:1.0
3.Push the image
docker push jordiascension/dependency_injection:1.0
4.Pull the image
docker pull jordiascension/dependency_injection:1.0
5.Docker Hub Image
https://hub.docker.com/repository/docker/jordiascension/dependency_injection
6.Github Source Code Repository
https://github.com/jordiascension/docker_dependency_injection

---

7.Theory
https://goinbigdata.com/docker-run-vs-cmd-vs-entrypoint/

Use RUN instructions to build your image by adding layers on top of initial image.

Prefer ENTRYPOINT to CMD when building executable Docker image and you need a
command always to be executed. Additionally use CMD if you need to provide 
extra default arguments that could be overwritten from command line when 
docker container runs.

Choose CMD if you need to provide a default command and/or arguments that can 
be overwritten from command line when docker container runs.