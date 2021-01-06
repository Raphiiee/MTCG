@echo off

REM --------------------------------------------------
REM Monster Trading Cards Game
REM --------------------------------------------------
title Monster Trading Cards Game
echo CURL Testing for Monster Trading Cards Game
echo.

REM --------------------------------------------------
echo 1) Create Users (Registration)
REM Create User
curl -X POST http://localhost:10001/users --header "Content-Type: application/json" -d "{\"Username\":\"kienboec\", \"Password\":\"daniel\"}"
echo.
curl -X POST http://localhost:10001/users --header "Content-Type: application/json" -d "{\"Username\":\"altenhof\", \"Password\":\"markus\"}"
echo.
curl -X POST http://localhost:10001/users --header "Content-Type: application/json" -d "{\"Username\":\"admin\",    \"Password\":\"istrator\"}"
echo.

echo should fail:-----------------------
curl -X POST http://localhost:10001/users --header "Content-Type: application/json" -d "{\"Username\":\"kienboec\", \"Password\":\"danielf\"}"
echo.
curl -X POST http://localhost:10001/users --header "Content-Type: application/json" -d "{\"Username\":\"kienboec\", \"Password\":\"different\"}"
echo. 
echo.

REM -------------------------REGISTRIEUNG UND LOGIN ÜBER SELBE MeTHODE [EDIT]
echo 2) Login Users
curl -X POST http://localhost:10001/users --header "Content-Type: application/json" -d "{\"Username\":\"kienboec\", \"Password\":\"daniel\"}"
echo.
curl -X POST http://localhost:10001/users --header "Content-Type: application/json" -d "{\"Username\":\"altenhof\", \"Password\":\"markus\"}"
echo.
curl -X POST http://localhost:10001/users --header "Content-Type: application/json" -d "{\"Username\":\"admin\",    \"Password\":\"istrator\"}"
echo.

echo should fail:---------------------------
curl -X POST http://localhost:10001/users --header "Content-Type: application/json" -d "{\"Username\":\"kienboec\", \"Password\":\"different\"}"
echo.
echo.

REM --------------------------------------------------
echo 4) acquire packages kienboec
curl -X POST http://localhost:10001/transactions/packages --header "Content-Type: application/json" --header "Authorization: 926771" -d "{\"PackId\": \"1\"}"
echo.
curl -X POST http://localhost:10001/transactions/packages --header "Content-Type: application/json" --header "Authorization: 926771" -d "{\"PackId\": \"2\"}"
echo.
curl -X POST http://localhost:10001/transactions/packages --header "Content-Type: application/json" --header "Authorization: 926771" -d "{\"PackId\": \"3\"}"
echo.
curl -X POST http://localhost:10001/transactions/packages --header "Content-Type: application/json" --header "Authorization: 926771" -d "{\"PackId\": \"4\"}"
echo.
echo should fail (no money):
curl -X POST http://localhost:10001/transactions/packages --header "Content-Type: application/json" --header "Authorization: 926771" -d "{\"PackId\": \"5\"}"
echo.
echo.

REM --------------------------------------------------
echo 5) acquire packages altenhof
curl -X POST http://localhost:10001/transactions/packages --header "Content-Type: application/json" --header "Authorization: 718124" -d "{\"PackId\": \"1\"}"
echo.
curl -X POST http://localhost:10001/transactions/packages --header "Content-Type: application/json" --header "Authorization: 718124" -d "{\"PackId\": \"2\"}"
echo.
echo should fail (no package):
curl -X POST http://localhost:10001/transactions/packages --header "Content-Type: application/json" --header "Authorization: 718124" -d ""
echo.
echo.

REM --------------------------------------------------
echo 7) acquire newly created packages altenhof
curl -X POST http://localhost:10001/transactions/packages --header "Content-Type: application/json" --header "Authorization: 718124" -d "{\"PackId\": \"3\"}"
echo.
curl -X POST http://localhost:10001/transactions/packages --header "Content-Type: application/json" --header "Authorization: 718124" -d "{\"PackId\": \"4\"}"
echo.
echo should fail (no money):
curl -X POST http://localhost:10001/transactions/packages --header "Content-Type: application/json" --header "Authorization: 718124" -d "{\"PackId\": \"5\"}"
echo.
echo.

REM --------------------------------------------------
echo 8) show all acquired cards kienboec
curl -X GET http://localhost:10001/cards --header "Authorization: 926771"
echo should fail (no token)
curl -X GET http://localhost:10001/cards
echo.
echo.

REM --------------------------------------------------
echo 9) show all acquired cards altenhof
curl -X GET http://localhost:10001/cards --header "Authorization: 718124"
echo.
echo.

REM --------------------------------------------------
echo 10) show unconfigured deck
curl -X GET http://localhost:10001/deck --header "Authorization: 926771"
echo.
curl -X GET http://localhost:10001/deck --header "Authorization: 718124"
echo.
echo.

