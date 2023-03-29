class jugador
    {
        private string nombre;
        private int clase, vida = 200, vidaMaxima = 200;
        private static int modo;
        private int[] movimientosEntero = new int[4], probabilidades = new int[9], daños = new int[9];
        private string[] movimientos = new string[4], movimientosDisponibles = new string[9];
        private bool[] protect = new bool[2], poison = new bool[3], bleed = new bool[3];
        public jugador()
        {
            probabilidades[0] = 100; probabilidades[1] = 45; probabilidades[2] = 30; probabilidades[3] = 3; probabilidades[4] = 15;
            probabilidades[5] = 40; probabilidades[6] = 40; probabilidades[7] = 40; probabilidades[8] = 100;
            daños[0] = 20; daños[1] = 40; daños[2] = 60; daños[3] = 1000; daños[4] = 80; daños[5] = 0; daños[6] = 10; daños[7] = 15; daños[8] = 15;
            movimientosDisponibles[0] = $"1: BITE ({probabilidades[0]}%, 20 PHYSICAL DAMAGE)"; movimientosDisponibles[1] = $"2: SLAY ({probabilidades[1]}%, 40 PHYSICAL DAMAGE)";
            movimientosDisponibles[2] = $"3: SMASH ({probabilidades[2]}%, 60 PHYSICAL DAMAGE)"; movimientosDisponibles[3] = $"4: KILL ({probabilidades[3]}%, ONESHOT)";
            movimientosDisponibles[4] = $"5: HEAL ({probabilidades[4]}%, HEAL 80 HP)"; movimientosDisponibles[5] = $"6: PROTECT ({probabilidades[5]}%, PROTECTS FROM PHYSICAL DAMAGE AND BLEEDING 2 TURNS)";
            movimientosDisponibles[6] = $"7: POISON ({probabilidades[6]}%, 10 DAMAGE 3 TURNS, IGNORES PROTECTION)"; movimientosDisponibles[7] = $"8: BLEED ({probabilidades[7]}%, 15 DAMAGE 3 TURNS, BLOCKED BY PROTECTION)";
            movimientosDisponibles[8] = $"9: BOW ({probabilidades[8]}%, 15 RANGED DAMAGE)";
            poison[0] = false; poison[1] = false; poison[2] = false;
            bleed[0] = false; bleed[1] = false; bleed[2] = false;
            protect[0] = false; protect[1] = false;
        }
        public void setProtectPoisonBleed(string protectPoisonBleed, int posicion, bool activacion)
        {
            switch (protectPoisonBleed)
            {
                case "Protect":
                    protect[posicion] = activacion;
                    break;
                case "Poison":
                    poison[posicion] = activacion;
                    break;
                case "Bleed":
                    bleed[posicion] = activacion;
                    break;
            }
        }
        public void setClase(int clase)
        {
            this.clase = clase;
            switch (clase)
            {
                case 1:
                    vida = 400;
                    vidaMaxima = 400;
                    break;
                case 2:
                    for (int i = 0; i <= 8; i++)
                    {
                        probabilidades[i] *= 2;
                        if (probabilidades[i] > 100) probabilidades[i] = 100;
                    }
                    movimientosDisponibles[0] = "1: BITE (" + probabilidades[0] + "%, 20 PHYSICAL DAMAGE)"; movimientosDisponibles[1] = "2: SLAY (" + probabilidades[1] + "%, 40 PHYSICAL DAMAGE)";
                    movimientosDisponibles[2] = "3: SMASH (" + probabilidades[2] + "%, 60 PHYSICAL DAMAGE)"; movimientosDisponibles[3] = "4: KILL (" + probabilidades[3] + "%, ONESHOT)";
                    movimientosDisponibles[4] = "5: HEAL (" + probabilidades[4] + "%, HEAL 80 HP)"; movimientosDisponibles[5] = "6: PROTECT (" + probabilidades[5] + "%, PROTECTS FROM PHYSICAL DAMAGE AND BLEEDING 2 TURNS)";
                    movimientosDisponibles[6] = "7: POISON (" + probabilidades[6] + "%, 10 DAMAGE 3 TURNS, IGNORES PROTECTION)"; movimientosDisponibles[7] = "8: BLEED (" + probabilidades[7] + "%, 15 DAMAGE 3 TURNS, BLOCKED BY PROTECTION)";
                    movimientosDisponibles[8] = "9: BOW (" + probabilidades[8] + "%, 15 RANGED DAMAGE)";
                    break;
                case 3:
                    movimientosEntero = new int[6];
                    movimientos = new string[6];
                    break;
            }
        }
        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public static void setModo(int modo)
        {
            jugador.modo = modo;
        }
        public void setVida(int vida, bool dañoCura)
        {
            if (dañoCura) this.vida += vida;
            else this.vida -= vida;
            ;
        }
        public int getModo()
        {
            return modo;
        }
        public void setVidaDeterminada(int vida)
        {
            this.vida = vida;
        }
        public bool getProtectPoisonBleed(string protectPoisonBleed, int posicion)
        {
            switch (protectPoisonBleed)
            {
                case "Protect":
                    return protect[posicion];
                case "Poison":
                    return poison[posicion];
                case "Bleed":
                    return bleed[posicion];
                default:
                    return false;
            }
        }
        public int getMovimientosEntero(int posicion)
        {
            return movimientosEntero[posicion];
        }
        public string getNombre()
        {
            return nombre;
        }
        public int getClase()
        {
            return clase;
        }
        public int getVida()
        {
            return vida;
        }
        public void elegirMovimientos()
        {
            int max_Mov = 9, movimiento = 0;
            for (int i = 0; i <= movimientos.Length - 1; i++)
            {
                Console.Write(nombre);
                switch (clase)
                {
                    case 1:
                        mostrarResultado("TANK");
                        break;
                    case 2:
                        mostrarResultado("LUCKY");
                        break;
                    case 3:
                        mostrarResultado("CHEATER");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("CHOOSE YOUR MOVEMENT " + (i + 1));
                foreach (string i2 in movimientosDisponibles) Console.WriteLine(i2);
                Console.WriteLine();
                foreach (string i3 in movimientos) Console.WriteLine(i3);
                switch (movimientos.Length)
                {
                    case 4:
                        do
                        {
                            movimiento = leerMovimiento();
                            if (movimiento > max_Mov || movimiento < 1) Console.WriteLine("You introduced a number out of range\nIntroduce your movement again");

                            if ((movimientosEntero[0] == movimiento || movimientosEntero[1] == movimiento || movimientosEntero[2] == movimiento || movimientosEntero[3] == movimiento) && movimiento != 0)
                            {
                                Console.WriteLine("Your movement is repeated");
                                Console.WriteLine("Introduce another movement");
                            }
                        } while (movimiento > max_Mov || movimiento < 1 || movimientosEntero[0] == movimiento || movimientosEntero[1] == movimiento || movimientosEntero[2] == movimiento || movimientosEntero[3] == movimiento);
                        break;
                    case 6:
                        do
                        {
                            movimiento = leerMovimiento();
                            if (movimiento > max_Mov || movimiento < 1) Console.WriteLine("You introduced a number out of range\nIntroduce your movement again");
                            if ((movimientosEntero[0] == movimiento || movimientosEntero[1] == movimiento || movimientosEntero[2] == movimiento || movimientosEntero[3] == movimiento || movimientosEntero[4] == movimiento) && movimiento != 0)
                            {
                                Console.WriteLine("Your movement is repeated");
                                Console.WriteLine("Introduce another movement");
                            }
                        } while (movimiento > max_Mov || movimiento < 1 || movimientosEntero[0] == movimiento || movimientosEntero[1] == movimiento || movimientosEntero[2] == movimiento || movimientosEntero[3] == movimiento || movimientosEntero[4] == movimiento);
                        break;
                }
                movimientosEntero[i] = movimiento;
                movimientos[i] = movimientosDisponibles[movimiento - 1];
                Console.Clear();
            }
            ordenarMovimientos();
        }
        public void procesarMovimiento(jugador jugadorDef, int movimiento)
        {
            int probabilidad;
            Random r = new Random();

            probabilidad = r.Next(1, 101);
            switch (movimiento)
            {
                case 1:
                    if (!jugadorDef.getProtectPoisonBleed("Protect", 0))
                    {
                        if (probabilidad <= probabilidades[0])
                        {
                            jugadorDef.setVida(daños[0], false);
                            mostrarResultado("SUCCESS");
                        }
                        else mostrarResultado("FAIL");
                    }
                    else mostrarResultado("DODGED");
                    break;
                case 2:
                    if (!jugadorDef.getProtectPoisonBleed("Protect", 0))
                    {
                        if (probabilidad <= probabilidades[1])
                        {
                            mostrarResultado("SUCCESS");
                            jugadorDef.setVida(daños[1], false);
                        }
                        else
                        {
                            mostrarResultado("FAIL");
                        }
                    }
                    else
                    {
                        mostrarResultado("DODGED");
                    }
                    break;
                case 3:
                    if (!jugadorDef.getProtectPoisonBleed("Protect", 0))
                    {
                        if (probabilidad <= probabilidades[2])
                        {
                            mostrarResultado("SUCCESS");
                            jugadorDef.setVida(daños[2], false);
                        }
                        else
                        {
                            mostrarResultado("FAIL");
                        }
                    }
                    else
                    {
                        mostrarResultado("DODGED");
                    }

                    break;
                case 4:
                    if (!jugadorDef.getProtectPoisonBleed("Protect", 0))
                    {
                        if (probabilidad <= probabilidades[3])
                        {
                            mostrarResultado("SUCCESS");
                            jugadorDef.setVida(daños[3], false);
                        }
                        else mostrarResultado("FAIL");
                    }
                    else mostrarResultado("DODGED");
                    break;
                case 5:
                    if (probabilidad <= probabilidades[4])
                    {
                        mostrarResultado("SUCCESS");
                        setVida(daños[4], true);
                        if (getVida() > vidaMaxima) setVidaDeterminada(vidaMaxima);
                    }
                    else mostrarResultado("FAIL");
                    break;
                case 6:
                    if (probabilidad <= probabilidades[5])
                    {
                        mostrarResultado("SUCCESS");
                        setProtectPoisonBleed("Protect", 0, true);
                        setProtectPoisonBleed("Protect", 1, false);
                    }
                    else mostrarResultado("FAIL");
                    break;
                case 7:
                    if (probabilidad <= probabilidades[6])
                    {
                        mostrarResultado("SUCCESS");
                        jugadorDef.setProtectPoisonBleed("Poison", 0, true);
                        jugadorDef.setProtectPoisonBleed("Poison", 1, false);
                        jugadorDef.setProtectPoisonBleed("Poison", 2, false);
                    }
                    else mostrarResultado("FAIL");
                    break;
                case 8:
                    if (probabilidad <= probabilidades[7])
                    {
                        mostrarResultado("SUCCESS");
                        jugadorDef.setProtectPoisonBleed("Bleed", 0, true);
                        jugadorDef.setProtectPoisonBleed("Bleed", 1, false);
                        jugadorDef.setProtectPoisonBleed("Bleed", 2, false);
                    }
                    else mostrarResultado("FAIL");
                    break;
                case 9:
                    jugadorDef.setVida(daños[8], false);
                    mostrarResultado("SUCCESS");
                    break;
            }
            avanceTurno(jugadorDef);
        }
        private void ordenarMovimientos()
        {
            string movimientoTransitorio;
            int movimientoTransitorio_;
            switch (movimientosEntero.Length)
            {
                case 4:
                    do
                    {
                        for (int i = movimientosEntero.Length - 1; i >= 1; i--)
                        {
                            if (movimientosEntero[i] < movimientosEntero[i - 1])
                            {
                                movimientoTransitorio = movimientos[i];
                                movimientos[i] = movimientos[i - 1];
                                movimientos[i - 1] = movimientoTransitorio;
                                movimientoTransitorio_ = movimientosEntero[i];
                                movimientosEntero[i] = movimientosEntero[i - 1];
                                movimientosEntero[i - 1] = movimientoTransitorio_;
                            }
                        }
                    } while (movimientosEntero[0] > movimientosEntero[1] || movimientosEntero[1] > movimientosEntero[2] || movimientosEntero[2] > movimientosEntero[3]);
                    break;
                case 6:
                    do
                    {
                        for (int i = movimientosEntero.Length - 1; i >= 1; i--)
                        {
                            if (movimientosEntero[i] < movimientosEntero[i - 1])
                            {
                                movimientoTransitorio = movimientos[i];
                                movimientos[i] = movimientos[i - 1];
                                movimientos[i - 1] = movimientoTransitorio;
                                movimientoTransitorio_ = movimientosEntero[i];
                                movimientosEntero[i] = movimientosEntero[i - 1];
                                movimientosEntero[i - 1] = movimientoTransitorio_;
                            }
                        }
                    } while (movimientosEntero[0] > movimientosEntero[1] || movimientosEntero[1] > movimientosEntero[2] || movimientosEntero[2] > movimientosEntero[3]
                             || movimientosEntero[3] > movimientosEntero[4] || movimientosEntero[4] > movimientosEntero[5]);
                    break;
            }

        }
        public int preguntarMovimiento(jugador jugador1, jugador jugador2, jugador jugador3, jugador jugador4)
        {
            int movimiento;
            Console.WriteLine();
            Console.WriteLine(nombre + "'S TURN");
            Console.WriteLine();
            mostrarEstado(jugador1, jugador2, jugador3, jugador4);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("CHOOSE:");
            getMovimientos();
            Console.WriteLine();
            if (clase != 3)
            {
                do
                {
                    movimiento = leerMovimiento();
                    if (movimiento != 0 && movimiento != movimientosEntero[0] && movimiento != movimientosEntero[1] &&
                        movimiento != movimientosEntero[2] && movimiento != movimientosEntero[3])
                    {
                        Console.WriteLine("Your chosen movement does not match with available movements");
                        Console.WriteLine("Introduce your movement again");
                    }
                } while (movimiento != movimientosEntero[0] && movimiento != movimientosEntero[1] && movimiento != movimientosEntero[2] && movimiento != movimientosEntero[3]);
            }
            else
            {
                do
                {
                    movimiento = leerMovimiento();
                    if (movimiento != 0 && movimiento != movimientosEntero[0] && movimiento != movimientosEntero[1] &&
                        movimiento != movimientosEntero[2] && movimiento != movimientosEntero[3] &&
                        movimiento != movimientosEntero[4] && movimiento != movimientosEntero[5])
                    {
                        Console.WriteLine("Your chosen movement does not match with available movements");
                        Console.WriteLine("Introduce your movement again");
                    }
                } while (movimiento != movimientosEntero[0] && movimiento != movimientosEntero[1] &&
                movimiento != movimientosEntero[2] && movimiento != movimientosEntero[3] &&
                movimiento != movimientosEntero[4] && movimiento != movimientosEntero[5]);
            }
            return movimiento;
        }
        public void mostrarEstado(jugador jugador1, jugador jugador2, jugador jugador3, jugador jugador4)
        {
            Console.Write(jugador1.getNombre() + ": " + jugador1.getVida() + " HP");
            switch (jugador1.getClase())
            {
                case 1:
                    mostrarResultado("TANK");
                    break;
                case 2:
                    mostrarResultado("LUCKY");
                    break;
                case 3:
                    mostrarResultado("CHEATER");
                    break;
            }
            if (jugador1.getProtectPoisonBleed("Protect", 0)) mostrarResultado("PROTECTED");
            if (jugador1.getProtectPoisonBleed("Poison", 0)) mostrarResultado("POISONED");
            if (jugador1.getProtectPoisonBleed("Bleed", 0)) mostrarResultado("BLEEDING");
            Console.WriteLine();
            Console.Write(jugador2.getNombre() + ": " + jugador2.getVida() + " HP");
            switch (jugador2.getClase())
            {
                case 1:
                    mostrarResultado("TANK");
                    break;
                case 2:
                    mostrarResultado("LUCKY");
                    break;
                case 3:
                    mostrarResultado("CHEATER");
                    break;
            }
            if (jugador2.getProtectPoisonBleed("Protect", 0)) mostrarResultado("PROTECTED");
            if (jugador2.getProtectPoisonBleed("Poison", 0)) mostrarResultado("POISONED");
            if (jugador2.getProtectPoisonBleed("Bleed", 0)) mostrarResultado("BLEEDING");
            Console.WriteLine();
            if (modo == 2)
            {
                Console.Write(jugador3.getNombre() + ": " + jugador3.getVida() + " HP");
                switch (jugador3.getClase())
                {
                    case 1:
                        mostrarResultado("TANK");
                        break;
                    case 2:
                        mostrarResultado("LUCKY");
                        break;
                    case 3:
                        mostrarResultado("CHEATER");
                        break;
                }
                if (jugador3.getProtectPoisonBleed("Protect", 0)) mostrarResultado("PROTECTED");
                if (jugador3.getProtectPoisonBleed("Poison", 0)) mostrarResultado("POISONED");
                if (jugador3.getProtectPoisonBleed("Bleed", 0)) mostrarResultado("BLEEDING");
                Console.WriteLine();
                Console.Write(jugador4.getNombre() + ": " + jugador4.getVida() + " HP");
                switch (jugador4.getClase())
                {
                    case 1:
                        mostrarResultado("TANK");
                        break;
                    case 2:
                        mostrarResultado("LUCKY");
                        break;
                    case 3:
                        mostrarResultado("CHEATER");
                        break;
                }
                if (jugador4.getProtectPoisonBleed("Protect", 0)) mostrarResultado("PROTECTED");
                if (jugador4.getProtectPoisonBleed("Poison", 0)) mostrarResultado("POISONED");
                if (jugador4.getProtectPoisonBleed("Bleed", 0)) mostrarResultado("BLEEDING");
            }
        }
        public static int leerMovimiento()
        {
            int movimiento;
            try
            {
                movimiento = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                excepciones("FormatException");
                movimiento = 0;
            }
            catch (OverflowException)
            {
                excepciones("OverflowException");
                movimiento = 0;
            }
            catch (Exception)
            {
                excepciones("Exception");
                movimiento = 0;
            }
            return movimiento;
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
        public void avanceTurno(jugador jugadorDef)
        {
            if (jugadorDef.getProtectPoisonBleed("Bleed", 0))
            {
                if (!jugadorDef.getProtectPoisonBleed("Protect", 0)) jugadorDef.setVida(15, false);
                if (jugadorDef.getProtectPoisonBleed("Bleed", 1))
                {
                    if (jugadorDef.getProtectPoisonBleed("Bleed", 2))
                    {
                        jugadorDef.setProtectPoisonBleed("Bleed", 0, false);
                        jugadorDef.setProtectPoisonBleed("Bleed", 1, false);
                        jugadorDef.setProtectPoisonBleed("Bleed", 2, false);
                    }
                    else jugadorDef.setProtectPoisonBleed("Bleed", 2, true);
                }
                else jugadorDef.setProtectPoisonBleed("Bleed", 1, true);
            }
            if (jugadorDef.getProtectPoisonBleed("Protect", 0))
            {
                if (jugadorDef.getProtectPoisonBleed("Protect", 1))
                {
                    jugadorDef.setProtectPoisonBleed("Protect", 0, false);
                    jugadorDef.setProtectPoisonBleed("Protect", 1, false);
                }
                else jugadorDef.setProtectPoisonBleed("Protect", 1, true);
            }
            if (jugadorDef.getProtectPoisonBleed("Poison", 0))
            {
                jugadorDef.setVida(10, false);
                if (jugadorDef.getProtectPoisonBleed("Poison", 1))
                {
                    if (jugadorDef.getProtectPoisonBleed("Poison", 2))
                    {
                        jugadorDef.setProtectPoisonBleed("Poison", 0, false);
                        jugadorDef.setProtectPoisonBleed("Poison", 1, false);
                        jugadorDef.setProtectPoisonBleed("Poison", 2, false);
                    }
                    else jugadorDef.setProtectPoisonBleed("Poison", 2, true);
                }
                else jugadorDef.setProtectPoisonBleed("Poison", 1, true);
            }
        }
        public void getMovimientos()
        {
            Console.WriteLine(nombre + "'S MOVEMENTS");
            Console.WriteLine();
            foreach (string i in movimientos)
            {
                Console.WriteLine(i);
            }
        }
        static public void mostrarResultado(string mensaje)
        {
            switch (mensaje)
            {
                case "SUCCESS":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("SUCCESS");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "DODGED":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("PROTECTED");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "FAIL":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("FAIL");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "PROTECTED":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(" (Protected)");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "POISONED":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(" (Poisoned)");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "BLEEDING":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(" (Bleeding)");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "TANK":
                    Console.Write(" (TANK)");
                    break;
                case "LUCKY":
                    Console.Write(" (LUCKY)");
                    break;
                case "CHEATER":
                    Console.Write(" (CHEATER)");
                    break;
            }
        }
    }