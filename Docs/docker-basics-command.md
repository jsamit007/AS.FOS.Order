# Docker Basic Commands

1. Pull an image locally 
```
docker pull {image-name}
```

2. Run an Image eg - postgres
```
docker run --name postgres-db -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=YOUR_PASSWORD -e POSTGRES_DB=postgres -p 5432:5432 -d postgres
```

3. Run RabbitMq image
```
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq
```

3. Run postgres in powershell through docker
```
docker exec -it postgres psql -U postgres -d orderDB
```