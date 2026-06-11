# minesweeper_api

[![Build and deploy .NET Core application to Web App minesweeperapi](https://github.com/Joofer/minesweeper_api/actions/workflows/minesweeperapi.yml/badge.svg)](https://github.com/Joofer/minesweeper_api/actions/workflows/minesweeperapi.yml)

API for the online Minesweeper game ([link](https://minesweeper-test.studiotg.ru/))

## Testing

To test the application, you need a locally deployed Cosmos DB database ([installation](https://learn.microsoft.com/en-us/azure/cosmos-db/how-to-develop-emulator?tabs=windows%2Ccsharp&pivots=api-nosql)).

After installation, start the application and create the `MinesweeperDb` database (NOTE: you can choose any other name as well, provided that you also specify it in `appsettings.json`) through the Cosmos DB Data Explorer ([local link](https://localhost:8081/_explorer/index.html)).

You can also use the Azure Cosmos DB cloud service ([link](https://azure.microsoft.com/en-us/products/cosmos-db/)).

## REST API Methods

| Method | Description | Accepted value | Returned value | Error value |
| --- | --- | --- | --- | --- |
| `/new` | Creates a new game by generating a board of `width` x `height` cells with `mines_count` mines placed in random cells | {<br />width `int`<br />height `int`<br />mines_count `int`<br />} | {<br />game_id `guid`<br />width `int`<br />height `int`<br />mines_count `int`<br />completed `bool`<br />field `string[,]`<br />} | {<br />error `string`<br />} |
| `/turn` | Creates a request to open a cell at address (`col`, `row`) | {<br />game_id `guid`<br />col `int`<br />row `int`<br />} | {<br />game_id `guid`<br />width `int`<br />height `int`<br />mines_count `int`<br />completed `bool`<br />field `string[,]`<br />} | {<br />error `string`<br />} |

### Possible Errors

| Error message | Description |
| --- | --- |
| Bad request: cell (`col`, `row`) is already open. | The cell at address (`col`, `row`) is already open |
| Bad request: the game has already ended. | The game with identifier `guid` has ended; opening a cell in a completed game is impossible |
| Not found: GameInfo object with identifier `guid` was not found. | The game with identifier `guid` was not found |

## Root Projects

| Project | Description |
| --- | --- |
| CollectionManager | Contains the helper class List2d, which simplifies working with two-dimensional lists |
| Minesweeper | Main Minesweeper game logic |
| Contracts | Contracts for REST API methods |
| Domain | Main project classes containing entity descriptions, repository interfaces, and repository exceptions |
| Services.Abstractions | Service interfaces for use from controllers |
| Services | Implementation of service interfaces hidden from controllers |
| Persistence | Repository implementation and database context |
| Presentation | Controllers for REST API methods |
| minesweeper_api | Wrapper around all services; launches the Web project, Swagger documentation, and defines the CORS policy |

## Unit Testing Projects

| Project | Description |
| --- | --- |
| Common | Common classes for project testing |
| CollectionManager.Tests | CollectionManager tests |
| Controllers.Tests | Controllers tests |
| Minesweeper.Game.Core.Tests | Minesweeper.Game.Core tests |
| Repository.Tests | Repository tests |
| Services.Tests | Services tests |
