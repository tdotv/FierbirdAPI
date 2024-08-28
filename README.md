## Описание
Это API для работы с FireBird Server 5.0, разработанное на .NET 8. Включает интеграцию с Swagger и Entity Framework Core (EFCore).

## Установка
1. Клонируйте репозиторий:
    ```bash
    git clone https://github.com/tdotv/FierbirdAPI.git
    ```

2. Перейдите в директорию проекта:
    ```bash
    cd your-repo
    ```

3. Установите зависимости:
    ```bash
    dotnet restore
    ```

## Настройка
Настройте строку подключения к базе данных FireBird в `Startup.cs`:
```cs
options.UseFirebird("database=localhost:TESTDB.FDB;user=SYSDBA;password=sysdba"
```

## Миграции
Для создания и применения миграций используйте следующие команды:<br/>
**P.S.** В Visual Studio "dotnet ef" не существует. Используйте dotnet-ef
1. Создание миграции:
    ```bash
    dotnet ef migrations add InitialCreate
    ```

2. Применение миграций:
    ```bash
    dotnet ef database update
    ```

## Swagger
```bash
    http://localhost:5000/api/docs/index.html
```

## Запуск
Запустите приложение:
```bash
dotnet run
```
