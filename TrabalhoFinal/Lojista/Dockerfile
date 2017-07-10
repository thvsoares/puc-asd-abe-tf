FROM microsoft/dotnet
RUN git clone https://github.com/thvsoares/puc-asd-abe-tf.git
RUN dotnet restore puc-asd-abe-tf/TrabalhoFinal/Lojista/
RUN dotnet publish -c Release -o /out puc-asd-abe-tf/TrabalhoFinal/Lojista/
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80
WORKDIR /out
ENTRYPOINT ["dotnet", "Lojista.dll"]
