EF := dotnet ef --project src/ForoMy.Infrastructure --startup-project src/ForoMy.Web

.PHONY: dev build test migration migrate

dev:
	dotnet watch --project src/ForoMy.Web --launch-profile http

build:
	dotnet build

test:
	dotnet test

migration:
	$(if $(name),,$(error Usage: make migration name=MigrationName))
	$(EF) migrations add $(name) --output-dir Data/Migrations

migrate:
	$(EF) database update