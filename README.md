# AshxConverter

AshxConverter is een C#-applicatie die het eenvoudig maakt om verschillende bestandstypen te converteren met behulp van een flexibele en uitbreidbare structuur. Deze tool is ideaal voor ontwikkelaars die met ASP.NET werken en regelmatig geconfronteerd worden met de noodzaak om data te converteren of te exporteren via .ashx handlers.

## Features

- Ondersteunt conversie van en naar diverse bestandsformaten (bijv. XML, JSON, CSV)
- Eenvoudig uit te breiden met nieuwe conversiemodules
- Gebruiksvriendelijke command-line interface
- Snel, efficiënt en geschikt voor batchverwerking
- Ontwikkeld in C#, volledig open source

## Installatie

1. Clone deze repository:
   ```bash
   git clone https://github.com/Zaibatsu89/AshxConverter.git
   ```
2. Open het project in Visual Studio of een andere C# IDE.
3. Herstel de benodigde NuGet-packages.
4. Bouw het project.

## Gebruik

1. Start de applicatie via de command line:

   ```bash
   AshxConverter.exe -i "<input-bestand>" -o "<output-bestand>" --from "<bronformaat>" --to "<doelformaat>"
   ```

2. Voorbeeld:
   ```bash
   AshxConverter.exe -i "voorbeeld.xml" -o "voorbeeld.json" --from xml --to json
   ```

### Opties

- `-i`, `--input` : Pad naar het bronbestand (verplicht)
- `-o`, `--output` : Pad voor het geconverteerde bestand (verplicht)
- `--from` : Bronformaat (bijv. xml, json, csv) (verplicht)
- `--to` : Doelformaat (bijv. xml, json, csv) (verplicht)

## Uitbreiden

Nieuwe conversies kunnen eenvoudig worden toegevoegd door een nieuwe module te implementeren volgens de bestaande interface en deze te registreren in het project.

## Bijdragen

Bijdragen zijn welkom! Open een issue voor feedback of feature requests, of maak een pull request voor verbeteringen.

## Licentie

Dit project is gelicenseerd onder de MIT-licentie.

## Contact

Voor vragen of feedback, maak gerust een issue aan of neem contact op via [Zaibatsu89](https://github.com/Zaibatsu89).
