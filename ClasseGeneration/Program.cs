//------Programma Principale-------------
int maxPostiAula = 10;
int nAlunniIscritti = 0;

string[] cognomeAlunni = new string[maxPostiAula];
string[] nomeAlunni = new string[maxPostiAula];
int[] etaAlunni = new int[maxPostiAula];


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

void aggiungiAlunno(string nome, string cognome, int eta)
{
    if(nAlunniIscritti < maxPostiAula)
    {
        Console.WriteLine("Inserisci i dati del nuovo alunno: ");
        Console.WriteLine("Nome: ");
        nomeAlunni[nAlunniIscritti] = nome;
        cognomeAlunni[nAlunniIscritti] = cognome;
        etaAlunni[nAlunniIscritti] = eta;

        nAlunniIscritti++;
    }
    else
    {
        Console.WriteLine("Hai raggiunto il numero massimo di iscrizioni");
    }
}

void rimuoviUltimoAlunno()
{
    if(nAlunniIscritti > 0)
    {
        nomeAlunni[nAlunniIscritti] = "";
        cognomeAlunni[nAlunniIscritti] = "";
        etaAlunni[nAlunniIscritti] = 0;
        nAlunniIscritti--;
    }
    else
    {
        Console.WriteLine("Non ci sono più alunni iscritti a questo corso!");
    }
}