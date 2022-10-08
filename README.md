Web приложение в стиле REST с JWT-авторизацией
==============
Функционал:
--------------
- Получить JWT токен :
  "POST" "api/login"
  {
    "username" : "name",
    "password": "pass"
  }
-------------
 - Получить всех юзеров (Role = "Admin"):
  "GET" "api/users"
-------------
 - Получить уникального юзера (Role = "Admin"):
  "GET" "api/users/{userID}"
-------------
 - Добавить юзера (Role = "Admin"):
  "POST" "api/users"
  {
    "Age": "age",
    "Name": "name"
  }
 -------------
   - Изменить юзера юзера (Role = "Admin"):
  "PUT" "api/users/{userID}"
  {
    "Age": "age",
    "Name": "name"
  }
 -------------
   - Удалить уникального юзера (Role = "Admin"):
  "DELETE" "api/users/{userID}"
