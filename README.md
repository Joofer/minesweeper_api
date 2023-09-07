# minesweeper_api
API для онлайн-игры Сапер ([ссылка](https://minesweeper-test.studiotg.ru/))

## Методы REST API
| Метод | Описание | Принимаемое значение | Возвращаемое значение | Значение ошибки |
| --- | --- | --- | --- | --- |
| `/new` | Создает новую игру, формируя поле из `width` x `height` ячеек с `mines_count` минами в случайных ячейках | {<br />width ```int```<br />height ```int```<br />mines_count ```int```<br />} | {<br />game_id ```guid```<br />width ```int```<br />height ```int```<br />mines_count ```int```<br />completed ```bool```<br />field ```string[,]```<br />} | {<br />error ```string```<br />} |
| `/turn` | Создает запрос на открытие клетки по адресу (```col```, ```row```) | {<br />game_id ```guid```<br />col ```int```<br />row ```int```<br />} | {<br />game_id ```guid```<br />width ```int```<br />height ```int```<br />mines_count ```int```<br />completed ```bool```<br />field ```string[,]```<br />} | {<br />error ```string```<br />} |

### Возможные ошибки
| Сообщение ошибки | Описание |
| --- | --- |
| Bad request: ячейка (```col```, ```row```) уже открыта. | Ячейка по адресу (```col```, ```row```) уже открыта |
| Bad request: игра уже закончилась. | Игра с идентификатором ```guid``` закончилась, открытие ячейки в законченой игре невозможно |
| Not found: объект GameInfo с идентификатором 3fa85f64-5717-4562-b3fc-2c963f66afa6 не найден. | Игра с идентификатором ```guid``` не найдена |

## Корневые проекты
| Проект | Описание |
| --- | --- |
| CollectionManager | Содержит вспомогательный класс List2d, упрощающий работу с двумерными списками |
| Minesweeper | Основная логика игры Minesweeper |
| Contracts | Контракты для методов REST API |
| Domain | Основные классы проекта, содержащие описание сущностей, интерфейсы репозиториев и исключения для репозиториев |
| Services.Abstractions | Интерфейсы сервисов для использования из контроллеров |
| Services | Имплементация интерфейсов сервисов, скрытая от контроллеров |
| Persistence | Имплементация репозиториев и контекст базы данных |
| Presentation | Контроллеры для методов REST API |
| minesweeper_api | Обертка вокруг всех сервисов, запускает Web-проект, докунтацию Swagger и определает политику CORS |

## Unit-testing проекты
| Проект | Описание |
| --- | --- |
| Common | Общие классы для тестирования проекта |
| CollectionManager.Tests | Тесты CollectionManager |
| Controllers.Tests | Тесты Controllers |
| Minesweeper.Game.Core.Tests | Тесты Minesweeper.Game.Core |
| Repository.Tests | Тесты Repository |
| Services.Tests | Тесты Services |
