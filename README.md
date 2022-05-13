## Репозиторий для тестового задания :hatching_chick:
В данном репозитории находится десктопный WPF-клиент, находящийся в доработке. \
Реализованная серверная часть расположена [тут](https://github.com/aamenkov/DeliveryCompany).

* * *
### Условие. Задание C#:

Общее описание: есть Клиент, у него есть груз, и он готов отдать этот груз в назначенном месте в назначенное время. \
Компания силами курьеров забирает груз и доставляет его по указанному клиентом адресу. 

Необходимо создать приложение (WPF или любая платформа), которое позволит:
1. Зарегистрировать заявку на получение и доставку груза (с установкой статуса «Новая»)
2. Отобразить реестр заявок (таблица, список)
3. Найти заявку по введенному в поле тексту, принцип поиска – «по всем полям»
4. Передать заявку на выполнение (исполнители – курьеры)
5. Редактировать заявку. При этом, редактирование подразумевает:
    1. Редактирование полей с данными – допускается только, если заявка находится в статусе  «Новая»
    2. Перевод заявки в статус «Передано на выполнение»
    3. Перевод заявки в статус «Выполнено»
    4. Перевод заявки в статус «Отменена» с вводом комментария причины отмены
6. Удалить заявку


* * *
### To RUN:
* Модифицировать appsettings.json для корректного использования БД.
* Открыть в VS (>Средства >Диспетчер пакетов NuGet >Консоль) \
 В проекте по умолчанию в консоли должен стоять проект "DeliveryCompanyDataAccessEF"
```  
  add-migration {MigrationName}
  update-database
```  
* Запустить проект [DeliveryCompanyWebApi](https://github.com/aamenkov/DeliveryCompany).
* Запустить проект DeliveryCompany_WPF.

* * *
