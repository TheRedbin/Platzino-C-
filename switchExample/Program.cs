// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

System.Random random = new System.Random();

int platziCoins = 0;
int num = 0;
string message = "";
string switchControl = "menu";
string respuesta = "";
int i = 0;
int restantes = 0;
int totalJugador = 0;
int totalDealer = 0;
int apuesta = 0;

//Blackjack, Juntar 21 pidiendo cartas o en caso de tener menos
//de 21 igual tener mayor puntuación que el dealer

while (true)
{
    Console.WriteLine("Welcome al P L A T Z I N O");
    Console.WriteLine("¿Cuántos PlatziCoins deseas? \n" +
    "Ingresa un número entero \n" +
    "Recuerda que necesitas gastar almenos 1 por ronda.");
    platziCoins = int.Parse(Console.ReadLine());

    i = 0;

    while (i <= platziCoins)
    {
        switch (switchControl)
        {
            case "menu":
                Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
                Console.WriteLine("Escriba '21' para jugar al 21");
                switchControl = Console.ReadLine();
                break;

            case "21":
                for (i = 1; i <= platziCoins; i++)
                {
                    totalJugador = 0;
                    totalDealer = 0;
                    apuesta = 0;

                    //Lee el valor de la apuesta
                    Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
                    Console.WriteLine("¿De cuantos PlatziCoins será tu apuesta?");
                    apuesta = int.Parse(Console.ReadLine());

                    if (apuesta <= platziCoins && apuesta > 0)
                    {

                        do
                        {
                            num = random.Next(1, 12);
                            totalJugador = totalJugador + num;
                            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
                            Console.WriteLine("Toma tu carta, jugador");
                            Console.WriteLine($"Te salió el número: {num}");
                            Console.WriteLine($"Total de las cartas: {totalJugador}");
                            Console.WriteLine("¿Deseas otra carta?");
                            respuesta = Console.ReadLine().ToLower();

                        } while (respuesta == "yes" || respuesta == "si");

                        totalDealer = random.Next(14, 23);
                        Console.WriteLine($"El dealer tiene: {totalDealer}");

                        //Cuando se tiene más puntaje que el dealer y este puntaje es menor a 21
                        //Se gana
                        if (totalJugador > totalDealer && totalJugador <= 21)
                        {
                            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
                            message = "Venciste al dealer, felicidades";
                            platziCoins -= apuesta;
                            apuesta = apuesta * 2;
                            platziCoins += apuesta;
                            restantes = platziCoins - i;
                            Console.WriteLine($"La casa te paga {apuesta} PlatziCoins");
                            Console.WriteLine($"Tus PlatziCoins restantes son: {restantes}");
                        }

                        //Cuando el jugador tiene menor o igual a 21 y el dealer tiene mayor a 21
                        //Se gana
                        else if (totalJugador <= 21 && totalDealer > 21)
                        {
                            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
                            message = "Ganaste vs el dealer, el dealer se pasó de 21";
                            platziCoins -= apuesta;
                            apuesta = apuesta * 2;
                            platziCoins += apuesta;
                            restantes = platziCoins - i;
                            Console.WriteLine($"La casa te paga {apuesta} PlatziCoins");
                            Console.WriteLine($"Tus PlatziCoins restantes son: {restantes}");
                        }

                        //Cuando ambos sacan el mismo puntaje
                        //Se empata
                        else if (totalJugador == totalDealer || (totalJugador > 21 && totalDealer > 21))
                        {
                            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
                            message = "Empataste con el dealer, nadie gana";
                            i--;
                            restantes = platziCoins - i;
                            Console.WriteLine($"Tus PlatziCoins restantes son: {restantes}");
                        }

                        //Si jugador pasa de 21 y dealer tiene menor o igual a 21
                        //Se pierde
                        else if (totalJugador > 21 && totalDealer <= 21)
                        {
                            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
                            message = "Perdiste vs el dealer, te pasaste de 21";
                            platziCoins -= apuesta;
                            restantes = platziCoins - i;
                            Console.WriteLine($"Tus PlatziCoins restantes son: {restantes}");
                        }

                        //Cuando el jugador tiene menos que el dealer y el dealer tiene menor o igual a 21
                        //Se pierde
                        else if (totalJugador < totalDealer && totalDealer <= 21)
                        {
                            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
                            message = "Perdiste vs el dealer, lo siento";
                            platziCoins -= apuesta;
                            restantes = platziCoins - i;
                            Console.WriteLine($"Tus PlatziCoins restantes son: {restantes}");

                        }

                        //Si ninguna de las anteriores condiciones se cumplen
                        else
                        {
                            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
                            i--;
                            message = "Condicion no válida";
                        }

                        //Cuando cualquiera de estas condiciones se cumple
                        Console.WriteLine(message);
                        Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
                        Console.WriteLine("Oprima enter para volver a jugar");
                        Console.ReadLine();
                        switchControl = "menu";
                    }
                    //Cuando se intenta apostar una cantidad mayor a la que tiene
                    else
                    {
                        Console.WriteLine($"PlatziCoins insuficientes, tu PlatziCoins son: {platziCoins} \n" +
                            $"Y tu apuesta es de: {apuesta}");
                        i--;
                        restantes = platziCoins - i;
                        Console.WriteLine($"Tus PlatziCoins restantes son: {restantes}");
                    }

                }
                break;

            //Cuando no se ingresa el valor de ningun case
            default:
                Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
                Console.WriteLine("Valor ingresado no válido en el c a s i n o");
                switchControl = "menu";
                break;
        }
    }
    Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
    Console.WriteLine("Ya no tienes PlatziCoins \n" +
        "Oprime enter para volver a empezar");
    Console.ReadLine();
    Console.Clear();
}