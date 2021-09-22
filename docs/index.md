## SMS Teknik Developer Documentation

# Implementasjonsveiledning

Denne veiledningen tar for seg utvalgte områder for integrasjon mot SMS Teknik. Det henvises til offisiell dokumentasjon
for mer utfyllende informasjon.

SMS Teknik tilbyr flere metoder for utsendelse av SMS basert på ulike teknologier og metodikker. I denne veiledningen
går vi innom de tre vanligste metodene. I tillegg ser vi på hvordan vi kan motta leveransestatus på utsendte meldinger,
samt gjennomgang av flere andre nyttige funksjoner som plattformen tilbyr. De fleste av prinsippene er demonstrert med
[kodeeksempler](CodeExamples.html).

Velg først hvilket grensesnitt du ønsker å benytte ved å gå gjennom oppsummeringen under. Du kan deretter klikke deg inn
på det aktuelle grensesnittet for å få mer utfyllende informasjon.

# Prerequisites

Før du begynner må du få utdelt id, brukernavn og passord av SMS Teknik. Da vil da også få tilgang til offisiell
dokumentasjon.

I tillegg til brukernavn og passord vil du også få utlevert en token til bruk ved Basic Authentication. Vi anbefaler
alltid at Basic Authentication i header benyttes fremfor å legge brukernavn og passord som parametere i URL.

# Grensesnitt for utsendelse av SMS

Det finnes flere ulike grensesnitt (API-er) for å sende ut SMS. Vurder hvilket grensesnitt som passer best for ditt
prosjekt, og klikk deg videre inn for mer utfyllende informasjon.

## .Net Web Service (SOAP/XML)

Klassisk SOAP/XML Web Service for utsendelse av SMS. Inneholder metode for både enkel og avansert utsendelse av SMS.

Web Service kan benyttes som klassisk web service (med proxy), eller ved å utføre HTTP POST mot et endepunkt.

[Les mer](Guide-WS.html)

## XML over HTTP

Dette prinsippet baserer seg på at man genererer et XML objekt som man poster (HTTP POST) til et endepunkt (URL). XML
objektet inneholder alle parameterne for å sende SMS, som f.eks. mottakere, avsendere, etc. Dette er en enkel teknikk
som alle plattformer kan benytte.

[Les mer](Guide-XmlHttp.html)

## HTTP GET wrapper (parametere i URL)

Dette prinsippet baserer seg på at man kaller en URL med parametere (query string) med instrukser for SMS som skal
sendes.

Denne metoden er svært enkel å implementere, men har enkelte begrensninger som at den støtter ikke leveranserapporter
eller flere mottakere.

[Les mer](Guide-HttpGetWrapper.html)

## Andre grensesnitt

I tillegg tilbys også følgende mindre aktuelle grensesnitt. Disse grensesnittene er ikke omhandlet ytterligere i denne
veiledningen, men du kan lese mer om den i offisiell dokumentasjon og på Wikipedia.

- Short Message Peer-to-Peer (SMPP) - Wikipedia
- Universal Computer Protocol (UCP) - Wikipedia
- Computer Interface to Message Distribution (CIMD) - Wikipedia

See [sammenligning](comparison.html) for sammenligning av de ulike grensesnittene.

# Leveranserapporter

Plattformen tilbyr også mulighet for å få leveranserapporter, det vil si status om meldingen fra den blir sendt frem til
den når mottaker eller av ulike årsaker har feilet.

Leveransestatus kan enten oppdrives som push eller pull. Push vil si at statusrapporter blir sendt til oss (som http
callback, e-post, etc.) når status har endret seg, mens pull vil si at vi må kalle et endepunkt for å motta gjeldende
status.

[Les mer](Guide-DeliveryReports.html)

# Annet nyttig

## Sjekke credits

Man kan kalle et endepunkt for å returnere antall credits tilgjengelig på konto. Dette gjelder imidlertid kun dersom
konto er satt opp med forhåndsbetalte credits. 
Sjekk kodeeksempel for [Web Service](Guide-WS.html) eller for [XML over HTTP](Guide-XmlHttp.html) 
for mer informasjon om hvordan dette fungerer.

## Slette meldinger i køen

Dersom man har sendt instrukser om at en melding skal sendes frem i tid, men deretter ønsker å avbryte, kan man kalle et
endepunkt med meldingens ID (som man mottok ved sending) for å kansellere utsendelsen.
Sjekk kodeeksempel for [Web Service](Guide-WS.html) eller for [XML over HTTP](Guide-XmlHttp.html)
for mer informasjon om hvordan dette fungerer.

# Offisiell dokumentasjon

Logg inn på medlemsområdet for å laste ned offisiell dokumentasjon:

[Offisiell dokumentasjon](https://www.smsteknik.se/member/login/)