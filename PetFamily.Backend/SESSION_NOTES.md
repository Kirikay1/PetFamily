# SESSION_NOTES.md

## Проект

PetFamily.Backend — учебный backend-проект по Clean Architecture.

Проекты:
- PetFamily.API
- PetFamily.Application
- PetFamily.Domain
- PetFamily.Infrastructure

## Формат работы

Основной код пишет разработчик.

Codex работает как наставник и ревьюер:
- объясняет непонятные моменты;
- делает ревью;
- помогает разбирать ошибки;
- предлагает варианты решений;
- не делает большие задачи целиком без явного запроса.

Перед изменениями кода Codex должен сначала описать:
1. Что собирается изменить.
2. Какие файлы будут затронуты.
3. Почему эти изменения нужны.
4. Как это связано с текущим заданием.

Код менять только после явного разрешения.

## Текущий статус заданий

### Сделано

- B-1 выполнено.
- B-2 выполнено.
- B-3 выполнено.
- B-4 выполнено.

### В работе

- B-4.1: EF Core + PostgreSQL + DbContext + конфигурации + миграции.

### Добавлено в AGENTS.md

В `AGENTS.md` добавлены задания:
- B-5
- B-5.1
- B-5.2
- B-5.3
- B-5.4
- B-5.5

## Текущий прогресс по B-4.1

Уже сделано:
- Добавлен `docker-compose.yml` для PostgreSQL.
- PostgreSQL запускается через Docker.
- Добавлен `ApplicationDbContext` в `PetFamily.Infrastructure`.
- Добавлены пакеты EF Core / Npgsql / snake_case naming conventions.
- Добавлен `UserSecretsId` в `PetFamily.API`.
- Строка подключения хранится через user secrets.
- В `appsettings.json` оставлена заглушка строки подключения.
- В `ApplicationDbContext` используется `UseNpgsql`.
- В `ApplicationDbContext` используется `UseSnakeCaseNamingConvention`.
- Добавлено логирование EF Core через `LoggerFactory`.

Важно:
- В `docker-compose.yml` PostgreSQL проброшен наружу на порт `5434`.
- Поэтому локальная строка подключения должна использовать `Port=5434`.