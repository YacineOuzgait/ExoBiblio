using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.classes
{

  internal class Livre : BaseModel<Livre>
    {
        
        string titre;
        string isbn;

        public string Titre
        { 
            get
            { return titre; } 
            set
            {
                if (this.titre != value)
                {
                    this.titre = value;
                }
            }
                }
        public string Isbn
        {
            get
            { return isbn; }
            set
            {
                if (this.isbn != value)
                {
                    this.isbn = value;
                }
            }
        }
    }

    [JsonIgnore]
    private List<Exemplaire> exemplairesList;
    public List<Exemplaire> ExemplairesList
    {
        get
        {
            if (this.exemplairesList == null)
            {
                this.exemplairesList = Exemplaire.jDA.GetAll(item => item.IdLivre == this.Id);
            }
            return this.exemplairesList;
        }
    }
    public List<Exemplaire> AddExemplaire(Exemplaire exemplaire)
    {
        if (this.ExemplairesList.Find(item => item.Id == exemplaire.Id) == null)
        {
            this.ExemplairesList.Add(exemplaire);
            if (exemplaire.Livre.Id != this.Id)
            {
                exemplaire.Livre = this;
            }
        }
        return this.ExemplairesList;
    }

    public List<Exemplaire> RemoveExemplaire(Exemplaire exemplaire)
    {
        int index = this.ExemplairesList.FindIndex(item => item.Id == exemplaire.Id);
        if (index >= 0)
        {
            this.ExemplairesList.RemoveAt(index);
            if (exemplaire.Livre.Id == this.Id)
            {
                exemplaire.Livre = null;
            }
        }
        return this.ExemplairesList;
    }

    [JsonIgnore]
    private List<Reservation> reservationsList;
    public List<Reservation> ReservationsList
    {
        get
        {
            if (this.reservationsList == null)
            {
                this.reservationsList = Reservation.jDA.GetAll(item => item.IdLivre == this.Id);
            }
            return this.reservationsList;
        }
    }
    public List<Reservation> AddReservation(Reservation reservation)
    {
        if (this.ReservationsList.Find(item => item.Id == reservation.Id) == null)
        {
            this.ReservationsList.Add(reservation);
            if (reservation.Livre.Id != this.Id)
            {
                reservation.Livre = this;
            }
        }
        return this.ReservationsList;
    }

    public List<Reservation> RemoveReservation(Exemplaire reservation)
    {
        int index = this.ReservationsList.FindIndex(item => item.Id == reservation.Id);
        if (index >= 0)
        {
            this.ReservationsList.RemoveAt(index);
            if (reservation.Livre.Id == this.Id)
            {
                reservation.Livre = null;
            }
        }
        return this.ReservationsList;
    }

    [JsonIgnore]
    private List<int> idAuteurList;
    public List<int> IdAuteurList
    {
        get
        {
            if (this.idAuteurList == null)
            {

                List<dynamic> ids = jDA.LoadJsonData("auteur_livre").FindAll(item => item.id_livre == this.Id);
                idAuteurList = new();
                ids.ForEach(item =>
                {
                    idAuteurList.Add((int)item.id_auteur);
                });
            }
            return this.idAuteurList;
        }
    }

    [JsonIgnore]
    private List<Auteur> auteurList;
    public List<Auteur> AuteurList
    {
        get
        {
            if (this.auteurList == null)
            {
                this.auteurList = Auteur.jDA.GetAll(item => this.IdAuteurList.Contains(item.Id));
            }
            return this.auteurList;
        }
    }

    public List<Auteur> AddAuteur(Auteur auteur)
    {
        if (this.AuteurList.Find(item => item.Id == auteur.Id) == null)
        {
            this.IdAuteurList.Add(auteur.Id);
            this.AuteurList.Add(auteur);
            auteur.AddLivre(this);
            //TODO persist
        }
        return this.AuteurList;
    }

    public List<Auteur> RemoveAuteur(Auteur auteur)
    {
        int index = this.AuteurList.FindIndex(item => item.Id == auteur.Id);
        if (index >= 0)
        {
            this.IdAuteurList.Remove(auteur.Id);
            this.AuteurList.RemoveAt(index);
            auteur.RemoveLivre(this);
            //TODO persist
        }
        return this.AuteurList;
    }

    [JsonIgnore]
    private List<int> idThemeList;
    public List<int> IdThemeList
    {
        get
        {
            if (this.idThemeList == null)
            {

                List<dynamic> ids = jDA.LoadJsonData("theme_livre").FindAll(item => item.id_livre == this.Id);
                idThemeList = new();
                ids.ForEach(item =>
                {
                    idThemeList.Add((int)item.id_theme);
                });
            }
            return this.idThemeList;
        }
    }

    [JsonIgnore]
    private List<Theme> themeList;
    public List<Theme> ThemeList
    {
        get
        {
            if (this.themeList == null)
            {
                this.themeList = Auteur.jDA.GetAll(item => this.IdThemeList.Contains(item.Id));
            }
            return this.themeList;
        }
    }

    public List<Theme> AddTheme(Theme theme)
    {
        if (this.ThemeList.Find(item => item.Id == theme.Id) == null)
        {
            this.IdThemeList.Add(theme.Id);
            this.ThemeList.Add(theme);
            theme.AddLivre(this);
            //TODO persist
        }
        return this.ThemeList;
    }

    public List<Theme> RemoveTheme(Theme theme)
    {
        int index = this.ThemeList.FindIndex(item => item.Id == theme.Id);
        if (index >= 0)
        {
            this.IdThemeList.Remove(theme.Id);
            this.ThemeList.RemoveAt(index);
            theme.RemoveLivre(this);
            //TODO persist
        }
        return this.ThemeList;
    }

    [JsonIgnore]
    private List<int> idMotCleList;
    public List<int> IdMotCleList
    {
        get
        {
            if (this.idMotCleList == null)
            {

                List<dynamic> ids = jDA.LoadJsonData("motcle_livre").FindAll(item => item.id_livre == this.Id);
                idMotCleList = new();
                ids.ForEach(item =>
                {
                    idMotCleList.Add((int)item.id_motcle);
                });
            }
            return this.idMotCleList;
        }
    }

    [JsonIgnore]
    private List<MotCle> motcleList;
    public List<MotCle> MotCleList
    {
        get
        {
            if (this.motcleList == null)
            {
                this.motcleList = MotCle.jDA.GetAll(item => this.IdMotCleList.Contains(item.Id));
            }
            return this.motcleList;
        }
    }

    public List<MotCle> AddMotCle(MotCle motcle)
    {
        if (this.MotCleList.Find(item => item.Id == motcle.Id) == null)
        {
            this.IdMotCleList.Add(motcle.Id);
            this.MotCleList.Add(motcle);
            motcle.AddLivre(this);
            //TODO persist
        }
        return this.MotCleList;
    }

    public List<MotCle> RemoveMotCle(MotCle motcle)
    {
        int index = this.MotCleList.FindIndex(item => item.Id == motcle.Id);
        if (index >= 0)
        {
            this.IdMotCleList.Remove(motcle.Id);
            this.MotCleList.RemoveAt(index);
            motcle.RemoveLivre(this);
            //TODO persist
        }
        return this.MotCleList;
    }


}

