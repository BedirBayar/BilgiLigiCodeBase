FROM mcr.microsoft.com/mssql/server:2022-latest

# SQL Server i�in gerekli ara�lar� y�kleme (sqlcmd dahil)
RUN apt-get update \
    && apt-get install -y curl apt-transport-https \
    && curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - \
    && curl https://packages.microsoft.com/config/ubuntu/20.04/prod.list > /etc/apt/sources.list.d/mssql-release.list \
    && apt-get update \
    && ACCEPT_EULA=Y apt-get install -y msodbcsql17 mssql-tools unixodbc-dev \
    && apt-get clean -y

# PATH'e sqlcmd ekleme
ENV PATH="$PATH:/opt/mssql-tools/bin"

# SQL Server ba�lat
CMD /opt/mssql/bin/sqlservr