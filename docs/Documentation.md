Ludo user stories

1. Som spelare slår jag med tärningar och får gå antal prickar på den med min pjäs
2. Som spelare kan man gå med i ett spel som har mindre än 4 spelare
3. Som spelare ska jag flytta pjäsen ett varv innan den kommer i mål.
4. Som spelare har jag fyra pjäser att gå i mål med
5. Som spelare vinner jag om jag har gått i mål med mina 4 pjäser
6. Som spelar får jag slå igen om jag slagit en 6:a med tärningen


Beskrivning av API

HTTP                                GET                     POST            PUT                           DELETE
/ludo                               Lista av spelen         Skapa nytt    
/ludo/{gameId}                      Info om spec. spel                      Ändra placering på pjäs       Ta bort spel
/ludo/{gameId}/players              Lista med alla          Lägg till ny   
                                    spelare i spec.spel     spelare
/ludo/{gameId}/players/{playerId}   Detaljerat om spelaren                  Ändra namn/färg på spelaren   Ta bort spelare               

