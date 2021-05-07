#!/bin/sh
docker container ls -a | grep "tr"
if [ $? -eq 0 ];then
    docker container stop tr
    docker container rm tr
    docker rmi  tr
	docker network ls |grep tr
	docker network rm tr
fi

docker build -t tr --build-arg env="Development" .
docker run -d --restart=always  -p 8051:8010 --name tr tr
docker cp /etc/localtime tr:/etc/