# 基于dotnet基础环境构建镜像
FROM docker.io/microsoft/dotnet

RUN mkdir /TR
#定义参数
ARG env
# 把发布的内容拷贝到docker容器的TR目录下
COPY /publish /TR
# 设置工作目录
WORKDIR /TR
# 暴露80端口
EXPOSE 8010
# 设置环境变量
ENV ASPNETCORE_ENVIRONMENT=$env
# 启动web
RUN echo "执行环境： $env"
CMD ["dotnet","TR.dll"]
