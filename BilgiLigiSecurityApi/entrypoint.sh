#!/bin/bash
/opt/mssql/bin/sqlservr &

# SQL Server'ın hazır olmasını bekleyelim
sleep 30s

# init.sql dosyasını çalıştırarak veritabanını oluştur
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Single2024! -d master -i /docker-entrypoint-initdb.d/init.sql