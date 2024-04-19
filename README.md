
# Warcraft-Realms-Rise-of-Azeroth
Juego de cartas 
Proyecto de ciencias de la computacion, Ian Carlos Aguirre Gonzalez.
Por favor respetar la privacidad de este y el esfuerzo y sacrificio con el que fue creado.

## Contacto
https://t.me/Ian_Carlos101 Telegram.
+53 55301007 Numero de telefono.
iancarlosaguirre@gmail.com Gmail.
## Comenzando 🚀

Warcraft Realm: Rise of Azeroth es un juego de cartas donde cada jugador tiene acceso a un deck, una fila para asedio, una fila para unidades de combate cuerpo a cuerpo (melee), una fila para unidades de combate a distancia (rango), y zonas de aumento y clima compartidas. En cada turno, los jugadores pueden colocar una carta, pasar, o usar el efecto del héroe. Al pasar, el jugador renuncia a jugar durante toda la ronda hasta que el oponente haga lo mismo.

Al finalizar una ronda, se verifica el poder total de ambos jugadores. El ganador reduce en 1 vida al oponente. En caso de empate, ambos jugadores pierden 1 vida. El primer jugador en quedarse con 0 vidas pierde la partida.

Las cartas tienen efectos únicos que se activan al ser invocadas. Se dividen en dos facciones: Icecrown y Alianza. La facción Icecrown está inspirada en la mítica banda Ciudadela de la Corona de Hielo de World Of Warcraft, liderada por el Rey Examine, quien utiliza su ejército de la plaga para derrotar a sus oponentes. Por otro lado, la facción Alianza, dirigida por el Rey Varian, lucha hasta el final para vencer a la plaga.

Además de las cartas regulares, existen cartas especiales, de oro y platino, que tienen efectos únicos y pueden ser determinantes para decidir el ganador al final de cada ronda.

¡Suerte en tu batalla! Elige sabiamente tus movimientos y recuerda que siempre hay esperanzas de vencer. Confía en el corazón de las cartas y lucha por Azeroth, guerrero

## Scripts

Card.cs: Define los Scriptable Objects de las cartas.

CardDisplay.cs: Convierte un objeto Card en un elemento visual dentro del juego.

DataScriptable.cs: Contiene una lista de Scriptable Objects de cartas para almacenarlas como una base de datos.

Deck.cs: Crea el mazo donde se almacenan las cartas con las que se jugará. Dependiendo de la base de datos, puede haber dos mazos, uno para cada una.

Decktohand.cs: Instancia las cartas del mazo a través de un botón para que aparezcan en la mano del jugador.

Displaytext.cs: Muestra textos en el juego.

Dragable.cs: Permite mover las cartas de un lugar a otro.

Drop1.cs: Acopla las cartas que se están moviendo, verifica el tipo de carta para asegurarse de que solo se puedan colocar en un lugar adecuado y llama a métodos como el de efecto de las cartas y el de cambio de turno.

GameManager.cs: Es el script principal que controla los puntos, la victoria por ronda y la victoria final. También contiene un método spell que se encarga de aplicar los efectos de las cartas según su ID.

Limit.cs: Verifica que no se exceda el límite de la cantidad de cartas que se puede tener en ciertos paneles.

MainMenu.cs: Controla la escena del menú.

PlaySound.cs: Reproduce sonidos cuando es llamado, tiene dos sonidos, uno para cada tipo de movimiento dependiendo del jugador.

TextAdapter.cs: Útil para cambiar el formato de los textos.

TotalAtaccker.cs: Controla los puntos de los paneles para mostrarlos visualmente.

TurnSystem.cs: Controla los turnos y las rondas del juego.


##
────────────────────────────────
───────────────██████████───────
──────────────████████████──────
──────────────██────────██──────
──────────────██▄▄▄▄▄▄▄▄▄█──────
──────────────██▀███─███▀█────── 
█─────────────▀█────────█▀──────
██──────────────────█───────────
─█──────────────██──────────────
█▄────────────████─██──████
─▄███████████████──██──██████ ──
────█████████████──██──█████████
─────────────████──██─█████──███
──────────────███──██─█████──███
──────────────███─────█████████
──────────────██─────████████▀
────────────────██████████
────────────────██████████
─────────────────████████
──────────────────██████████▄▄
────────────────────█████████▀
─────────────────────████──███
────────────────────▄████▄──██
────────────────────██████───▀
────────────────────▀▄▄▄▄▀