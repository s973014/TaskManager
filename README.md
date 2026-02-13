# Task Manager (ASP.NET Core MVC + Docker + PostgreSQL)

Task Manager — это простое веб-приложение для управления проектами и задачами.  
Проект реализован с использованием **ASP.NET Core MVC**, **Entity Framework Core**, **PostgreSQL** и **Docker**.

---

## 🧰 Технологии

- **Backend:** ASP.NET Core MVC (net8.0)  
- **ORM:** Entity Framework Core 8  
- **База данных:** PostgreSQL 16  
- **Контейнеризация:** Docker + Docker Compose  
- **Архитектура:** Multi-layer (Web / Application / Infrastructure / Domain)  

---

## ⚙️ Возможности

- CRUD для **Проектов** и **Задач**  
- Миграции базы данных через EF Core  
- Полная работа в контейнерах Docker  
- Поддержка конфигурации через `.env`  

---

## Структура проекта

```plaintext
TaskManager.sln
├── Web
│   ├── Controllers
│   ├── Views
│   ├── ViewModels
│   └── Program.cs
├── Application
│   ├── Interfaces
│   ├── Services
│   ├── DTOs
│   └── Mappings
├── Infrastructure
│   ├── Data
│   │   ├── AppDbContext.cs
│   │   └── Configurations
│   ├── Repositories
│   └── Migrations
└── Domain
    ├── Entities
    ├── Enums
    └── Common
```

## 🐳 Установка и запуск через Docker

### 1. Клонировать репозиторий

```bash
git clone https://github.com/s973014/TaskManager.git
cd TaskManager

```

### 2. Создать .env файл в корне проекта

#### Пример содержимого .env:
```
# PostgreSQL
POSTGRES_DB=taskmanager
POSTGRES_USER=postgres
POSTGRES_PASSWORD=postgres

# ASP.NET Core
DB_HOST=db
DB_PORT=5432
DB_NAME=taskmanager
DB_USER=postgres
DB_PASSWORD=postgres
```
### 3. Поднять контейнеры
```
docker-compose down -v   # удаляем старые контейнеры и тома
docker-compose up --build
```

- -v удаляет том PostgreSQL, чтобы пересоздать базу с новыми переменными окружения

- --build пересобирает образы заново

### 4. Доступ к приложению

После запуска в браузере:

```http://localhost:5000```

- Все миграции EF Core применяются автоматически при старте контейнера.

## 👨‍💻 Разработка

- Все изменения делаются через слои Application / Infrastructure

- В Web создаются контроллеры, представления и ViewModels
- Используется DI (Dependency Injection) для сервисов и репозиториев

## 🖼️ Скриншоты работы

Ниже показан интерфейс Task Manager и примеры CRUD операций с задачами и проектами.

### Главная страница

![Главная страница](screenshots/homepage.jpg)

---

### Создание проекта

![Создание проекта](screenshots/createproject.jpg)

---

### Редактирование проекта

![Редактирование проекта](screenshots/editproject.jpg)

---

### Создание новой задачи

![Создание новой задачи](screenshots/createtask.jpg)

---

### Просмотр проекта

![Просмотр проекта](screenshots/project.jpg)