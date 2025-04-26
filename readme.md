# How to Run this Application

1. First install docker desktop - https://www.docker.com/products/docker-desktop/
2. Install Postgres Image
3. Open Powershell and paste following commands 
  ```
  docker pull postgres
  ```
4. Install RabbitMQ Image
```
dcoker pull rabbitmq
```
5. Run these images follow this - [Link Text](./Docs/docker-basics-command.md)
6. Now install Postgres client App (Server not required as it is already installed in docker) - https://www.pgadmin.org/download/
7. Connect to PGAdmin and Execute this script [Link Test](./AS.FOS.Order.Persistence/order.sql)
8. Now execute this data seed script - [Link Text](./Docs/initial-script.sql)
9. Now Start the Application
10. Test APIs - [Link Text](./Docs/order-apis.http)












