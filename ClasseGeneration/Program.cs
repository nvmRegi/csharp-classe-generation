//------Programma Principale-------------
int maxPostiAula = 10;
int nAlunniIscritti = 0;

string[] cognomeAlunni = new string[maxPostiAula];
string[] nomeAlunni = new string[maxPostiAula];
int[] etaAlunni = new int[maxPostiAula];



while (true)
{   
    Console.WriteLine("BENVENUTO NEL MIO PROGRAMMA!\n"); 

    Console.WriteLine("Seleziona un'opzione: ");
    Console.WriteLine("0 - Numero degli alunni iscritti.");
    Console.WriteLine("1 - Elenco dei nomi degli alunni iscritti.");
    Console.WriteLine("2 - Elenco dei cognomi degli alunni iscritti.");
    Console.WriteLine("3 - Elenco delle età degli alunni iscritti.");
    Console.WriteLine("4 - Aggiungi i dati di un nuovo alunno.");
    Console.WriteLine("5 - Rimuovi i dati dell'ultimo alunno iscritto.");
    Console.WriteLine("6 - Statistiche.\n");

    int risposta = Convert.ToInt32(Console.ReadLine());

    Console.Clear();

    switch (risposta)
    {
        case 0:
            Console.WriteLine("Il numero degli alunni iscritti in questo corso è: " + nAlunniIscritti);
            break;

        case 1:
            stampaElementoArray(nomeAlunni);
            break;
        case 2:
            stampaElementoArray(cognomeAlunni);
            break;
        case 3:
            stampaEtaAlunni(etaAlunni);
            break;
        case 4:
            if(nAlunniIscritti < maxPostiAula)
            {
                Console.WriteLine("Inserisci i dati del nuovo alunno: ");
                Console.Write("Nome: ");
                string nomeInserito = Console.ReadLine();
                Console.Write("Cognome: ");
                string cognomeInserito = Console.ReadLine();
                Console.Write("Età: ");
                int etaInserito = Convert.ToInt32(Console.ReadLine());
                aggiungiAlunno(nomeInserito, cognomeInserito, etaInserito);
            }
            else
            {
                Console.WriteLine("Hai raggiunto il numero massimo di iscrizioni");
            }
            
            break;
        case 5:
            rimuoviUltimoAlunno();
            break;
        case 6:
            if (nAlunniIscritti != 0)
            {
                Console.WriteLine("Statistiche sulla classe: ");
                float etaMedia = etaMediaClasse();
                Console.WriteLine("L'età media della classe è: " + etaMedia);
                int ilPiuGiovane = etaPiuGiovane();
                Console.WriteLine("L'età dell'alunno più giovane è: " + ilPiuGiovane);
                int ilPiuVecchio = etaPiuVecchio();
                Console.WriteLine("L'età dell'alunno più vecchio è: " + ilPiuVecchio);

                Console.WriteLine("L'alunno più giovane è: " + nomeAlunni[posizioneGiovane()] + " " + cognomeAlunni[posizioneGiovane()] + " e ha " + ilPiuGiovane + " anni.");
                Console.WriteLine("L'alunno più vecchio è: " + nomeAlunni[posizioneVecchio()] + " " + cognomeAlunni[posizioneVecchio()] + " e ha " + ilPiuVecchio + " anni.");
            }
            else
            {
                Console.WriteLine("Non ci sono alunni.");
            }
            break;
        default:
            Console.WriteLine("Non hai inserito un'opzione valida!");
            break;

    }

    Console.WriteLine("\n\n\nPremere un qualsiasi tasto per andare avanti...");
    Console.ReadKey();
    Console.Clear();
}


//------Funzioni-------------------------
void stampaElementoArray(string[] array) //stampa gli elementi di un array string generico
{
    for(int i = 0; i < array.Length; i++)
    {
        Console.WriteLine((i + 1) + " - " + array[i]);
    }
}

void stampaEtaAlunni(int[] eta) //stampa gli elementi di un array int
{
    for(int i = 0; i < eta.Length; i++)
    {
        Console.WriteLine((i + 1) + " - " + eta[i]);
    }
}

void aggiungiAlunno(string nome, string cognome, int eta) //aggiungi un elemento ai miei array globali
{
        nomeAlunni[nAlunniIscritti] = nome;
        cognomeAlunni[nAlunniIscritti] = cognome;
        etaAlunni[nAlunniIscritti] = eta;

        nAlunniIscritti++;
}

void rimuoviUltimoAlunno() // rimuovo ultimo elemento dai miei array globali
{
    if(nAlunniIscritti > 0)
    {
        nomeAlunni[nAlunniIscritti - 1] = "";
        cognomeAlunni[nAlunniIscritti - 1] = "";
        etaAlunni[nAlunniIscritti - 1] = 0;
        nAlunniIscritti--;
    }
    else
    {
        Console.WriteLine("Non ci sono più alunni iscritti a questo corso!");
    }
}

float etaMediaClasse()
{
    int somma = 0;
    for(int i = 0; i < nAlunniIscritti; i++)
    {
        somma += etaAlunni[i];
    }
    float media = somma / nAlunniIscritti;
    return media;
}

int etaPiuGiovane()
{
    int etaQuelloPiuGiovane = etaAlunni[0];
    for(int i = 0; i < nAlunniIscritti; i++)
    {
        if(etaAlunni[i] < etaQuelloPiuGiovane)
        {
            etaQuelloPiuGiovane = etaAlunni[i];
        }
    }
    return etaQuelloPiuGiovane;
}

int etaPiuVecchio()
{
    int etaQuelloPiuVecchio = etaAlunni[0];
    for (int i = 0; i < nAlunniIscritti; i++)
    {
        if (etaAlunni[i] > etaQuelloPiuVecchio)
        {
            etaQuelloPiuVecchio = etaAlunni[i];
        }
    }
    return etaQuelloPiuVecchio;
}

int posizioneGiovane()
{
    int i;
    for(i = 0; i < nAlunniIscritti; i++)
    {
        if(etaPiuGiovane() == etaAlunni[i])
        {
            break;
        }
    }
    return i;
}

int posizioneVecchio()
{
    int i;
    for (i = 0; i < nAlunniIscritti; i++)
    {
        if (etaPiuVecchio() == etaAlunni[i])
        {
            break;
        }
    }
    return i;
}