REM --------------------------------------------------
echo 11) configure deck
curl -X PUT http://localhost:10001/deck --header "Content-Type: application/json" --header "Authorization: 926771" -d "[{\"DeckCard\": \"28\"},{\"DeckCard\": \"42\"},{\"DeckCard\": \"95\"},{\"DeckCard\": \"139\"}]"
echo.
curl -X GET http://localhost:10001/deck --header "Authorization: 926771"
echo.
curl -X PUT http://localhost:10001/deck --header "Content-Type: application/json" --header "Authorization: 718124" -d "[{\"DeckCard\": \"54\"},{\"DeckCard\": \"129\"},{\"DeckCard\": \"179\"},{\"DeckCard\": \"231\"}]"
echo.
curl -X GET http://localhost:10001/deck --header "Authorization: 718124"
echo.
echo.
echo show original from before:
curl -X PUT http://localhost:10001/deck --header "Content-Type: application/json" --header "Authorization: 718124" -d "[{\"DeckCard\": \"54\"},{\"DeckCard\": \"129\"},{\"DeckCard\": \"179\"},{\"DeckCard\": \"231\"}]"
echo.
curl -X GET http://localhost:10001/deck --header "Authorization: 718124"
echo.
echo.
echo should fail ... only 3 cards set
curl -X PUT http://localhost:10001/deck --header "Content-Type: application/json" --header "Authorization: 718124" -d "[{\"DeckCard\": \"54\"},{\"DeckCard\": \"129\"},{\"DeckCard\": \"179\"}]"
echo.

REM --------------------------------------------------
echo 12) show configured deck 
curl -X GET http://localhost:10001/deck --header "Authorization: 926771"
echo.
curl -X GET http://localhost:10001/deck --header "Authorization: 718124"
echo.
echo.

REM --------------------------------------------------
echo 15) stats
curl -X GET http://localhost:10001/stats --header "Authorization: 926771"
echo.
curl -X GET http://localhost:10001/stats --header "Authorization: 718124"
echo.
echo.

REM --------------------------------------------------
echo 16) scoreboard
curl -X GET http://localhost:10001/score --header "Authorization: 926771"
echo.
echo.

REM --------------------------------------------------
echo 17) battle
start /b "kienboec battle" curl -X GET http://localhost:10001/battle --header "Authorization: 926771"
start /b "altenhof battle" curl -X GET http://localhost:10001/battle --header "Authorization: 718124"
ping localhost -n 10 >NUL 2>NUL

REM --------------------------------------------------
echo 18) Stats 
echo kienboec
curl -X GET http://localhost:10001/stats --header "Authorization: 926771"
echo.
echo altenhof
curl -X GET http://localhost:10001/stats --header "Authorization: 718124"
echo.
echo.

REM --------------------------------------------------
echo 19) scoreboard
curl -X GET http://localhost:10001/score --header "Authorization: 926771"
echo.
echo.

REM --------------------------------------------------
echo 20) trade
echo check trading deals
curl -X GET http://localhost:10001/tradings --header "Authorization: 926771"
echo.
echo create trading deal
curl -X POST http://localhost:10001/tradings --header "Content-Type: application/json" --header "Authorization: 926771" -d "{\"Insert\":true,\"WantId\":6,\"GiveId\":12,\"UserTradeWith\":\"\"}"
echo.
echo check trading deals
curl -X GET http://localhost:10001/tradings --header "Authorization: 926771"
echo.
curl -X GET http://localhost:10001/tradings --header "Authorization: 718124"
echo.
echo delete trading deals
curl -X DELETE http://localhost:10001/tradings --header "Content-Type: application/json" --header "Authorization: 926771" -d "{\"WantedId\":\"6\"}"
echo.
echo.

REM --------------------------------------------------
echo 21) check trading deals
curl -X GET http://localhost:10001/tradings  --header "Authorization: 926771"
echo.
curl -X POST http://localhost:10001/tradings --header "Content-Type: application/json" --header "Authorization: 926771" -d "{\"Insert\":true,\"WantId\":6,\"GiveId\":12,\"UserTradeWith\":\"\"}"
echo check trading deals
curl -X GET http://localhost:10001/tradings  --header "Authorization: 926771"
echo.
curl -X GET http://localhost:10001/tradings  --header "Authorization: 718124"
echo.
echo try to trade with yourself (should fail)
curl -X POST http://localhost:10001/tradings --header "Content-Type: application/json" --header "Authorization: 926771" -d "{\"Insert\":false,\"WantId\":6,\"GiveId\":0,\"UserTradeWith\":\"kienboec\"}"
echo.
echo try to trade 
echo.
curl -X POST http://localhost:10001/tradings --header "Content-Type: application/json" --header "Authorization: 718124" -d "{\"Insert\":false,\"WantId\":6,\"GiveId\":0,\"UserTradeWith\":\"kienboec\"}"
echo.
curl -X GET http://localhost:10001/tradings --header "Authorization: 926771"
echo.
curl -X GET http://localhost:10001/tradings --header "Authorization: 718124"
echo.
REM -------------------------------------------------- OWN TEST
echo --MTCG Logout TEST--
curl -X POST http://localhost:10001/logout --header "Content-Type: application/json" --header "Authorization: 718124" -d ""
echo.
curl -X POST http://localhost:10001/logout --header "Content-Type: application/json" --header "Authorization: 926771" -d ""
echo.
curl -X POST http://localhost:10001/logout --header "Content-Type: application/json" --header "Authorization: 227886" -d ""
echo.

REM --------------------------------------------------
echo end...

REM this is approx a sleep 
ping localhost -n 100 >NUL 2>NUL
@echo on