echo "Postavljam kontejner!"
docker-compose up -d
echo "Zaganjam sql skripto!"
docker exec -u postgres postgres_postgres_avtokampi_1 psql postgres postgres -f docker-entrypoint-initdb.d/data.sql
echo "Kontejner z bazo je zagnan!"
