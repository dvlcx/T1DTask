
# T1DTask

Разработан небольшой сервис на языке C#, используя .NET 9.

Приложение имеет двухслойную архитектуру - DAL (Два репозитроия для общения с БД) и PL (один контроллер).
Дополнительные задания:
- Сохранение исходного кода в git репозитории ✅
- Использование СУБД PostgreSQL ✅
- Использование ORM Entity Framework ✅
- Использование Code First подхода для создания структуры базы данных ✅ 
- Использование Docker, написание Dockerfile, а также Docker Compose файла для запуска всей системы (сервиса и СУБД). ✅ (в файлах Dockerfile и docker-compose.yml соответственно)


## Пример работы API 
#### Получить все курсы
```http
  GET /api/courses
```
![App Screenshot](https://github.com/dvlcx/T1DTask/blob/master/readme/courses-get.png?raw=true)

#### Создать Курс
```http
  POST /api/courses
```
![App Screenshot](https://github.com/dvlcx/T1DTask/blob/master/readme/courses-post.png?raw=true)

#### Добавить студента с курсом
```http
  POST /api/courses/{id:guid}/students
```
![App Screenshot](https://github.com/dvlcx/T1DTask/blob/master/readme/student-post.png?raw=true)

#### Удалить курс
```http
  DELETE /api/courses/{id:guid}
```
![App Screenshot](https://github.com/dvlcx/T1DTask/blob/master/readme/courses-delete.png?raw=true)
