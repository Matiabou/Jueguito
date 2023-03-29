            int modo, movimiento, enemigo;
            bool necesitaEnemigo, juegoActivo = true;
            bool[] back = { false, false, false, false };
            jugador[] jugadores = new jugador[4];
            jugadores[0] = new jugador(); jugadores[1] = new jugador(); jugadores[2] = new jugador(); jugadores[3] = new jugador();
            jugador jugadorDef = new jugador();
            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                modo = ingresarEntero("Select mode\n1: 1 vs 1\n2: 2 vs 2");
                if (modo != 1 && modo != 2) Console.Clear(); Console.WriteLine("Choose: 1, 2");
            } while (modo != 1 && modo != 2);
            jugador.setModo(modo);
            if (modo != 2)
            {
                jugadores[2].setVidaDeterminada(-3000);
                jugadores[3].setVidaDeterminada(-3000);
            }
            Console.Clear();
            for (int i = 0; i < jugadores.Length; i++)
            {
                jugadores[i].setNombre(ingresarTexto("Introduce the name of the Player " + (i + 1)));
            }
            mostrarInstrucciones();
            foreach (var c in jugadores)
            {
                clase(c);
            }
            foreach (var c in jugadores)
            {
                c.elegirMovimientos();
            }
            foreach (var c in jugadores)
            {
                c.getMovimientos();
                presionarTecla();
            }
            while ((jugadores[0].getVida() > 0 || jugadores[1].getVida() > 0) && (jugadores[2].getVida() > 0 || jugadores[3].getVida() > 0) || jugadores[3].getVida() == -3000)
            {
                // turno jugador 1
                if (jugadores[0].getVida() > 0)
                {
                    movimiento = jugadores[0].preguntarMovimiento(jugadores[0], jugadores[1], jugadores[2], jugadores[3]);
                    necesitaEnemigo = verNecesidadEnemigo(movimiento);
                    if (modo == 2 && necesitaEnemigo)
                    {
                        do
                        {
                            Console.WriteLine($"Choose enemy:\n");
                            if (jugadores[2].getVida() > 0) Console.WriteLine($"3: {jugadores[2].getNombre()}\n");
                            if (jugadores[3].getVida() > 0) Console.WriteLine($"4: {jugadores[3].getNombre()}\n");
                            enemigo = ingresarEntero("\n\n5: Get back to choose a movement");
                            if (enemigo != 3 && enemigo != 4 && enemigo != 5) Console.WriteLine("You have to choose: 3, 4, 5");
                        } while (enemigo != 3 && enemigo != 4 && enemigo != 5);
                        if (enemigo == 5) back[0] = true;
                        else jugadorDef = procesarEnemigo(enemigo, jugadores[0], jugadores[1], jugadores[2], jugadores[3]);
                    }
                    else jugadorDef = jugadores[1];
                    Console.Clear();
                    if (!back[0]) jugadores[0].procesarMovimiento(jugadorDef, movimiento);
                    juegoActivo = verificarContinuidadJuego(jugadores);
                    if (!juegoActivo) break;
                }
                // turno jugador 3
                if (!back[0] && modo == 2 && jugadores[2].getVida() > 0)
                {
                    movimiento = jugadores[2].preguntarMovimiento(jugadores[0], jugadores[1], jugadores[2], jugadores[3]);
                    do
                    {
                        Console.WriteLine($"Choose enemy:\n");
                        if (jugadores[0].getVida() > 0) Console.WriteLine($"1: {jugadores[0].getNombre()}\n");
                        if (jugadores[1].getVida() > 0) Console.WriteLine($"2: {jugadores[1].getNombre()}\n");
                        enemigo = ingresarEntero("\n\n5: Get back to choose a movement");
                        if (enemigo != 1 && enemigo != 2 && enemigo != 5) Console.WriteLine("You have to choose: 1, 2, 5");
                    } while (enemigo != 1 && enemigo != 2 && enemigo != 5);
                    if (enemigo == 5) back[2] = true;
                    else jugadorDef = procesarEnemigo(enemigo, jugadores[0], jugadores[1], jugadores[2], jugadores[3]);
                    Console.Clear();
                    if (!back[2]) jugadores[2].procesarMovimiento(jugadorDef, movimiento);
                    juegoActivo = verificarContinuidadJuego(jugadores);
                    if (!juegoActivo) break;
                }
                // turno jugador 2
                if (!back[0] && !back[2] && jugadores[1].getVida() > 0)
                {
                    movimiento = jugadores[1].preguntarMovimiento(jugadores[0], jugadores[1], jugadores[2], jugadores[3]);
                    if (modo == 2)
                    {
                        do
                        {
                            Console.WriteLine($"Choose enemy:\n");
                            if (jugadores[2].getVida() > 0) Console.WriteLine($"3: {jugadores[2].getNombre()}\n");
                            if (jugadores[3].getVida() > 0) Console.WriteLine($"4: {jugadores[3].getNombre()}\n");
                            enemigo = ingresarEntero("\n\n5: Get back to choose a movement");
                            if (enemigo != 3 && enemigo != 4 && enemigo != 5) Console.WriteLine("You have to choose: 3, 4, 5");
                        } while (enemigo != 3 && enemigo != 4 && enemigo != 5);
                        if (enemigo == 5) back[1] = true;
                        jugadorDef = procesarEnemigo(enemigo, jugadores[0], jugadores[1], jugadores[2], jugadores[3]);
                    }
                    else jugadorDef = jugadores[0];
                    Console.Clear();
                    if (!back[1]) jugadores[1].procesarMovimiento(jugadorDef, movimiento);
                    juegoActivo = verificarContinuidadJuego(jugadores);
                    if (!juegoActivo) break;
                }
                // turno jugador 4
                if (!back[0] && !back[1] && !back[2] && !back[3] && modo == 2 && jugadores[3].getVida() > 0)
                {
                    movimiento = jugadores[3].preguntarMovimiento(jugadores[0], jugadores[1], jugadores[2], jugadores[3]);
                    do
                    {
                        Console.WriteLine($"Choose enemy:\n");
                        if (jugadores[0].getVida() > 0) Console.WriteLine($"1: {jugadores[0].getNombre()}\n");
                        if (jugadores[1].getVida() > 0) Console.WriteLine($"2: {jugadores[1].getNombre()}\n");
                        enemigo = ingresarEntero("\n5: Get back to choose a movement");
                        if (enemigo != 1 && enemigo != 2 && enemigo != 5) Console.WriteLine("You have to choose: 1, 2, 5");
                    } while (enemigo != 1 && enemigo != 2 && enemigo != 5);
                    if (enemigo == 5) back[3] = true;
                    jugadorDef = procesarEnemigo(enemigo, jugadores[0], jugadores[1], jugadores[2], jugadores[3]);
                    Console.Clear();
                    if (!back[3]) jugadores[3].procesarMovimiento(jugadorDef, movimiento);
                    juegoActivo = verificarContinuidadJuego(jugadores);
                    if (!juegoActivo) break;
                }
                for (int i = 0; i <= 3; i++) back[i] = false;
            }
            mostrarGanador(jugadores[0], jugadores[1], jugadores[2], jugadores[3], modo);
        
        static private int ingresarEntero(string mensaje)
        {
            int n = 0;
            Console.WriteLine(mensaje);
            do
            {
                try
                {
                    n = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    excepciones("FormatException");
                }
                catch (OverflowException)
                {
                    excepciones("OverflowException");
                }
                catch (Exception)
                {
                    excepciones("Exception");
                }
            } while (n == 0);

            return n;
        }
        static private bool verNecesidadEnemigo(int movimiento)
        {
            return movimiento != 5 && movimiento != 6;
        }
        private static void clase(jugador jugador)
        {
            do
            {
                jugador.setClase(ingresarEntero(jugador.getNombre() + "\n\nSelect class\n1: Tank (400 HP)\n2: Lucky (Probabilities duplicated)\n3: Cheater (6 Movements)"));
                Console.Clear();
                if (jugador.getClase() != 1 && jugador.getClase() != 2 && jugador.getClase() != 3) Console.WriteLine("You have to choose: 1, 2, 3");
            } while (jugador.getClase() != 1 && jugador.getClase() != 2 && jugador.getClase() != 3);
        }
        static public void excepciones(string excepcion)
        {
            switch (excepcion)
            {
                case "FormatException":
                    Console.WriteLine("The data introduced was not a valid numeric value");
                    Console.WriteLine("Introduce it again");
                    break;
                case "OverflowException":
                    Console.WriteLine("The number introduced has too much digits");
                    Console.WriteLine("Introduce it again");
                    break;
                case "Exception":
                    Console.WriteLine("An error has occurred");
                    Console.WriteLine("Introduce it again");
                    break;
            }
        }
        public static jugador procesarEnemigo(int n, jugador jugador1, jugador jugador2, jugador jugador3, jugador jugador4)
        {
            jugador jugDef = new jugador();
            switch (n)
            {
                case 1:
                    jugDef = jugador1;
                    break;
                case 2:
                    jugDef = jugador2;
                    break;
                case 3:
                    jugDef = jugador3;
                    break;
                case 4:
                    jugDef = jugador4;
                    break;
            }
            return jugDef;
        }
        static private string ingresarTexto(string mensaje)
        {
            string texto = "";
            bool while_ = true;
            Console.WriteLine(mensaje);
            do
            {
                try
                {
                    texto = Console.ReadLine();
                }
                catch (Exception)
                {
                    excepciones("Exception");
                    while_ = false;
                }
            } while (while_ == false);

            return texto;
        }
        public static void presionarTecla()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        private static void mostrarInstrucciones()
        {
            Console.Clear();
            Console.WriteLine("You will have to choose 4 movements to play with in the fight");
        }
        static private void mostrarGanador(jugador jugador1, jugador jugador2, jugador jugador3, jugador jugador4, int modo)
        {
            string final;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(jugador1.getNombre() + ": " + jugador1.getVida() + " HP");
            Console.WriteLine(jugador2.getNombre() + ": " + jugador2.getVida() + " HP");
            if (modo == 2)
            {
                Console.WriteLine(jugador3.getNombre() + ": " + jugador3.getVida() + " HP");
                Console.WriteLine(jugador4.getNombre() + ": " + jugador4.getVida() + " HP");
                Console.WriteLine();
                if (jugador1.getVida() <= 0 && jugador2.getVida() <= 0) Console.WriteLine("WINNER: TEAM 2");
                else Console.WriteLine("WINNER: TEAM 1");
            }
            else
            {
                Console.WriteLine();
                if (jugador1.getVida() <= 0) Console.WriteLine($"WINNER: {jugador2.getNombre()} (Player 2)");
                else Console.WriteLine($"WINNER: {jugador1.getNombre()} (Player 1)");
            }
            do
            {

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Type <<finish>> to finish");
                final = Console.ReadLine();

                Console.Clear();
            } while (final != "finish");

        }
        private static bool verificarContinuidadJuego(jugador[] jugadores)
        {      
            return (jugadores[0].getVida() > 0 || jugadores[1].getVida() > 0) && (jugadores[2].getVida() > 0 || jugadores[3].getVida() > 0) || jugadores[3].getVida() == -3000;
        }
    }
    